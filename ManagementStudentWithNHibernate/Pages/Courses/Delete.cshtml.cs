using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManagementStudentWithNHibernate.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly ICourseService _courseService;
        [BindProperty]
        public Course Course { get; set; }

        public DeleteModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void OnGet(int id)
        {
            Course = _courseService.GetCourse(id);
        }

        public IActionResult OnPost()
        {
            var courseDelete = _courseService.GetCourse(Course.Id);

            if(courseDelete != null)
            {
                _courseService.DeleteCourse(courseDelete);
                return Redirect($"./{ViewNames.Index}");
            }

            return Page();
        }

    }
}
