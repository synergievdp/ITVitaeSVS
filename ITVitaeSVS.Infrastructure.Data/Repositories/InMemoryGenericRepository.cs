using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure.Data.Repositories {
    public class InMemoryGenericRepository<T> : IGenericRepository<T> where T : BaseEntity {
        public List<T> list { get; set; } = new();
        public void Delete(int id) {
            T entity = Get(e => e.Id == id);
            list.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter = null, string[] includeProperties = null) {
            return list.FirstOrDefault(filter.Compile());
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string[] includeProperties = null) {
            return list.Where(filter.Compile());
        }

        public T Insert(T obj) {
            list.Add(obj);
            obj.Id = list.Count;
            return obj;
        }

        public void Update(T obj) {
            T entity = list.FirstOrDefault(e => e.Id == obj.Id);
            if (entity != null) {
                entity.IsDeleted = obj.IsDeleted;
            }
        }
    }
}
