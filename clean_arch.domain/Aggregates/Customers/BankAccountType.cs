using clean_arch.common.Domain.Seedwork;

namespace clean_arch.domain.Aggregates.Customers
{
    public class BankAccountType : Enumeration
    {

        public static BankAccountType Savings = new(1, nameof(Savings));
        public static BankAccountType Checking = new(2, nameof(Checking));

        public BankAccountType(int id, string name) : base(id, name)
        {
        }
    }
}
