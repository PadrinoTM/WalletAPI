using Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects
{
    public class WithdrawalRequestDTO
    { 
        public long Amount { get; set; }    
        public AccountType walletType { get; set; }

    }
}
