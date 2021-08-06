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
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        public TopicRepository(DataDbContext context) : base(context)
        {
        }

        public override Topic Get(Expression<Func<Topic, bool>> filter = null)
        {
            return GetQueryable(filter)
                .Include(t => t.Level)
                .Include(t => t.Links)
                .Include(t => t.Requisites)
                .Include(t => t.WorkMethod)
                .Include(t => t.Prerequisites)
                .Include(t => t.Tags)
                .Include(t => t.Certificate)
                .Include(t => t.Files)
                .Include(t => t.Subject)
                .FirstOrDefault();
        }

        public override IEnumerable<Topic> GetAll(Expression<Func<Topic, bool>> filter = null, int? skip = null, int? take = null)
        {
            return GetQueryable(filter, null, skip, take)
                .Include(t => t.Level)
                .Include(t => t.Links)
                .Include(t => t.Requisites)
                .Include(t => t.WorkMethod)
                .Include(t => t.Prerequisites)
                .Include(t => t.Tags)
                .Include(t => t.Certificate)
                .Include(t => t.Files)
                .Include(t => t.Subject);
        }
    }
}
