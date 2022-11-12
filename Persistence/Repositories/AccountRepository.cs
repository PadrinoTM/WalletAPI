using Application.DataTransferObjects;
using AutoMapper;
using Domain.Common.Enums;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserWalletDbContext context;
        private readonly UserManager<UserProfile> userManager;
        private readonly SignInManager<UserProfile> signinMgr;
        private readonly IMapper mapper;
        private List<long> accountNum = new List<long>();

        public AccountRepository(UserWalletDbContext context, UserManager<UserProfile> userManager, SignInManager<UserProfile> signinMgr, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
            this.signinMgr = signinMgr;
        }


        public async Task<bool> CreditAccount(CreditAccountDTO creditDto)
        {
            UserProfile person = new();
            var wallet = await context.WalletAccounts.FindAsync(creditDto.WalletNumber);
            var user = await context.UserProfiles.Where(x => wallet.Id == x.walletAccount.Id).FirstOrDefaultAsync();

            if (creditDto.Currency == AccountType.USD)
            {
                var newBalance = user.walletAccount.USDWallet + creditDto.Amount;
                var walletBalance = new WalletAccount(user.walletAccount.WalletNumber, user.walletAccount.WalletNumber, user.walletAccount.NGNWallet, newBalance);
                var tranHistory = new TransactionProfile()
                {
                    TransactionDate = DateTime.Now,
                    TransactionType = TransactionType.CREDIT,
                    TransactionName = $"{user.FirstName} Account was Credited in USD"
                };
                await context.SaveChangesAsync();
                return true;

            }
            else if (creditDto.Currency == AccountType.NGN)
            {
                var newBalance = user.walletAccount.NGNWallet + creditDto.Amount;
                var walletBalance = new WalletAccount(user.walletAccount.WalletNumber, user.walletAccount.WalletNumber, newBalance, user.walletAccount.USDWallet);
                var tranHistory = new TransactionProfile()
                {
                    TransactionDate = DateTime.Now,
                    TransactionType = TransactionType.CREDIT,
                    TransactionName = $"{user.FirstName} Account was Credited in NGN"
                };
                await context.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<WalletAccount> CreateWallet(CreateWalletDTO createWalletDTO)
        {
            var user = mapper.Map<UserProfile>(createWalletDTO);
            var newUser = await userManager.CreateAsync(user, createWalletDTO.Password);
            if (newUser.Succeeded)
            {

                var accNum = WalletNumGenerator();
                return new WalletAccount(accNum, 0, 0, 0);


            }

            return null;
        }

        public long WalletNumGenerator()
        {
            Random random = new Random();
            long nuban = random.Next(32000000, 33000000);

            foreach (var item in accountNum)
            {
                if (nuban == item)
                {
                    return WalletNumGenerator();
                }
            }
            return nuban;

        }

        public async Task<string> ViewWalletBalance(ViewBalanceDTO viewBal)
        {
            //if (!string.IsNullOrEmpty(viewBal) return null;

            var result = await signinMgr.PasswordSignInAsync(viewBal.Email, viewBal.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await userManager.FindByEmailAsync(viewBal.Email);

                if (user.walletAccount.WalletNumber == viewBal.WalletNumber)
                {
                    var wallet = await context.WalletAccounts.FindAsync(viewBal.WalletNumber);
                    return $"Your USD Balance is {wallet.USDWallet} ,your NGN balance is {wallet.NGNWallet}";
                }
                else
                {
                    return $"Wallet Number does not correspond to User details";
                }

            }

            else
            {
                return "Login Attempt was unsuccessful";
            }




        }

        public async Task<string> WithdrawBalance(WithdrawFromBalDTO withdrawFromBalDTO)
        {
            var result = await signinMgr.PasswordSignInAsync(withdrawFromBalDTO.Email, withdrawFromBalDTO.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await userManager.FindByEmailAsync(withdrawFromBalDTO.Email);
                if (user.walletAccount.WalletNumber == withdrawFromBalDTO.WalletNumber)
                {
                    var wallet = await context.WalletAccounts.FindAsync(withdrawFromBalDTO.WalletNumber);
                    if (withdrawFromBalDTO.Currency == AccountType.USD.ToString() && withdrawFromBalDTO.Amount >= wallet.USDWallet)
                    {
                        var newUSD = wallet.USDWallet - withdrawFromBalDTO.Amount;
                        var newWallet = new WalletAccount(wallet.WalletNumber, 0, wallet.NGNWallet, newUSD);
                        return $"Your New USD Balance is {newUSD}";
                    }

                    else if (withdrawFromBalDTO.Currency == AccountType.NGN.ToString() && withdrawFromBalDTO.Amount >= wallet.NGNWallet)
                    {
                        var newNGN = wallet.NGNWallet - withdrawFromBalDTO.Amount;
                        var newWallet = new WalletAccount(wallet.WalletNumber, 0, newNGN, wallet.USDWallet);
                        return $"Your New NGN Balance is {newNGN}";
                    }

                    else
                    {
                        return "Cannot withdraw more than your current Balance in NGN or USD";
                    }
                }

                else
                {
                    return "Wallet Number doesnt match the user, please input the correct wallet";
                }
            }

            else
            {
                return "Login attempts failed";
            }

        }


    }
}
