using EDU.Domain.Entities;
using System;

namespace EDU.Domain.ValueObjects
{
    public class ExamResults
    {
        public int Id { get; set; }
        public Exam Exam { get; set; }
        public User Student { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
    }
}
