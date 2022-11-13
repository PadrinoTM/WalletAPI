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
    public class WalletAccount
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public long WalletBalance { get; private set; }
        [Required]
        public long WalletNumber { get; private set; }
        public AccountType WalletType { get; set; }
        [Required]

        public long USDWallet { get; private set; }

        [Required]
        public long NGNWallet { get; private set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        [ForeignKey("userId")]
        public string userId { get; set; }
        public UserProfile users { get; set; }

        public WalletAccount()
        { }
        public WalletAccount(long walletNumber, long walletBalance, long ngnwallet, long usdwallet)
        {
            WalletBalance = walletBalance;
            USDWallet = usdwallet;
            NGNWallet = ngnwallet;
            WalletNumber = walletNumber;

        }

    }


}
