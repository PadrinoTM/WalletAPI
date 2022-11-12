using Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TransactionProfile
    {
        [Key]
        public string TransactionId { get; set; }

        public string TransactionName { get; set; } 
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        [ForeignKey("userId")]
        public string userId { get; set; }  
        public UserProfile userProfiles { get; set; }  

        //public IEnumerable<WalletAccount> walletAccounts { get; set; }  = new List<WalletAccount>();
    }
}
