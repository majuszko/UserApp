using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserApp.Models;

namespace UserApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Message>()
                .HasOne<AppUser>(a => a.Sender)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.UserID);
        }
        public DbSet<Message> Messages { get; set; }
    }
}
