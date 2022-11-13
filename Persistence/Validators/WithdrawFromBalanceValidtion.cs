using Domain.Common.Enums;
using FluentValidation;
using Persistence.MediaTR.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Validators
{

    public sealed class WithdrawFromBalanceValidtion : AbstractValidator<WithdrawFromAccountCommand>
    {
        public WithdrawFromBalanceValidtion()
        {
            RuleFor(c => c.WithdrawFromBalDTO.Amount).NotEmpty();
            RuleFor(c => c.WithdrawFromBalDTO.Currency).NotEmpty();
            RuleFor(c => c.WithdrawFromBalDTO.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.WithdrawFromBalDTO.Password).NotEmpty();


        }

    }
}
