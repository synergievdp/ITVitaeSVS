using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Domain.Entities {
    public class Student : BaseEntity {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => String.Join(" ", FirstName, LastName);
        public DateTime EnrolledDate { get; set; } = DateTime.Today;
        private readonly List<CurriculumTopic> topics = new();
        public IReadOnlyCollection<CurriculumTopic> Topics => topics.AsReadOnly();

        public void AddTopic(Topic topic) {
            topics.Add(new CurriculumTopic() { Student = this, Topic = topic });
        }

        public void RemoveTopic(Topic topic) {
            topics.Remove(Topics.FirstOrDefault(ct => ct.TopicId == topic.Id));
        }

        public IEnumerable<Topic> GetTopics() {
            return Topics.Select(ct => ct.Topic);
        }

        public IEnumerable<Subject> GetSubjects() {
            return Topics.Select(ct => ct.Topic.Subject).Distinct();
        }

        public IEnumerable<CurriculumTopic> GetCurriculumTopics(Subject subject)
        {
            return Topics.Where(ct => ct.Topic.Subject == subject);
        }

        public Progress? GetProgress(Topic topic)
        {
            return Topics.FirstOrDefault(ct => ct.TopicId == topic.Id).Progress;
        }
    }
}
