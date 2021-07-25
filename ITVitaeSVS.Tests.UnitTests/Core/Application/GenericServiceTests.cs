using ITVitaeSVS.Core.Application.Interfaces.Repositories;
using ITVitaeSVS.Core.Application.Interfaces.Services;
using ITVitaeSVS.Core.Domain.Entities;
using ITVitaeSVS.Infrastructure.Data;
using ITVitaeSVS.Tests.UnitTests.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ITVitaeSVS.Tests.UnitTests.Core.Application
{
    public abstract class GenericServiceTests<T> where T : BaseEntity, new()
    {
        protected readonly ITestOutputHelper output;

        public virtual IGenericService<T> sut { get; set; }
        public virtual IGenericRepository<T> repository { get; set; }

        public GenericServiceTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void Add_Adds_WhenEmpty()
        {
            var entity = new T();
            sut.Add(entity);

            Assert.True(entity.Id == 1);
            Assert.Contains(entity, sut.GetAll());
        }
        [Fact]
        public void Add_DoesNothing_WhenNull()
        {
            sut.Add(null);

            Assert.Empty(sut.GetAll());
        }

        [Fact]
        public void Remove_SetsDeleted_WhenExists()
        {
            var entity = new T();
            sut.Add(entity);
            sut.Remove(entity);

            Assert.True(entity.IsDeleted);
            Assert.True(sut.GetById(entity.Id).IsDeleted);

            Assert.Contains(entity, repository.GetAll());
            Assert.DoesNotContain(entity, sut.GetAll());
        }
        [Fact]
        public void Remove_DoesNothing_WhenNotExists()
        {
            var entity = new T();
            sut.Remove(entity);

            Assert.DoesNotContain(entity, repository.GetAll());
            Assert.DoesNotContain(entity, sut.GetAll());
        }
    }
}
