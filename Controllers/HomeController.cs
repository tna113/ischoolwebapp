using iSchoolWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using iSchoolWebApp.Services;

namespace iSchoolWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            //load the data...
            var getAbout = new GetAbout();

            //tell the instance to go get the data...
            var loadedAbout = await getAbout.getAb();

            //take the loadedAbout and populate the model
            var aboutModel = new AboutRootModel()
            {
                Title = "About our iSchool",
                About = loadedAbout
            };

            //call the view
            return View(aboutModel);
        }

        public async Task<IActionResult> Faculty()
        {
            //setup to load the data
            //supposed to include iSchoolWebApp.Models and iSchoolWebApp.Services
            var getAllFac = new GetFaculty(); //inside GetFaculty.cs ... it's a class

            //load the data
            var loadedFac = await getAllFac.getAllFaculty(); //have to await bcos GetFaculty() is async task return type

            //populate the model
            var facultyModel = new FacultyRootModel()
            {
                //needs List<Faculty> faculty and a String title
                Title = "iSchool Faculty",
                faculty = loadedFac.ToList()
            };

            //send to the view
            return View(facultyModel);
        }

        public async Task<IActionResult> Staff()
        {
            var getAllStaff = new GetStaff();
            var loadedStaff = await getAllStaff.getAllStaff();
            var staffModel = new StaffRootModel()
            {
                title = "Staff",
                staff = loadedStaff.ToList()
            };

            return View(staffModel);
        }

        public async Task<IActionResult> Undergraduate()
        {
            var getAllUndergrad = new GetUndergraduate();
            var loadedUndergrad = await getAllUndergrad.getAllUndergraduate();
            var undergradModel = new UndergraduateRootModel()
            {
                Title = "Undergraduate Degrees",
                undergraduate = loadedUndergrad.ToList()
            };

            return View(undergradModel);
        }

        public async Task<IActionResult> Graduate()
        {
            var getAllGrad = new GetGraduate();
            var loadedGrad = await getAllGrad.getAllGraduate();
            var gradModel = new GraduateRootModel()
            {
                Title = "Graduate Degrees",
                graduate = loadedGrad.ToList()
            };
            
            return View(gradModel);
        }

        public async Task<IActionResult> Minors()
        {
            var getAllMinors = new GetMinors();
            var loadedMinors = await getAllMinors.getAllMinors();
            var minorModel = new MinorsRootModel()
            {
                title = "Minors",
                minors = loadedMinors.ToList()
            };

            return View(minorModel);
        }

        public async Task<IActionResult> Employment()
        {
            //set up to load the data
            var getEmployment = new GetEmployment();
            //get the data
            var loadedEmployment = await getEmployment.getAllEmployment();
            //send to view
            return View(loadedEmployment);
        }

        public async Task<IActionResult> Course()
        {
            var getAllCourses = new GetCourse();
            var loadedCourses = await getAllCourses.getAllCourse();
            var courseModel = new CourseRootModel()
            {
                title = "Courses",
                course = loadedCourses
            };

            return View(courseModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
