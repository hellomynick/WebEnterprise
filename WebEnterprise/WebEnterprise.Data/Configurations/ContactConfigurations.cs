using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.UserID);
            builder.Property(x => x.ApartmentNumber);
            builder.Property(x => x.NameStreet);
            builder.Property(x => x.Image);
            builder.HasOne(x => x.Users).WithOne(x => x.Contacts).HasForeignKey<Contact>(x => x.UserID);
        }
    }
}
