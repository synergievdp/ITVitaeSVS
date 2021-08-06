using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITVitaeSVS.Core.Application.Services {
    public class StudentService : GenericService<Student>, IStudentService {
        private readonly ITopicService topics;
        private readonly ISubjectService subjects;

        public StudentService(IStudentRepository repo,
            ITopicService topics,
            ISubjectService subjects) : base(repo) {
            this.topics = topics;
            this.subjects = subjects;
        }
        public Student GetByName(string name) {
            return repo.Get(student => student.Name.Contains(name));
        }

        public IEnumerable<Student> GetAllByName(string name) {
            return repo.GetAll(student => student.Name.Contains(name));
        }

        public override Student GetById(int id)
        {
            return repo.Get(s => s.Id == id);
        }

        public override IEnumerable<Student> GetAll(int? skip = null, int? take = null)
        {
            return repo.GetAll(null, skip, take);
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

        public void SetSubjects(int id, IEnumerable<int> subjectIds)
{
            if(subjectIds.Count() == 0)
            {
                SetTopics(id, null);
            }
            foreach (var subjectId in subjectIds)
            {
                var subject = subjects.GetById(subjectId);
                SetTopics(id, subject.Topics.Select(t => t.Id));
            }
        }
    }
}
