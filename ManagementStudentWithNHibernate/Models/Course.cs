namespace ManagementStudentWithNHibernate.Models
{
	public class Course
	{
		public virtual int Id { get; set; }
		public virtual string CourseName { get; set; }
		public virtual int CourseUnit { get; set; }

		public virtual int EnrollmentCount { get; set;}
	}
}
