using Microsoft.AspNetCore.Http;
using ManagementStudentWithNHibernate.Models;
using System.Collections.Generic;
using NHibernate;
using ISession = NHibernate.ISession;
using System.Linq;
using ManagementStudentWithNHibernate.IRepositories;
using System.Threading.Tasks;


namespace ManagementStudentWithNHibernate.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ISession _session;

        public StudentRepository(ISession session)
        {
            _session = session;
        }

        public List<Student> GetStudents()
        {
            return _session.Query<Student>().ToList();
        }

        public Student GetStudent(int id)
        {
            return _session.Get<Student>(id);
        }

        public void CreateStudent(Student student)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Save(student);
                transaction.Commit();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Update(student);
                transaction.Commit();
            }
        }

        public void DeleteStudent(Student student)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Delete(student);
                transaction.Commit();
            }
        }
    }
}
