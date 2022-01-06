using clean_arch.domain.Aggregates.Banks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace clean_arch.infrastructure.Persistence.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.RowVersion).IsRowVersion();
            builder.HasIndex(c => c.Name).IsUnique();

            builder.HasMany(c => c.Customers)
               .WithOne()
               .HasForeignKey("BankID")
               .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata.FindNavigation(nameof(Bank.Customers)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }

}
