using ManagementStudentWithNHibernate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagementStudentWithNHibernate.IServices;

namespace ManagementStudentWithNHibernate.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentService _studentService;
        [BindProperty]
        public StudentViewModel StudentViewModel { get; set; }

        public CreateModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void OnGet()
        {
            StudentViewModel = new StudentViewModel
            {
                IsEdit = false,
                Student = new Student()
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _studentService.CreateStudent(StudentViewModel.Student);

            return RedirectToPage($"./{ViewNames.Index}");
        }
    }
}
