using ITVitaeSVS.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVitaeSVS.Infrastructure.Data
{
    public class DataDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Requisite> Requisites { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<WorkMethod> WorkMethods { get; set; }
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Curriculum)
                .WithOne(c => c.Student)
                .HasForeignKey<Curriculum>(c => c.Id);

            modelBuilder.Entity<CurriculumTopic>()
                .HasKey(ct => new { ct.CurriculumId, ct.TopicId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
