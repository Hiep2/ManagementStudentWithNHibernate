using ManagementStudentWithNHibernate.IRepositories;
using ManagementStudentWithNHibernate.Models;
using MySqlX.XDevAPI;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace ManagementStudentWithNHibernate.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ISession _session;

        public EnrollmentRepository(ISession session)
        {
            _session = session;
        }

        public List<Student> SearchStudent(string searchTerm)
        {
            return _session.Query<Student>()
            .Where(s => s.Id.ToString().Contains(searchTerm) || s.Name.Contains(searchTerm))
            .ToList();
        }

        public List<Course> GetCoursesByStudentId(int studentId)
        {
            var hqlQuery = @"select e.Course 
                            from ManagementStudentWithNHibernate.Models.Enrollment e 
                            where e.Student.Id = :studentId";

            List<Course> courses = (List<Course>)_session.CreateQuery(hqlQuery)
                                        .SetParameter("studentId", studentId)
                                        .List<Course>();

            return courses;
        }

        public List<Student> GetStudentsByCourseId(int courseId)
        {
            using (ITransaction transaction = _session.BeginTransaction()) 
            {
                var students = _session.Query<Enrollment>()
                                      .Where(e => e.Course.Id == courseId)
                                      .Select(e => e.Student)
                                      .Distinct()
                                      .ToList();
                return students;
            }
        }

        public Enrollment GetEnrollmentByStudentIdAndCourseId(int studentId, int courseId)
        {
            return _session.Query<Enrollment>()
            .Where(e => e.Student.Id == studentId && e.Course.Id == courseId)
            .FirstOrDefault();
        }

        public void UpdateEnrollment(Enrollment enrollment)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var enrollmentToUpdate = _session.Get<Enrollment>(enrollment.Id);

                if (enrollmentToUpdate != null)
                {
                    enrollmentToUpdate.ProzessGrade = enrollment.ProzessGrade;
                    enrollmentToUpdate.ComponentGrade = enrollment.ComponentGrade;
                    _session.SaveOrUpdate(enrollmentToUpdate);
                    transaction.Commit();
                }
            }
        }

        public List<Enrollment> GetEnrollmentsByStudentId(int id)
        {
            return _session.Query<Enrollment>()
                .Where(e => e.Student.Id == id)
                .ToList();
        }

        public void AddStudentToCourse(int studentId, int courseId)
        {
            var existingEnrollment = _session.Query<Enrollment>()
                                            .FirstOrDefault(e => e.Student.Id == studentId && e.Course.Id == courseId);

            if (existingEnrollment == null)
            {
                var student = _session.Get<Student>(studentId);
                var course = _session.Get<Course>(courseId);

                if (student != null && course != null)
                {
                    var newEnrollment = new Enrollment
                    {
                        Student = student,
                        Course = course
                    };

                    using (var transaction = _session.BeginTransaction())
                    {
                        _session.Save(newEnrollment);
                        transaction.Commit();
                    }
                }
            }
        }

        public void RemoveStudentFromCourse(Enrollment enrollment)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(enrollment);
                transaction.Commit();
            }
        }
    }
}
