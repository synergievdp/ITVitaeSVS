using ITVitaeSVS.Core.Domain.Entities;
using System;
using Xunit;
using Xunit.Abstractions;

namespace ITVitaeSVS.Tests.UnitTests.Core.Domain
{
    public class CurriculumTests
    {
        private readonly ITestOutputHelper output;
        private readonly Curriculum sut;

        public CurriculumTests(ITestOutputHelper output)
        {
            this.output = output;
            sut = new();
        }

        [Fact]
        public void AddTopic_AddsTopic_WhenEmpty()
        {
            Topic topic = new();

            sut.AddTopic(topic);

            Assert.True(sut.HasTopic(topic));
        }

        [Fact]
        public void AddTopic_AddsTopic_WhenNotEmpty()
        {
            Topic topic1 = new();
            sut.AddTopic(topic1);

            Topic topic2 = new();
            sut.AddTopic(topic2);

            Assert.True(sut.HasTopic(topic1));
            Assert.True(sut.HasTopic(topic2));
        }

        [Fact]
        public void AddTopic_DoesNothing_WhenNullAndEmpty()
        {

            sut.AddTopic(null);

            Assert.Empty(sut.Topics);
        }

        [Fact]
        public void AddTopic_DoesNothing_WhenNull()
        {
            Topic topic = new();

            sut.AddTopic(topic);
            sut.AddTopic(null);

            Assert.True(sut.Topics.Count == 1);
            Assert.True(sut.HasTopic(topic));
        }

        [Fact]
        public void RemoveTopic_DoesNothing_WhenEmpty()
        {
            Topic topic = new();

            sut.RemoveTopic(topic);

            Assert.Empty(sut.Topics);
        }

        [Fact]
        public void RemoveTopic_DoesNothing_WhenNull()
        {

            sut.RemoveTopic(null);

            Assert.Empty(sut.Topics);
        }

        [Fact]
        public void RemoveTopic_RemovesTopic_WhenEmpty()
        {
            Topic topic = new();
            sut.AddTopic(topic);

            sut.RemoveTopic(topic);

            Assert.Empty(sut.Topics);
        }

        [Fact]
        public void RemoveTopic_RemovesTopic_WhenNotEmpty()
        {
            Topic topic1 = new();
            sut.AddTopic(topic1);
            Topic topic2 = new();
            sut.AddTopic(topic2);

            sut.RemoveTopic(topic1);

            Assert.True(sut.Topics.Count == 1);
            Assert.True(sut.HasTopic(topic2));
        }
    }
}
