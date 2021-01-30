using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class DepartmentCatelogoryConfigurations : IEntityTypeConfiguration<DepartmentCatelogory>
    {
        public void Configure(EntityTypeBuilder<DepartmentCatelogory> builder)
        {
            builder.ToTable("DepartmentCatelogorys");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name);
            builder.Property(x => x.UserID);
            builder.HasOne(x => x.Users).WithOne(x => x.DepartmentCatelogorys).HasForeignKey<DepartmentCatelogory>(x => x.UserID);

        }
    }
}
