using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCBlog.Domain.Entities;

namespace MVCBlog.Domain.Configuration
{
    internal class EssayConfig : IEntityTypeConfiguration<Essay>
    {
        public void Configure(EntityTypeBuilder<Essay> builder)
        {
            builder.ToTable("ESSAY");

            builder.Property(p => p.Id).HasColumnName("ID").IsRequired();
            builder.Property(p => p.PublishDate).HasColumnName("PUBLISH_DATE").IsRequired();
            builder.Property(p => p.Subtitle).HasColumnName("SUBTITLE").HasMaxLength(200);
            builder.Property(p => p.Title).HasColumnName("TITLE").HasMaxLength(200).IsRequired();
            builder.Property(p => p.Body).HasColumnName("BODY").IsRequired();
        }
    }
}
