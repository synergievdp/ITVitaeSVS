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
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(DataDbContext context) : base(context)
        {

        }

        protected override IQueryable<Subject> GetQueryable(Expression<Func<Subject, bool>> filter = null, Func<IQueryable<Subject>, IOrderedQueryable<Subject>> orderBy = null, int? skip = null, int? take = null)
        {
            return base.GetQueryable(filter, orderBy, skip, take)
                .Include(s => s.Topics);
        }
    }
}
