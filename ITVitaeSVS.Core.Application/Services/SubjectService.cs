using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Services
{
    public class SubjectService : GenericService<Subject>, ISubjectService
    {
        private readonly ITopicService topics;

        public SubjectService(ISubjectRepository repo, ITopicService topics) : base(repo)
        {
            this.topics = topics;
        }

        public void SetTopics(int id, IEnumerable<int> topicIds)
        {
            var subject = GetById(id);
            if (subject != null)
            {
                foreach (var topic in subject.Topics)
                {
                    if (topicIds is null || !topicIds.Contains(topic.Id))
                    {
                        subject.RemoveTopic(topic);
                    }
                }

                if (topicIds is not null)
                    foreach (var topicId in topicIds)
                    {
                        var topic = topics.GetById(topicId);
                        if(!subject.Topics.Contains(topic))
                            subject.AddTopic(topic);
                    }
            }
            Update(subject);
        }
    }
}
