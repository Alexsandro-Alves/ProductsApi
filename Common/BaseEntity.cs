using System;

namespace ProductsApi.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? OriginTimestampUtc { get; set; }


        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public void SetCreatedProperties(DateTime dateTimeNow, string currentUser)
        {
            CreatedBy = currentUser;
            CreatedAt = dateTimeNow;
        }

        public void SetLastModifiedProperties(DateTime dateTimeNow, string currentUser)
        {
            LastModifiedBy = currentUser;
            LastModifiedAt = dateTimeNow;
        }
    }

    
}