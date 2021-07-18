using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Interfaces.Services {
    public interface IRequisiteService : IGenericService<Requisite> {
        public Requisite GetByName(string name);
        public IEnumerable<Requisite> GetAllByName(string name);
    }
}
