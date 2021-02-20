using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class FacultyOfDocumentConfigurations : IEntityTypeConfiguration<FacultyOfDocument>
    {
        public void Configure(EntityTypeBuilder<FacultyOfDocument> builder)
        {
            builder.ToTable("FacultyOfDocument");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(t => t.Name);
        }
    }
}
