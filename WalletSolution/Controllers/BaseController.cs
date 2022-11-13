using Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WalletSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {


        public BaseController()
        {

        }

        internal Error PopulateError(int code, string message, string type)
        {
            return new Error()
            {
                Code = code,
                Message = message,
                Type = type
            };
        }
    }
}

