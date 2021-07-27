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
        public Curriculum Curriculum { get; set; } = new();

        public void AddTopic(Topic topic) {
            Curriculum.AddTopic(topic);
        }

        public void RemoveTopic(Topic topic) {
            Curriculum.RemoveTopic(topic);
        }

        public IEnumerable<Topic> GetTopics() {
            return Curriculum.GetTopics();
        }

        public Progress? GetProgress(Topic topic)
        {
            return Curriculum.GetProgress(topic);
        }
    }
}
