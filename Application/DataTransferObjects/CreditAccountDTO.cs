using Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects
{
    public class CreditAccountDTO
    {
        public string WalletNumber { get; set; }
        public long Amount { get; set; }    
        public WalletType Currency { get; set; }
    }
}
