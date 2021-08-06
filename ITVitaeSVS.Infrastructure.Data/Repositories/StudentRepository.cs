using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ITVitaeSVS.Infrastructure.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(DataDbContext context) : base(context)
        {
        }

        public override IEnumerable<Student> GetAll(Expression<Func<Student, bool>> filter = null, int? skip = null, int? take = null)
{
            return GetQueryable(filter, null, skip, take);
        }

        public override Student Get(Expression<Func<Student, bool>> filter = null)
        {
            return GetQueryable(filter).FirstOrDefault();
        }

        protected override IQueryable<Student> GetQueryable(Expression<Func<Student, bool>> filter = null, Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null, int? skip = null, int? take = null)
        {
            return base.GetQueryable(filter, orderBy, skip, take)
                .Include(s => s.Topics)
                .ThenInclude(ct => ct.Topic)
                .ThenInclude(t => t.Subject); ;
        }
    }
}
