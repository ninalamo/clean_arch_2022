using clean_arch.domain.Aggregates.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_arch.infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Ignore(c => c.DomainEvents);
            builder.Property(c => c.RowVersion).IsRowVersion();

            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.LastName).IsRequired();

            builder.HasMany(c => c.BankAccounts)
                .WithOne()
                .HasForeignKey("CustomerID")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata.FindNavigation(nameof(Customer.BankAccounts)).SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(c => c.Transactions)
             .WithOne()
             .HasForeignKey("CustomerID")
             .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata.FindNavigation(nameof(Customer.Transactions)).SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property<Guid>("BankID").IsRequired();

            builder.OwnsOne(o => o.Address);

        }
    }

}
