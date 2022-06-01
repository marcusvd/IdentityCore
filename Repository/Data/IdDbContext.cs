using System;
using Authentication.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Repository.Data
{
    public class IdDbContext : IdentityDbContext<User, Role, int,
                                                                IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                                IdentityRoleClaim<int>, IdentityUserToken<int>
    >
    {
        public IdDbContext(DbContextOptions<IdDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
            userRole.HasKey(ur => new {ur.UserId, ur.RoleId});
            userRole.HasOne<User>().WithMany(u => u.UserRoles)
            .HasForeignKey(fk => fk.UserId)
            .IsRequired();
            
            userRole.HasOne<Role>().WithMany(ur => ur.UserRoles)
            .HasForeignKey(fk => fk.RoleId)
            .IsRequired();


            });




            builder.Entity<Organization>(org =>
            {
                org.ToTable("Organization");
                org.HasKey(id => id.Id);

                org.HasMany<User>()
                .WithOne().HasForeignKey(fk => fk.OrgId)
                .IsRequired(false);
            });


        }



    }
}
