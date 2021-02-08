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
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.Name);
            builder.Property(x => x.UserID);
            builder.Property(x => x.DataFile);
            builder.Property(x => x.FileType);
            builder.Property(x => x.CreateOn);
            builder.Property(x => x.ViewCount);
            builder.Property(x => x.FacultyOfDocumentID);
            builder.Property(x => x.MagazineID);
            builder.HasOne(x => x.User).WithMany(x => x.Documents).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.FacultyOfDocuments).WithOne(x => x.Documents).HasForeignKey<Document>(x => x.FacultyOfDocumentID);
            builder.HasOne(x => x.Magazines).WithMany(x => x.Documents).HasForeignKey(x => x.MagazineID);

        }
    }
}
