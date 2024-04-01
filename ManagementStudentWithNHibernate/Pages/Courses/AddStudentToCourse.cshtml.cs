using ManagementStudentWithNHibernate.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.Models;
using System.Collections.Generic;

namespace ManagementStudentWithNHibernate.Pages.Courses
{
    public class AddStudentToCourseModel : PageModel
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IStudentService _studentService;
        public int CourseId { get; set; }
        public IList<Student> Students { get; set; }

        [BindProperty]
        public List<int> SelectedStudents { get; set; } = new List<int>();

        public AddStudentToCourseModel(IEnrollmentService enrollmentService, IStudentService studentService)
        {
            _enrollmentService = enrollmentService;
            _studentService = studentService;
        }

        public void OnGet(int courseId)
        {
            CourseId = courseId;
            Students = _studentService.GetStudents();
        }

        public IActionResult OnPost(int courseId)
        {
            if (SelectedStudents != null && SelectedStudents.Count > 0)
            {
                foreach (var studentId in SelectedStudents)
                {
                    _enrollmentService.AddStudentToCourse(studentId, courseId);
                }
            }

            return RedirectToPage("/Courses/Details", new { courseId = courseId });
        }
    }
}
