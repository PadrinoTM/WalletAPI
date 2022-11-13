using Application.DataTransferObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.MediaTR.Commands;
using Persistence.MediaTR.Queries;

namespace WalletSolution.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ISender sender;
        public AccountController(ISender sender) => this.sender = sender;
        [HttpGet]
        public async Task<IActionResult> GetBalance(ViewBalanceDTO balanceDTO)
        {
            if (balanceDTO is null)
                return BadRequest("Balance Request object is null");

            var balance = await sender.Send(new GetBalance(balanceDTO, TrackChanges: false));
           return Ok(balance);

        }

        [HttpPost]
        public async Task<IActionResult> WithdrawAmount(WithdrawFromBalDTO withdraw)
        {
            if (withdraw is null)
                return BadRequest("Withdrawal Details object is null");

            var balance = await sender.Send(new WithdrawFromAccountCommand(withdraw));

            return Ok(balance);
        }


        [HttpPost]
        public async Task<IActionResult> SendAmount(CreditAccountDTO creditAccountDTO)
        {
            if (creditAccountDTO is null)
                return BadRequest("credit Details object is null");

            var credit = await sender.Send(new CreditAccountCommand(creditAccountDTO));

            return Ok(credit);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWallet(CreateWalletDTO createWalletDTO)
        {
            if (createWalletDTO is null)
                return BadRequest("CompanyForCreationDto object is null");

            var createWallet = await sender.Send(new CreateUserWallet(createWalletDTO));
            return Ok(createWallet);
        }





    }
}
