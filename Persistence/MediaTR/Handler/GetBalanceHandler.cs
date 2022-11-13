using Application.DataTransferObjects;
using AutoMapper;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using Persistence.MediaTR.Queries;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.MediaTR.Handler
{
    public class GetBalanceHandler : IRequestHandler<GetBalance, Result<string>>
    {
        private readonly IAccountRepository _repo;
        private readonly IMapper _mapper;

        public GetBalanceHandler(IAccountRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Result<string>> Handle(GetBalance request, CancellationToken cancellationToken)
        {
            

            Result<string> result = new Result<string>();
            result.IsSuccess = false;
            try
            {
                var response = await _repo.ViewWalletBalance(request.viewBal);
                result.Content = response;
                if (response == "")
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "No Balance to return";
                    result.Message = "Issue, Wallet Balance not returned";
                }
                else
                {
                    result.IsSuccess = true;
                    result.ErrorMessage = "";
                    result.Message = $"{response}";
                }
            }
            catch (Exception ex)
            {
               // Logger.Error(ex, "Error while creating OneTimeTranPassword");
                result.ErrorMessage = ex.ToString();
                result.Message = "Error while returning balance";
                result.IsSuccess = false;
            }
            return result;
        }
    }
}
