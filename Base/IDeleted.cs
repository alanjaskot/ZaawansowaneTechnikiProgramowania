using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public interface IDeleted
    {
#nullable enable
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
#nullable disable
    }
}
