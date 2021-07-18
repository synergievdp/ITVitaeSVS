using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Core.Application.Interfaces.Repositories {
    public interface IGenericRepository<T> where T : BaseEntity {
        public T Insert(T obj);
        public void Update(T obj);
        public void Delete(int id);
        public T Get(Expression<Func<T, bool>> filter = null, string[] includeProperties = null);
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string[] includeProperties = null);
    }
}
