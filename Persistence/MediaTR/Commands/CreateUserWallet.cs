using Application.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.MediaTR.Commands
{
    public sealed record CreateUserWallet(CreateWalletDTO CreateWalletDTO): IRequest<WalletReturnDTO>
    {
    }
}
