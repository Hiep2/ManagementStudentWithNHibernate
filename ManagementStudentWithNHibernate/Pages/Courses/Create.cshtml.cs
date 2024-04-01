using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManagementStudentWithNHibernate.Pages.Courses
{
    public class Create1Model : PageModel
    {
        public ICourseService _courseService;
        [BindProperty]
        public CourseViewModel CourseViewModel { get; set; }

        public Create1Model(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void OnGet()
        {
            CourseViewModel = new CourseViewModel
            {
                IsEdit = false,
                Course = new Course()
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _courseService.CreateCourse(CourseViewModel.Course);

            return RedirectToPage($"./{ViewNames.Index}");
        }
    }
}
