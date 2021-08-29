using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Common
{
    public class Base
    {
        // For Audit purpose, every record which updates the database should have details about who did it and when
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } //Kept nullable as there is no login functionality
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
