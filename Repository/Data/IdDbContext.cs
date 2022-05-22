using System;
using Authentication.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class IdDbContext : IdentityDbContext<AppUser>
    {
        public IdDbContext(DbContextOptions<IdDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Organization>(org =>
            {
                org.ToTable("Organization");
                org.HasKey(id => id.Id);

                org.HasMany<AppUser>()
                .WithOne().HasForeignKey(fk => fk.OrgId)
                .IsRequired(false);

            });


        }



    }
}
