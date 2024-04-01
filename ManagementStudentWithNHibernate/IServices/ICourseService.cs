using System.Collections.Generic;
using ManagementStudentWithNHibernate.DTO;
using ManagementStudentWithNHibernate.Models;

namespace ManagementStudentWithNHibernate.IServices
{
	public interface ICourseService
	{
		List<CourseEnrollmentDTO> GetCourses();
		Course GetCourse(int id);
		void CreateCourse(Course course);
		void UpdateCourse(Course course);
		void DeleteCourse(Course course);
	}
}
