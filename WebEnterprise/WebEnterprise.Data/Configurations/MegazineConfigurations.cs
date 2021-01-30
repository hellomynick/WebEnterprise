﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class MegazineConfigurations : IEntityTypeConfiguration<Megazine>
    {
        public void Configure(EntityTypeBuilder<Megazine> builder)
        {
            builder.ToTable("Megazines");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name);
            builder.Property(x => x.DocumentID);
        }
    }
}
