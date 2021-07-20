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
        public IEnumerable<Topic> GetAllByCertificate(Certificate certificate) {
            return repo.GetAll(topic => topic.Certificate.Id == certificate.Id);
        }

        public IEnumerable<Topic> GetAllByLevel(Level level) {
            return repo.GetAll(topic => topic.Level.Id == level.Id);
        }

        public IEnumerable<Topic> GetAllByNameCode(string nameCode) {
            return repo.GetAll(topic => topic.Name.Contains(nameCode)
                || topic.Code.Contains(nameCode));
        }

        public IEnumerable<Topic> GetAllByTag(Tag tag) {
            return repo.GetAll(topic => topic.Tags.Any(t => t.Id == tag.Id));
        }

        public Topic GetByNameCode(string nameCode) {
            return repo.Get(topic => topic.Name.Contains(nameCode)
                || topic.Code.Contains(nameCode));
        }
    }
}
