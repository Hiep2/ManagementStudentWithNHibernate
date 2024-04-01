using System.Collections.Generic;
using ManagementStudentWithNHibernate.Models;

namespace ManagementStudentWithNHibernate.IRepositories
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        Student GetStudent(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
}
