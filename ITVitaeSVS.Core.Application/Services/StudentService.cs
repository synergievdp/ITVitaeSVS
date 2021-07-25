using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Services {
    public class StudentService : GenericService<Student>, IStudentService {
        private readonly ITopicService topics;

        public StudentService(IGenericRepository<Student> repo,
            ITopicService topics) : base(repo) {
            this.topics = topics;
        }
        public Student GetByName(string name) {
            return repo.Get(student => student.Name.Contains(name));
        }

        public IEnumerable<Student> GetAllByName(string name) {
            return repo.GetAll(student => student.Name.Contains(name));
        }

        public void SetTopics(int id, IEnumerable<int> topicIds) {
            var student = GetById(id);
            if(student != null) {
                foreach (var topic in student.GetTopics().ToList()) {
                    if(topicIds is null || !topicIds.Contains(topic.Id)) {
                        student.RemoveTopic(topic);
                    }
                }

                if(topicIds is not null)
                    foreach (var topicId in topicIds) {
                        var topic = topics.GetById(topicId);
                        student.AddTopic(topic);
                    }
            }
            Update(student);
        }
    }
}
