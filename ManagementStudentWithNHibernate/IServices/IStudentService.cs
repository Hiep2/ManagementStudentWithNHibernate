using System.Collections.Generic;
using ManagementStudentWithNHibernate.Models;

namespace ManagementStudentWithNHibernate.IServices
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudent(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
    }
}
