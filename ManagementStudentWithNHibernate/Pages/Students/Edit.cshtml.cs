using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ManagementStudentWithNHibernate.Pages.Students
{
	public class EditModel : PageModel
	{
		private readonly IStudentService _studentService;

		[BindProperty]
		public StudentViewModel StudentViewModel { get; set; }

		public EditModel(IStudentService studentService)
		{
			_studentService = studentService;
		}

		public IActionResult OnGet(int id)
		{
			var student = _studentService.GetStudent(id);

			if (student == null)
			{
				return NotFound();
			}

			StudentViewModel = new StudentViewModel
			{
				IsEdit = true,
				Student = student
			};

			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_studentService.UpdateStudent(StudentViewModel.Student);

			return RedirectToPage($"./{ViewNames.Index}");
		}
	}
}
