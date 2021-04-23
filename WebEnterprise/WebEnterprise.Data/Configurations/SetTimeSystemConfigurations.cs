using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class SetTimeSystemConfigurations : IEntityTypeConfiguration<SetTimeSystem>
    {
        public void Configure(EntityTypeBuilder<SetTimeSystem> builder)
        {
            builder.ToTable("SetTimeSystem");
            builder.HasKey(x => new { x.ID });
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.StartDay);
            builder.Property(x => x.EndDay);
        }
    }
}