using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2.Models
{
    public interface IAuditable
    {        
        string CreatedBy { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        string UpdatedBy { get; set; }
        DateTimeOffset UpdatedDate { get; set; }
    }
}
