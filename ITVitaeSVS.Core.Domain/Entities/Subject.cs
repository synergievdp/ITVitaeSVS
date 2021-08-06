using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        private readonly List<Topic> topics = new();
        public IReadOnlyCollection<Topic> Topics => topics.AsReadOnly();

        public void RemoveTopic(Topic topic)
        {
            if(topics.Contains(topic))
            {
                topics.Remove(topic);
            }
        }

        public void AddTopic(Topic topic)
        {
            if(!topics.Contains(topic))
            {
                topics.Add(topic);
            }
        }
    }
}
