using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class SchoolYearConfigurations : IEntityTypeConfiguration<SchoolYear>
    {
        public void Configure(EntityTypeBuilder<SchoolYear> builder)
        {
            builder.ToTable("SchoolYears");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.UserID);
            builder.Property(x => x.StartDayYear);
            builder.Property(x => x.EndDayYear);
            builder.HasOne(x => x.Users).WithMany(x => x.SchoolYears).HasForeignKey(x => x.UserID);
        }
    }
}
