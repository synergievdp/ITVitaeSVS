using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Services {
    public class RequisiteService : GenericService<Requisite>, IRequisiteService {

        public RequisiteService(IGenericRepository<Requisite> repo) : base(repo) {

        }
        public IEnumerable<Requisite> GetAllByName(string name) {
            return repo.GetAll(requisite => requisite.Name.Contains(name));
        }

        public Requisite GetByName(string name) {
            return repo.Get(requisite => requisite.Name.Contains(name));
        }

        public override Requisite Add(Requisite obj) {
            if (GetByName(obj.Name) == null)
                return base.Add(obj);
            else
                return null;
        }

        public override void Update(Requisite obj) {
            if(GetByName(obj.Name) == null)
                base.Update(obj);
        }
    }
}
