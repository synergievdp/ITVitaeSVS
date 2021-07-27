using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Domain.Entities {
    public class Curriculum : BaseEntity {
        private readonly List<CurriculumTopic> topics = new();
        public IReadOnlyCollection<CurriculumTopic> Topics => topics.AsReadOnly();

        public void AddTopic(Topic topic) {
            if (!HasTopic(topic) && topic != null) {
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

        public bool HasTopic(Topic topic)
        {
            return topics.Any(ct => ct.Topic == topic);
        }

        public IEnumerable<Topic> GetTopics()
        {
            return Topics.Select(ct => ct.Topic);
        }
        public Progress? GetProgress(Topic topic)
        {
            return Topics.FirstOrDefault(ct => ct.Topic == topic)?.Progress;
        }
    }
}
