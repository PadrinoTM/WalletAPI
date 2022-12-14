using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class UserProfile : IdentityUser
    {
    [Key]
    public string Id { get; set; }  = Guid.NewGuid().ToString();    
  
    [Required]  
    [EmailAddress]
    public string Email { get; set; }   

    [Required]
    [StringLength(100, ErrorMessage = "Name should be under 60 characters")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Name should be under 60 characters")]
    public string LastName { get; set; }


    [Required]
    public string UserName { get; set; }
    public DateTime DOB { get; set; }
    public long BVN { get; set; }
    public string Gender { get; set; }
    [ForeignKey("WalletId")]
    public string WalletId { get; set; }    
    public WalletAccount walletAccount { get; set; }
    public IEnumerable<TransactionProfile> transactionProfile { get; set; }


    }

