using Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public abstract class BaseCreatedLastModifiedDeletedEntity : ICreatedLastModifiedDeleted
    {
        public DateTime CreatedAt { get; set; }
        public bool IsBuildIn { get; set; }
        public Guid Id { get; set; }
        public bool? IsModified { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
