using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.Models;
using ManagementStudentWithNHibernate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManagementStudentWithNHibernate.Pages.Courses
{
    public class EditModel : PageModel
    {
        public ICourseService _courseService;
        [BindProperty]
        public CourseViewModel CourseViewModel { get; set; }

        public EditModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult OnGet(int id)
        {
            var course = _courseService.GetCourse(id);

            if (course == null)
            {
                return NotFound();
            }

            CourseViewModel = new CourseViewModel
            {
                IsEdit = true,
                Course = course
            };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _courseService.UpdateCourse(CourseViewModel.Course);

            return RedirectToPage($"./{ViewNames.Index}");
        }
    }
}
