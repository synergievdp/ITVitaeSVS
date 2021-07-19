using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Services {
    public class TopicService : GenericService<Topic>, ITopicService {

        public TopicService(IGenericRepository<Topic> repo) : base(repo) {

        }
        public IEnumerable<Topic> GetByCertificate(Certificate certificate) {
            return repo.GetAll(topic => topic.Certificate.Id == certificate.Id);
        }

        public IEnumerable<Topic> GetByLevel(Level level) {
            return repo.GetAll(topic => topic.Level.Id == level.Id);
        }

        public IEnumerable<Topic> GetByNameCode(string nameCode) {
            return repo.GetAll(topic => topic.Name.Contains(nameCode)
                || topic.Code.Contains(nameCode));
        }

        public IEnumerable<Topic> GetByTag(Tag tag) {
            return repo.GetAll(topic => topic.Tags.Any(t => t.Id == tag.Id));
        }
    }
}
