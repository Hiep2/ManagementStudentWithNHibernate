using ManagementStudentWithNHibernate.IRepositories;
using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.Models;
using ManagementStudentWithNHibernate.Pages.Enrollments;
using System.Collections.Generic;

namespace ManagementStudentWithNHibernate.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmenrRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmenrRepository = enrollmentRepository;
        }

        public List<Student> SearchStudent(string searchString)
        {
            return _enrollmenrRepository.SearchStudent(searchString);
        }

        public List<Course> GetCoursesByStudentId(int studentId)
        {
            return _enrollmenrRepository.GetCoursesByStudentId(studentId);
        }

        public List<Student> GetStudentsByCourseId(int courseId)
        {
            return _enrollmenrRepository.GetStudentsByCourseId(courseId);
        }

        public Enrollment GetEnrollmentByStudentIdAndCourseId(int studentId, int courseId)
        {
            return _enrollmenrRepository.GetEnrollmentByStudentIdAndCourseId(studentId, courseId);
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            _enrollmenrRepository.UpdateEnrollment(enrollment);
        }

        public List<Enrollment> GetEnrollmentsByStudentId(int id)
        {
            return _enrollmenrRepository.GetEnrollmentsByStudentId(id);
        }

        public void AddStudentToCourse(int studentId, int courseId)
        {
            _enrollmenrRepository.AddStudentToCourse(studentId, courseId);
        }

        public void RemoveStudentFromCourse(Enrollment enrollment)
        {
            _enrollmenrRepository.RemoveStudentFromCourse(enrollment);
        }
    }
}
