using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System;
using System.Linq;
using ManagementStudentWithNHibernate.Models;
using NHibernate;
using ManagementStudentWithNHibernate.IServices;

namespace ManagementStudentWithNHibernate.Pages.Students
{
    public class IndexModel : PageModel
    {
        public List<Student> Students { get; set; }
        private readonly IStudentService _studentService;

        public IndexModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void OnGet()
        {
            Students = _studentService.GetStudents();
        }
    }
}
