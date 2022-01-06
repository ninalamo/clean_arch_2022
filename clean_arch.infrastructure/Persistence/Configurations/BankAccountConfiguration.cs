using clean_arch.domain.Aggregates.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace clean_arch.infrastructure.Persistence.Configurations
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.RowVersion).IsRowVersion();
            builder.HasIndex(c => c.Number).IsUnique();

            builder.Property<Guid>("CustomerID").IsRequired();
        }
    }



}
