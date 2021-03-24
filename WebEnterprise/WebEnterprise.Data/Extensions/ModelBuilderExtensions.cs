using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roleId = new Guid("9936B153-37A9-41D8-9781-F0532C25E732");
            var userId = new Guid("A0626E5F-0945-425C-9135-421CE9FFD4A1");
            modelBuilder.Entity<Faculty>().HasData(
               new Faculty()
               {
                   ID = 1,
                   Name = "IT",
               });
            modelBuilder.Entity<SchoolYear>().HasData(
               new SchoolYear()
               {
                   ID = 1,
                   UserID = userId,
                   EndDayYear = new DateTime(2020, 03, 09),
                   StartDayYear = new DateTime(2020, 05, 10)
               });
            // any guid
            modelBuilder.Entity<GroupUser>().HasData(new GroupUser
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin"
            });
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = userId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "minhvu09033@gmail.com",
                NormalizedEmail = "minhvu09033@gmail.com",
                EmailConfirmed = true,
                FirstName = "Tran Van",
                LastName = "Minh Vu",
                FacultyID = 1,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                DateOfBirth = new DateTime(2000, 03, 09),
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = userId
            });
            modelBuilder.Entity<Language>().HasData(
               new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
               new Language() { Id = "en", Name = "English", IsDefault = false });
        }
    }
}