using ManagementStudentWithNHibernate.IRepositories;
using System.Collections.Generic;
using ManagementStudentWithNHibernate.Models;
using ManagementStudentWithNHibernate.IServices;

namespace ManagementStudentWithNHibernate.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepositories;

        public StudentService(IStudentRepository studentRepositories)
        {
            _studentRepositories = studentRepositories;
        }

        public List<Student> GetStudents()
        {
            return _studentRepositories.GetStudents();
        }

        public Student GetStudent(int id)
        {
            return _studentRepositories.GetStudent(id);
        }

        public void CreateStudent(Student student)
        {
            _studentRepositories.CreateStudent(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepositories.UpdateStudent(student);
        }

        public void DeleteStudent(Student student)
        {
            _studentRepositories.DeleteStudent(student);
        }
    }
}
