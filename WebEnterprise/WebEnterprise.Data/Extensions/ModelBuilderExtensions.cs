using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roleId = new Guid("9936B153-37A9-41D8-9781-F0532C25E732");
            var userId = new Guid("A0626E5F-0945-425C-9135-421CE9FFD4A1");
            modelBuilder.Entity<Contact>().HasData(
               new Contact
               {
                   ID = 1,
                   UserID = userId,
                   ApartmentNumber = "04",
                   NameStreet = "Doan Uan",
               }
               );
            modelBuilder.Entity<DepartmentCatelogory>().HasData(
                new DepartmentCatelogory
                {
                    ID = 1,
                    UserID = userId,
                    Name = "IT",
                },
                new DepartmentCatelogory
                {
                    ID = 2,
                    Name = "Design",
                },
                new DepartmentCatelogory
                {
                    ID = 3,
                    Name = "Business",
                },
                new DepartmentCatelogory
                {
                    ID = 4,
                    Name = "Tourism",
                }
                );
            modelBuilder.Entity<Megazine>().HasData(
                new Megazine
                {
                    ID = 1,
                    Name = "Magazine Information Technology"
                },
                new Megazine
                {
                    ID = 2,
                    Name = "Magazine Design"
                },
                new Megazine
                {
                    ID = 3,
                    Name = "Magazine Business"
                },
                new Megazine
                {
                    ID = 4,
                    Name = "Magazine Tourism"
                },
                new Megazine
                {
                    ID = 5,
                    Name = "Magazine Information Technology"
                }
                );

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
                PasswordHash = hasher.HashPassword(null, "123"),
                SecurityStamp = string.Empty,
                DateOfBirth = new DateTime(2000, 03, 09),
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = userId
            });
        }
    }
}
