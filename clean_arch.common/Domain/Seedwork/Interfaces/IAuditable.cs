using System;

namespace clean_arch.common.Domain.Seedwork.Interfaces
{
    public interface IAuditable
    {
        string CreatedBy
        {
            get;
            set;
        }

        string ModifiedBy
        {
            get;
            set;
        }

        DateTime CreatedOn
        {
            get;
            set;
        }

        DateTime ModifiedOn
        {
            get;
            set;
        }

        bool IsActive
        {
            get;
            set;
        }

        byte[] RowVersion
        {
            get;
            set;
        }
    }
}
