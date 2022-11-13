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
    public sealed class CreditAccountValidation : AbstractValidator<CreditAccountCommand>
    {
        public CreditAccountValidation()
        {
            RuleFor(c => c.CreditAccountDTO.WalletNumber).NotEmpty();
            RuleFor(c => c.CreditAccountDTO.Amount).NotEmpty().GreaterThan(0);
            RuleFor(c => c.CreditAccountDTO.Currency).NotEmpty().IsInEnum(); 
            





        }

    }
}
