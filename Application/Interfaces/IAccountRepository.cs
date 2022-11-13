using Application.DataTransferObjects;
using Domain.Entities;

namespace Persistence.Repositories
{
    public interface IAccountRepository
    {
        Task<WalletAccount> CreateWallet(CreateWalletDTO createWalletDTO);
        Task<bool> CreditAccount(CreditAccountDTO creditDto);
        Task<string> ViewWalletBalance(ViewBalanceDTO viewBal);
        long WalletNumGenerator();
        Task<bool> WithdrawBalance(WithdrawFromBalDTO withdrawFromBalDTO);
    }
}