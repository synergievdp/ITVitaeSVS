using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Domain.Entities {
    public class Curriculum : BaseEntity {
        public Student Student { get; set; }
        private readonly List<CurriculumTopic> topics = new();
        public IReadOnlyCollection<CurriculumTopic> Topics => topics.AsReadOnly();
    }
}
