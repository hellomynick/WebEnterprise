using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Data.Configurations
{
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => new { x.ID });
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.UserID);
            builder.Property(x => x.DocumentID);
            builder.Property(x => x.Content);
            builder.HasOne(x => x.Users).WithMany(x => x.Comments).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.Documents).WithMany(x => x.Comments).HasForeignKey(x => x.DocumentID);
        }
    }
}