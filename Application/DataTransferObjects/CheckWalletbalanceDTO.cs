using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects
{
    public class CheckWalletbalanceDTO
    {
        public string Message { get; set; }
        public long WalletBalance { get; set; } 
    }
}
