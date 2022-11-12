
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DbContext
{
     public class UserWalletDbContext : IdentityDbContext<UserProfile>
    {
        public UserWalletDbContext(DbContextOptions<UserWalletDbContext> options)
           : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<WalletAccount> WalletAccounts { get; set; }

        public DbSet<TransactionProfile> TransactionProfiles { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.Entity<UserProfile>()
            .HasOne(a => a.walletAccount)
            .WithOne(a => a.users)
            .HasForeignKey<WalletAccount>(c => c.userId);

            base.OnModelCreating(builder);
        }
    }
}
