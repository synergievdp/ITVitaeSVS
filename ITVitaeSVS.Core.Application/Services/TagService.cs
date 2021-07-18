using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Services {
    public class TagService : GenericService<Tag>, ITagService {
        public TagService(IGenericRepository<Tag> repo) : base(repo) {

        }
        public IEnumerable<Tag> GetAllByName(string name) {
            return repo.GetAll(tag => tag.Name.Contains(name));
        }

        public Tag GetByName(string name) {
            return repo.Get(tag => tag.Name.Contains(name));
        }

        public override Tag Add(Tag obj) {
            if (GetByName(obj.Name) == null)
                return base.Add(obj);
            else
                return null;
        }

        public override void Update(Tag obj) {
            if(GetByName(obj.Name) == null)
                base.Update(obj);
        }
    }
}
