using asseco_pfm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asseco_pfm.Database.Configuration
{
    public class TransactionSplitSingleTypeConfiguration : IEntityTypeConfiguration<TransactionSplitSingle>
    {
        public void Configure(EntityTypeBuilder<TransactionSplitSingle> builder)
        {
            builder.ToTable("transactionsplit");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired(true);
            builder.Property(x => x.Amount).IsRequired(true);
            builder.Property(x => x.CatCode).HasMaxLength(3);
        }
    }
}
