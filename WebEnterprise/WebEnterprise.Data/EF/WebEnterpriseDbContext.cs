using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
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
            modelBuilder.ApplyConfiguration(new FacultyConfigurations());
            modelBuilder.ApplyConfiguration(new DocumentConfigurations());
            modelBuilder.ApplyConfiguration(new SchoolYearConfigurations());
            modelBuilder.ApplyConfiguration(new UserImageConfiguration());
            modelBuilder.ApplyConfiguration(new SetTimeSystemConfigurations());
            modelBuilder.ApplyConfiguration(new CommentConfigurations());

            modelBuilder.ApplyConfiguration(new GroupUserConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new FacultyOfDocumentConfigurations());
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserToken").HasKey(x => x.UserId);

            //Data seeding
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<FacultyOfDocument> FacultyOfDocument { get; set; }
        public DbSet<SetTimeSystem> SetTimeSystems { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}