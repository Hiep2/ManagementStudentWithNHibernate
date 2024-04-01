using ManagementStudentWithNHibernate.DTO;
using ManagementStudentWithNHibernate.IRepositories;
using ManagementStudentWithNHibernate.Models;
using NHibernate;
using NHibernate.Transform;
using System.Collections.Generic;
using System.Linq;
using ISession = NHibernate.ISession;

namespace ManagementStudentWithNHibernate.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ISession _session;

        public CourseRepository(ISession session)
        {
            _session = session;
        }

        public List<CourseEnrollmentDTO> GetCourses()
        {
            return _session.Query<CourseEnrollmentDTO>().ToList();
        }
        public Course GetCourse(int id)
        {
            return _session.Get<Course>(id);
        }
        public void CreateCourse(Course course)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Save(course);
                transaction.Commit();
            }
        }
        public void UpdateCourse(Course course)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Update(course);
                transaction.Commit();
            }
        }

        public void DeleteCourse(Course course)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Delete(course);
                transaction.Commit();
            }
        }
    }
}
