using System;

namespace ITVitaeSVS.Core.Domain.Entities {
    public class CurriculumTopic {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public Progress Progress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Approved { get; set; }
    }
}