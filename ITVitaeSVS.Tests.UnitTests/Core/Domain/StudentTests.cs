using ITVitaeSVS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ITVitaeSVS.Tests.UnitTests.Core.Domain
{
    public class StudentTests
    {
        private readonly ITestOutputHelper output;
        private readonly Student sut;

        public StudentTests(ITestOutputHelper output)
        {
            this.output = output;
            sut = new();
        }

        [Fact]
        public void GetTopics_ReturnsList_WhenEmpty()
        {

            Assert.Empty(sut.GetTopics());
        }

        [Fact]
        public void GetTopics_ReturnsList_WhenAdded()
        {
            Topic topic = new();

            sut.AddTopic(topic);

            Assert.Contains<Topic>(topic, sut.GetTopics());
        }

        [Fact]
        public void GetProgress_ReturnsNull_WhenEmpty()
        {
            Topic topic = new();
            
            Assert.Null(sut.GetProgress(topic));
        }

        [Fact]
        public void GetProgress_ReturnsProgress_WhenAdded()
        {
            Topic topic = new();

            sut.AddTopic(topic);

            Assert.True(Progress.ToDo == sut.GetProgress(topic));
        }
    }
}
