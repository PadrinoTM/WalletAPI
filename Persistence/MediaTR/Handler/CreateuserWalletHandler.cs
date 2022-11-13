using Application.DataTransferObjects;
using AutoMapper;
using MediatR;
using Persistence.MediaTR.Commands;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.MediaTR.Handler
{
    internal sealed class CreateuserWalletHandler : IRequestHandler<CreateUserWallet, WalletReturnDTO>
    {
        private readonly IAccountRepository _repo;
        private readonly IMapper _mapper;

        public CreateuserWalletHandler(IAccountRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;   

        }

        public async Task<WalletReturnDTO> Handle(CreateUserWallet request, CancellationToken cancellationToken)
        {
            var result = await _repo.CreateWallet(request.CreateWalletDTO);
            WalletReturnDTO walletReturnDTO = new WalletReturnDTO()
            {
                Email = request.CreateWalletDTO.Email,
                USDbalance = result.USDWallet,
                NGNbalance = result.NGNWallet,
                WalletNumber = result.WalletNumber

            };

            return walletReturnDTO;
        }
    }
}
