using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataDbContext context;
        protected readonly DbSet<T> table;

        public GenericRepository(DataDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public virtual void Delete(int id)
        {
            var entity = table.Find(id);
            if (entity != null)
                table.Remove(entity);
        }

        public virtual T Get(Expression<Func<T, bool>> filter = null, string[] includeProperties = null)
        {
            return GetQueryable(filter, includeProperties: includeProperties).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string[] includeProperties = null, int? skip = null, int? take = null)
        {
            return GetQueryable(filter, includeProperties: includeProperties).ToList();
        }

        public virtual T Insert(T obj)
        {
            if (obj != null)
            {
                context.Add(obj);
                context.SaveChanges();
            }
            return obj;
        }

        public virtual void Update(T obj)
        {
            if (obj != null)
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public int Count()
        {
            return table.Count();
        }

        protected virtual IQueryable<T> GetQueryable(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string[] includeProperties = null,
        int? skip = null,
        int? take = null)
        {
            IQueryable<T> query = context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if(includeProperties != null)
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }
    }
}
