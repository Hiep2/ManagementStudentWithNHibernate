using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.Models;

namespace ManagementStudentWithNHibernate.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentService _studentService;
        [BindProperty]
        public Student Student { get; set; }

        public DeleteModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void OnGet(int id)
        {
            Student = _studentService.GetStudent(id);
        }

        public IActionResult OnPost()
        {
            var studentToDelete = _studentService.GetStudent(Student.Id);

            if (studentToDelete != null)
            {
                _studentService.DeleteStudent(studentToDelete);
                return RedirectToPage($"./{ViewNames.Index}");
            }

            return Page();
        }
    }
}
