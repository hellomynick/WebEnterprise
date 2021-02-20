using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.ApartmentNumber);
            builder.Property(x => x.NameStreet);
            builder.Property(x => x.TotalofDocument);
            builder.Property(x => x.UserID);
            builder.HasOne(x => x.Users).WithMany(x => x.Contacts).HasForeignKey(x => x.UserID);
        }
    }
}