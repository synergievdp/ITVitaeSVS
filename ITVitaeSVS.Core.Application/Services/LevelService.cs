using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Services {
    public class LevelService : GenericService<Level>, ILevelService {

        public LevelService(IGenericRepository<Level> repo) : base(repo) {

        }
        public Level GetByName(string name) {
            return repo.Get(level => level.Name.Contains(name));
        }

        public override Level Add(Level obj) {
            if (GetByName(obj.Name) == null)
                return base.Add(obj);
            else
                return null;
        }

        public override void Update(Level obj) {
            if(GetById(obj.Id) != null && GetByName(obj.Name) == null)
                base.Update(obj);
        }
    }
}
