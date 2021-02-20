using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class UserImageConfiguration : IEntityTypeConfiguration<UserImage>
    {
        public void Configure(EntityTypeBuilder<UserImage> builder)
        {
            builder.ToTable("UserImages");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.ContactID);
            builder.Property(x => x.DayCreated);
            builder.Property(x => x.Caption);
            builder.Property(x => x.FileSize);
            builder.Property(x => x.ImagePath);
            builder.Property(x => x.IsDefault);
            builder.HasOne(x => x.Contacts).WithMany(x => x.UserImages).HasForeignKey(x => x.ContactID);
        }
    }
}