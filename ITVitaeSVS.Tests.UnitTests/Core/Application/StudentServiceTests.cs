using ITVitaeSVS.Core.Application.Services;
using ITVitaeSVS.Core.Domain.Entities;
using ITVitaeSVS.Infrastructure.Data;
using ITVitaeSVS.Infrastructure.Data.Repositories;
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
    public class StudentServiceTests : GenericServiceTests<Student>
    {
        private readonly TopicService topics;

        public StudentServiceTests(ITestOutputHelper output) : base(output)
        {
            
            repository = new InMemoryGenericRepository<Student>();
            topics = new TopicService(new InMemoryGenericRepository<Topic>());

            sut = new StudentService(repository, topics);
        }
        [Fact]
        public void SetTopics_DoesNothing_WhenStudentDoesntExists()
        {
            var sut = this.sut as StudentService;

            sut.SetTopics(1, new List<int>() { 1 });

            Assert.Null(sut.GetById(1));
        }

        [Fact]
        public void SetTopics_DoesNothing_WhenTopicDoesntExists()
        {
            var sut = this.sut as StudentService;
            var student = new Student();
            sut.Add(student);

            sut.SetTopics(student.Id, new List<int>() { 1 });

            Assert.Empty(student.GetTopics());
        }

        [Fact]
        public void SetTopics_SetsTopics_WhenEmpty()
        {
            var sut = this.sut as StudentService;
            var student = new Student();
            sut.Add(student);

            var topic = new Topic();
            topics.Add(topic);

            sut.SetTopics(student.Id, new List<int>() { topic.Id });

            var topicList = student.GetTopics();
            Assert.True(topicList.Count() == 1);
            Assert.Contains(topic, topicList);
        }
        [Fact]
        public void SetTopics_RemovesTopics_WhenSet()
        {
            var sut = this.sut as StudentService;
            var student = new Student();
            sut.Add(student);
            var topic = new Topic();
            topics.Add(topic);

            sut.SetTopics(student.Id, new List<int>() { topic.Id });
            sut.SetTopics(student.Id, new List<int>() { });

            Assert.Empty(student.GetTopics());
        }
        [Fact]
        public void SetTopics_RemovesTopics_WhenSetNull()
        {
            var sut = this.sut as StudentService;
            var student = new Student();
            sut.Add(student);
            var topic = new Topic();
            topics.Add(topic);

            sut.SetTopics(student.Id, new List<int>() { topic.Id });
            sut.SetTopics(student.Id, null);

            Assert.Empty(student.GetTopics());
        }
        [Fact]
        public void SetTopics_LeavesTopics_WhenSet()
        {
            var sut = this.sut as StudentService;
            var student = new Student();
            sut.Add(student);
            var topic1 = new Topic();
            topics.Add(topic1);
            var topic2 = new Topic();
            topics.Add(topic2);

            sut.SetTopics(student.Id, new List<int>() { topic1.Id });
            sut.SetTopics(student.Id, new List<int>() { topic1.Id, topic2.Id });

            var topicList = student.GetTopics();
            Assert.True(topicList.Count() == 2);
            Assert.Contains(topic1, topicList);
            Assert.Contains(topic2, topicList);
        }
    }
}
