using ManagementStudentWithNHibernate.Models;
using System.Collections.Generic;

namespace ManagementStudentWithNHibernate.IRepositories
{
    public interface IEnrollmentRepository
    {
        public List<Student> SearchStudent(string searchString);
        public List<Course> GetCoursesByStudentId(int studentId);
        public List<Student> GetStudentsByCourseId(int courseId);
        public Enrollment GetEnrollmentByStudentIdAndCourseId(int studentId, int courseId);
        public void UpdateEnrollment(Enrollment enrollment);
        public List<Enrollment> GetEnrollmentsByStudentId(int id);
        public void AddStudentToCourse(int studentId, int courseId);
        public void RemoveStudentFromCourse(Enrollment enrollment);
    }
}