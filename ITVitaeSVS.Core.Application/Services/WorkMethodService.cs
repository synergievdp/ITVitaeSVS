using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Services {
    public class WorkMethodService : GenericService<WorkMethod>, IWorkMethodService {
        public WorkMethodService(IGenericRepository<WorkMethod> repo) : base(repo) {

        }
        
        public IEnumerable<WorkMethod> GetAllByName(string name) {
            return repo.GetAll(workMethod => workMethod.Name.Contains(name));
        }

        public WorkMethod GetByName(string name) {
            return repo.Get(workMethod => workMethod.Name.Contains(name));
        }
    }
}
