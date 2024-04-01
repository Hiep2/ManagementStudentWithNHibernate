using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ManagementStudentWithNHibernate.Pages.Enrollments
{
    public class IndexModel : PageModel
    {
        private readonly IEnrollmentService _enrollmentService;
        public List<Student> SearchResults { get; set; }

        public IndexModel(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        public void OnGet(string searchString)
        {
            SearchResults = _enrollmentService.SearchStudent(searchString);
        }
    }
}
