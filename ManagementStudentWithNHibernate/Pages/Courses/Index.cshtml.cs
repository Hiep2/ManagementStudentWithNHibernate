using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ManagementStudentWithNHibernate.Models;
using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.DTO;

namespace ManagementStudentWithNHibernate.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseService _courseService;
        public List<CourseEnrollmentDTO> Courses { get; set; }

        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void OnGet()
        {
            Courses = _courseService.GetCourses();
        }
    }
}
