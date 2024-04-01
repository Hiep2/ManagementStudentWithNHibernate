using ManagementStudentWithNHibernate.IRepositories;
using System.Collections.Generic;
using ManagementStudentWithNHibernate.Models;
using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.DTO;

namespace ManagementStudentWithNHibernate.Services
{
	public class CourseService : ICourseService
	{
		private readonly ICourseRepository _courseRepository;

		public CourseService(ICourseRepository courseRepository)
		{
			_courseRepository = courseRepository;
		}

		public List<CourseEnrollmentDTO> GetCourses()
		{
			return _courseRepository.GetCourses();
		}

		public Course GetCourse(int id)
		{
			return _courseRepository.GetCourse(id);
		}

		public void CreateCourse(Course course)
		{
			_courseRepository.CreateCourse(course);
		}

		public void UpdateCourse(Course course)
		{
			_courseRepository.UpdateCourse(course);
		}

		public void DeleteCourse(Course course)
		{
			_courseRepository.DeleteCourse(course);
		}
	}
}
