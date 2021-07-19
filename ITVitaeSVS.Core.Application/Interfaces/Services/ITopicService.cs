using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Interfaces.Services {
    public interface ITopicService : IGenericService<Topic> {
        public IEnumerable<Topic> GetByNameCode(string nameCode);
        public IEnumerable<Topic> GetByTag(Tag tag);
        public IEnumerable<Topic> GetByLevel(Level level);
        public IEnumerable<Topic> GetByCertificate(Certificate certificate);
    }
}
