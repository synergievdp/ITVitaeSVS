using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Interfaces.Services {
    public interface ITopicService : IGenericService<Topic> {
        public Topic GetByNameCode(string nameCode);
        public IEnumerable<Topic> GetAllByNameCode(string nameCode);
        public IEnumerable<Topic> GetAllByTag(Tag tag);
        public IEnumerable<Topic> GetAllByLevel(Level level);
        public IEnumerable<Topic> GetAllByCertificate(Certificate certificate);
    }
}
