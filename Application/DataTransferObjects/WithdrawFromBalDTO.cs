using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects
{
    public class WithdrawFromBalDTO
    {
        public long Amount { get; set; }
        public long WalletNumber { get; set; }    
        public string Currency { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    
    }
}
