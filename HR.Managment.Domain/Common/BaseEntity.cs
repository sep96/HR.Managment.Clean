using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Domain.Common
{
    public class BaseEntity
    {
        public string CreateionUserID { get; set; } = string.Empty;
        public DateTime CreationDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; } = null;
    }
}
