using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects
{
    public class ViewBalanceDTO
    {
        public string Email { get; set; }   
        public string Password { get; set; }
        public long WalletNumber { get; set; }  
    }
}
