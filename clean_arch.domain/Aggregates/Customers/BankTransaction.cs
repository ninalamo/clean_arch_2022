using clean_arch.common.Domain.Seedwork;
using System;

namespace clean_arch.domain.Aggregates.Customers
{
    public class BankTransaction : BaseEntity
    {
        public DateTimeOffset TransactionDate { get; private set; }
        public string TransactionType { get; private set; }
        public decimal Balance { get; private set; }

    }
}
