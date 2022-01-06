using clean_arch.common.Domain.Seedwork;

namespace clean_arch.domain.Aggregates.Customers
{
    public class BankAccountType : BaseEntity
    {
        public BankAccountType(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
