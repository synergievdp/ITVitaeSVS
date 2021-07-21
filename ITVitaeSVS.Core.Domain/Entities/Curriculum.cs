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

        public void AddTopic(Topic topic) {
            if (!Topics.Any(ct => ct.Topic == topic)) {
                var ct = new CurriculumTopic() {
                    Curriculum = this,
                    Topic = topic
                };
                topics.Add(ct);
            }
        }

        public void RemoveTopic(Topic topic) {
            var ct = Topics.FirstOrDefault(ct => ct.Topic == topic);
            if(ct != null) {
                topics.Remove(ct);
            }
        }
    }
}
