using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.Models;

namespace ManagementStudentWithNHibernate.Pages.Enrollments
{
    public class EditModel : PageModel
    {
        private readonly IEnrollmentService _enrollmentsService;

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public EditModel(IEnrollmentService enrollmentsService)
        {
            _enrollmentsService = enrollmentsService;
        }

        public IActionResult OnGet(int studentId, int courseId)
        {
            Enrollment = _enrollmentsService.GetEnrollmentByStudentIdAndCourseId(studentId, courseId);

            if (Enrollment == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _enrollmentsService.UpdateEnrollment(Enrollment);

            return RedirectToPage("./Details", new { id = Enrollment.Student.Id});
        }
    }
}
