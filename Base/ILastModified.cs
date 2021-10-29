using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public interface ILastModified
    {
#nullable enable
        public bool? IsModified { get; set; }
        public DateTime? LastModifiedAt { get; set; }
#nullable disable
    }
}
