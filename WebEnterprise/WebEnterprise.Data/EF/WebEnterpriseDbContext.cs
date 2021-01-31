using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.Data.Configurations;
using WebEnterprise.Data.Entities;
using WebEnterprise.Data.Extensions;

namespace WebEnterprise.Data.EF
{
    public class WebEnterpriseDbContext : IdentityDbContext<User, GroupUser, Guid>
    {
        public WebEnterpriseDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfigurations());
            modelBuilder.ApplyConfiguration(new CommentConfigurations());
            modelBuilder.ApplyConfiguration(new DepartmentCatelogoryConfigurations());
            modelBuilder.ApplyConfiguration(new DocumentConfigurations());
            modelBuilder.ApplyConfiguration(new SelectedConfigurations());
            modelBuilder.ApplyConfiguration(new SchoolYearConfigurations());

            modelBuilder.ApplyConfiguration(new GroupUserConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserToken").HasKey(x => x.UserId);


            //Data seeding
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Contact> Addresses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DepartmentCatelogory> DepartmentCatelogories { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Selected> Megazines { get; set; }
    }
}
