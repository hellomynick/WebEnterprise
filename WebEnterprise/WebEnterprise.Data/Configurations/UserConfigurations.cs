using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(200);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(200);
            builder.Property(x => x.DateOfBirth).IsRequired(true);
            builder.Property(x => x.Sex).IsRequired(true);
            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.CreateOn);
        }
    }
}