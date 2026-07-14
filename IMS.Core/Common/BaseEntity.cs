using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset? UpdatedAt { get; private set; }

        protected BaseEntity()
        {
            CreatedAt = DateTimeOffset.UtcNow;
        }

        protected void MarkAsUpdated()
        {
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
