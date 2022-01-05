using clean_arch.common.Domain.Seedwork.Interfaces;
using System;

namespace clean_arch.common.Domain.Seedwork
{
    public abstract class BaseEntity : IAuditable
    {
        private int? _requestedHashCode;

        private Guid _Id;

        public virtual Guid Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        public string CreatedBy
        {
            get;
            set;
        }

        public string ModifiedBy
        {
            get;
            set;
        }

        public DateTime CreatedOn
        {
            get;
            set;
        } = DateTime.Now;


        public DateTime ModifiedOn
        {
            get;
            set;
        } = DateTime.Now;


        public bool IsActive
        {
            get;
            set;
        } = true;


        public byte[] RowVersion
        {
            get;
            set;
        }

        public bool IsTransient()
        {
            return Id == Guid.Empty;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj is not BaseEntity) return false;

            if (this == obj as BaseEntity) return true;

            if (GetType() != obj.GetType()) return false;

            BaseEntity baseEntity = (BaseEntity)obj;

            if (baseEntity.IsTransient() || IsTransient())  return false;

            return baseEntity.Id == Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue) _requestedHashCode = Id.GetHashCode() ^ 0x1F;

                return _requestedHashCode.Value;
            }

            return base.GetHashCode();
        }

        public static bool operator == (BaseEntity left, BaseEntity right)
        {
            if (Equals(left, null))  return Equals(right, null);

            return left.Equals(right);
        }

        public static bool operator !=(BaseEntity left, BaseEntity right) => !(left == right);
        
    }
}
