using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Interfaces.Services {
    public interface IGenericService<T> where T : BaseEntity {
        public T Add(T obj);
        public void Update(T obj);
        public void Remove(T obj);
        public T GetById(int id);
        public IEnumerable<T> GetAll();
    }
}
