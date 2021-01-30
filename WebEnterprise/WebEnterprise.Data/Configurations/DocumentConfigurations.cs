using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class DocumentConfigurations : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Documents");
            builder.HasKey(x => new { x.ID });
            builder.Property(x => x.Name);
            builder.Property(x => x.UserID);
            builder.Property(x => x.DepartmentCatelogoryID);
            builder.Property(x => x.DateFile);
            builder.Property(x => x.FileType);
            builder.Property(x => x.CreateOn);
            builder.HasOne(x => x.User).WithMany(x => x.Documents).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.Megazines).WithMany(x => x.Documents).HasForeignKey(x => x.ID);
            builder.HasOne(x => x.DepartmentCatelogorys).WithMany(x => x.Documents).HasForeignKey(x => x.DepartmentCatelogoryID);

        }
    }
}
