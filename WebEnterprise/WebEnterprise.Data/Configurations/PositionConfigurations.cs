using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class PositionConfigurations : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.Name);
            builder.Property(x => x.UserID);
            builder.Property(x => x.FacultyID);
            builder.HasOne(x => x.Users).WithMany(x => x.Positions).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.Faculties).WithMany(x => x.Positions).HasForeignKey(x => x.FacultyID);
        }
    }
}