//using Application.DataTransferObjects;
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
    internal class CreditAccountHandler : IRequestHandler<CreditAccountCommand, bool>
    {

        private readonly IAccountRepository _repo;
        private readonly IMapper _mapper;

        public CreditAccountHandler(IAccountRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }
        public async Task<bool> Handle(CreditAccountCommand request, CancellationToken cancellationToke)
        {
            var result = await _repo.CreditAccount(request.CreditAccountDTO);
            return result;
        }
    }
}

