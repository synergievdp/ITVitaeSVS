using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Services {
    public class GenericService<T> : IGenericService<T> where T : BaseEntity {
        protected readonly IGenericRepository<T> repo;

        public GenericService(IGenericRepository<T> repo) {
            this.repo = repo;
        }
        public virtual T Add(T obj) {
            if (obj != null)
            {
                return repo.Insert(obj);
            }
            return null;
        }

        public virtual IEnumerable<T> GetAll(int? skip = null, int? take = null) {
            return repo.GetAll(obj => obj.IsDeleted == false, skip: skip, take: take);
        }

        public virtual T GetById(int id) {
            return repo.Get(obj => obj.Id == id);
        }

        public virtual void Remove(T obj) {
            if (obj != null)
            {
                obj.IsDeleted = true;
                Update(obj);
            }
        }

        public virtual void Update(T obj) {
            if (obj != null)
            {
                repo.Update(obj);
            }
        }

        public virtual int Count()
        {
            return repo.Count();
        }
    }
}
