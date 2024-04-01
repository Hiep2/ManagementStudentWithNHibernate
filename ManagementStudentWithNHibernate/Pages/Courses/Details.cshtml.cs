using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.Models;
using ManagementStudentWithNHibernate.Pages.Enrollments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementStudentWithNHibernate.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly ICourseService _courseService;
        private readonly IEnrollmentService _enrollmentService;

        public Course Course { get; set; }
        public List<Student> EnrolledStudents { get; set; }

        public DetailsModel(ICourseService courseService, IEnrollmentService enrollmentService)
        {
            _courseService = courseService;
            _enrollmentService = enrollmentService;
        }

        public void OnGet(int courseId)
        {
            Course = _courseService.GetCourse(courseId);
            EnrolledStudents = _enrollmentService.GetStudentsByCourseId(courseId);
        }

        public IActionResult OnPostDeleteStudent(int courseId, int studentId)
        {
            var enrollment = _enrollmentService.GetEnrollmentByStudentIdAndCourseId(studentId, courseId);

            _enrollmentService.RemoveStudentFromCourse(enrollment);

            return RedirectToPage(new { courseId });
        }
    }
}
