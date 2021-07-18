using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Interfaces.Services {
    public interface ITagService : IGenericService<Tag> {
        public Tag GetByName(string name);
        public IEnumerable<Tag> GetAllByName(string name);
    }
}
