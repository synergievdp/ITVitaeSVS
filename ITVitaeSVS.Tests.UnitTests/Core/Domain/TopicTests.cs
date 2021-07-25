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
    public class TopicTests
    {
        private readonly ITestOutputHelper output;
        private readonly Topic sut;

        public TopicTests(ITestOutputHelper output)
        {
            this.output = output;
            sut = new();
        }

        [Fact]
        public void AddTag_AddsTag_WhenEmpty()
        {
            Tag tag = new();

            sut.AddTag(tag);

            Assert.Contains<Tag>(tag, sut.Tags);
        }

        [Fact]
        public void AddTag_AddsTag_WhenNotEmpty()
        {
            Tag tag1 = new();
            sut.AddTag(tag1);

            Tag tag2 = new();
            sut.AddTag(tag2);

            Assert.Contains<Tag>(tag1, sut.Tags);
            Assert.Contains<Tag>(tag2, sut.Tags);
        }
        [Fact]
        public void AddTag_DoesNothing_WhenNull()
        {

            sut.AddTag(null);

            Assert.Empty(sut.Tags);
        }

        [Fact]
        public void AddPrerequisite_AddsPrerequisite_WhenEmpty()
        {
            Topic prerequisite = new();

            sut.AddPrerequisite(prerequisite);

            Assert.Contains<Topic>(prerequisite, sut.Prerequisites);
        }
        [Fact]
        public void AddPrerequisite_AddsPrerequisite_WhenNotEmpty()
        {
            Topic prerequisite1 = new();
            sut.AddPrerequisite(prerequisite1);

            Topic prerequisite2 = new();
            sut.AddPrerequisite(prerequisite2);

            Assert.Contains<Topic>(prerequisite1, sut.Prerequisites);
            Assert.Contains<Topic>(prerequisite2, sut.Prerequisites);
        }
        [Fact]
        public void AddPrerequisite_DoesNothing_WhenNull()
        {

            sut.AddPrerequisite(null);

            Assert.Empty(sut.Prerequisites);
        }
        [Fact]
        public void AddLink_AddsLink_WhenEmpty()
        {
            Link link = new();

            sut.AddLink(link);

            Assert.Contains<Link>(link, sut.Links);

        }
        [Fact]
        public void AddLink_AddsLink_WhenNotEmpty()
        {
            Link link1 = new();
            sut.AddLink(link1);

            Link link2 = new();
            sut.AddLink(link2);

            Assert.Contains<Link>(link1, sut.Links);
            Assert.Contains<Link>(link2, sut.Links);

        }
        [Fact]
        public void AddLink_DoesLink_WhenNull()
        {

            sut.AddLink(null);

            Assert.Empty(sut.Links);
        }
        [Fact]
        public void AddRequisite_AddsRequisite_WhenEmpty()
        {
            Requisite requisite = new();

            sut.AddRequisite(requisite);

            Assert.Contains<Requisite>(requisite, sut.Requisites);

        }
        [Fact]
        public void AddRequisite_AddsRequisite_WhenNotEmpty()
        {
            Requisite requisite1 = new();
            sut.AddRequisite(requisite1);

            Requisite requisite2 = new();
            sut.AddRequisite(requisite2);

            Assert.Contains<Requisite>(requisite1, sut.Requisites);
            Assert.Contains<Requisite>(requisite2, sut.Requisites);

        }
        [Fact]
        public void AddRequisite_DoesNothing_WhenNull()
        {

            sut.AddRequisite(null);

            Assert.Empty(sut.Requisites);
        }
    }
}
