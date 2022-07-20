using asseco_pfm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asseco_pfm.Database.Configuration
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");
            builder.HasKey(x => x.Code);
            builder.Property(x => x.Code).IsRequired(true);
            builder.Property(x => x.ParentCode).HasMaxLength(2);
            builder.Property(x => x.Name).IsRequired(true);
        }
    }
}
