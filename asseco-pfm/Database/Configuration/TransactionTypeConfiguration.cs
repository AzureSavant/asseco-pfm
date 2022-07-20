using asseco_pfm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asseco_pfm.Database.Configuration
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transaction");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);
            builder.Property(x => x.BeneficaryName).HasMaxLength(40);
            builder.Property(x => x.Date).IsRequired(true);
            builder.Property(x => x.Direction).HasConversion<string>().IsRequired(true);
            builder.Property(x => x.Ammount).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Currency).HasMaxLength(3).IsRequired(true);
            builder.Property(x => x.Mcc).IsRequired(false);
            builder.Property(x => x.Kind).HasConversion<string>().IsRequired(true);
            builder.Property(x => x.Catcode);
        }
    }
}
