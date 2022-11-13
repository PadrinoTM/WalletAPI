using AutoMapper;
using Persistence.MediaTR.Commands;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.MediaTR.Handler
{
    internal class WithdrawFromBalHandler
    {
      

            private readonly IAccountRepository _repo;
            private readonly IMapper _mapper;

            public WithdrawFromBalHandler(IAccountRepository repo, IMapper mapper)
            {
                _repo = repo;
                _mapper = mapper;

            }
            public async Task<bool> Handle(WithdrawFromAccountCommand request, CancellationToken cancellationToken)
            {
            var result = await _repo.WithdrawBalance(request.WithdrawFromBalDTO);

            return result;
            }
        }
    
}
