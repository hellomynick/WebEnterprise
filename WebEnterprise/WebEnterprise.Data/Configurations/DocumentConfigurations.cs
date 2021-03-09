using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            builder.Property(x => x.UserID);
            builder.Property(x => x.FileSize);
            builder.Property(x => x.DocumentPath);
            builder.Property(x => x.CreateOn);
            builder.Property(x => x.Caption);
            builder.Property(x => x.ViewCount);
            builder.Property(x => x.FacultyOfDocumentID);
            builder.Property(x => x.MagazineID);
            builder.HasOne(x => x.User).WithMany(x => x.Documents).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.FacultyOfDocuments).WithMany(x => x.Documents).HasForeignKey(x => x.FacultyOfDocumentID);
            builder.HasOne(x => x.Magazines).WithMany(x => x.Documents).HasForeignKey(x => x.MagazineID);
        }
    }
}