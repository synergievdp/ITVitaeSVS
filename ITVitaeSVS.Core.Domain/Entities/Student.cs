using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Domain.Entities {
    public class Student : BaseEntity {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrolledDate { get; set; }
        public Curriculum Curriculum { get; set; }
    }
}
