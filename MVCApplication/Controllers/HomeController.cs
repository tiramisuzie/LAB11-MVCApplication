using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using System.Collections.Generic;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// View Page with User Input
        /// </summary>
        /// <returns>ViewResult</returns>
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        /// <summary>
        /// This POST will take start year and end year as params and redirect user to the result page with data within the selected years
        /// </summary>
        /// <param name="startYear">start year</param>
        /// <param name="endYear">end year</param>
        /// <returns>Object that redirect user to the result page</returns>
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            // Redirect to Result action within this controller
            return RedirectToAction("Result", new { startYear, endYear });
        }

        /// <summary>
        /// This GET will display the data base on the start year and endyear to be displayed on the page.
        /// </summary>
        /// <param name="startYear">start year</param>
        /// <param name="endYear">end year</param>
        /// <returns>ViewResult with collection of Person</returns>
        public ViewResult Result(int startYear, int endYear)
        {
            List<Person> peopleOfTheYear = Person.GetPersons(startYear, endYear);

            ViewData["startYear"] = startYear;
            ViewData["endYear"] = endYear;

            return View(peopleOfTheYear);
        }

    }
}
