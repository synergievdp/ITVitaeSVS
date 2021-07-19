using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Domain.Entities {
    public class Topic : BaseEntity {
        public string Code { get; set; }
        private string name;
        public string Name { 
            get { return String.IsNullOrWhiteSpace(name) ? Code : name; } 
            set { name = value; } 
        }
        public string Objective { get; set; }
        public TimeSpan Duration { get; set; }
        public WorkMethod WorkMethod { get; set; }
        public Level Level { get; set; }
        public Certificate Certificate { get; set; }
        private readonly List<Topic> prerequisites = new();
        public IReadOnlyCollection<Topic> Prerequisites => prerequisites.AsReadOnly();
        private readonly List<Tag> tags = new();
        public IReadOnlyCollection<Tag> Tags => tags.AsReadOnly();
        private readonly List<Link> links = new();
        public IReadOnlyCollection<Link> Links => links.AsReadOnly();
        private readonly List<Requisite> requisites = new();
        public IReadOnlyCollection<Requisite> Requisites => requisites.AsReadOnly();
    }
}
