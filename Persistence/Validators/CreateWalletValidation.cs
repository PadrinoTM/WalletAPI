using FluentValidation;
using Persistence.MediaTR.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Validators
{
    public sealed class CreateWalletValidation : AbstractValidator<CreateUserWallet>
    {
        public CreateWalletValidation()
        {
            RuleFor(c => c.CreateWalletDTO.FirstName).NotEmpty().MaximumLength(60);
            RuleFor(c => c.CreateWalletDTO.LastName).NotEmpty().MaximumLength(60);
            RuleFor(c => c.CreateWalletDTO.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.CreateWalletDTO.Password).NotEmpty();
            RuleFor(c => c.CreateWalletDTO.DateOfBirth).NotEmpty();
            RuleFor(c => c.CreateWalletDTO.BVN).NotEmpty();
            




        }

    }
}
