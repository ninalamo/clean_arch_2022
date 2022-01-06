using clean_arch.domain.Aggregates.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace clean_arch.infrastructure.Persistence.Configurations
{
    public class BankTransactionConfiguration : IEntityTypeConfiguration<BankTransaction>
    {
        public void Configure(EntityTypeBuilder<BankTransaction> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.RowVersion).IsRowVersion();

            builder.Property<Guid>("CustomerID").IsRequired();
        }
    }






}
