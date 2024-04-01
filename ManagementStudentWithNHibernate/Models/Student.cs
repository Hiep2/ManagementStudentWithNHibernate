using System;

namespace ManagementStudentWithNHibernate.Models
{
    public class Student
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Sex { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string ClassName { get; set; }
        public virtual int StudyYear { get; set; }
    }
}

