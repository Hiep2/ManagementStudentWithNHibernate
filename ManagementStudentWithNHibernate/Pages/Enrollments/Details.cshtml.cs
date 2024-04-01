using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.Models;

namespace ManagementStudentWithNHibernate.Pages.Enrollments
{
    public class DetailsModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly IEnrollmentService _enrollmentService;

        public Student Student { get; private set; }
        public List<Course> Courses { get; private set; }
        public List<Enrollment> Enrollment { get; private set; }

        public DetailsModel(IStudentService studentService, IEnrollmentService enrollmentService)
        {
            _studentService = studentService;
            _enrollmentService = enrollmentService;
        }

        public void OnGet(int id)
        {
            Student = _studentService.GetStudent(id);
            Courses = _enrollmentService.GetCoursesByStudentId(id);
            Enrollment = _enrollmentService.GetEnrollmentsByStudentId(id);
        }
    }
}
