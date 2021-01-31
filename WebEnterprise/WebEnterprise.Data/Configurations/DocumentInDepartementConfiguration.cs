using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class DocumentInDepartementConfiguration : IEntityTypeConfiguration<DocumentInDepartment>
    {
        public void Configure(EntityTypeBuilder<DocumentInDepartment> builder)
        {
            builder.ToTable("DocumentInDepartments");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.DepartmentCategoloryID);
            builder.Property(x => x.DocumentID);

        }
    }
}
