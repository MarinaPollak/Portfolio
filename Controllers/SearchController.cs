using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SearchingMVC.Models; // Replace with your namespace
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace SearchingMVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly List<int> _numbers;

        public SearchController(IWebHostEnvironment webHostEnvironment)
        {
            string filePath = Path.Combine(webHostEnvironment.ContentRootPath, "DataFiles", "scores.txt");

            if (!System.IO.File.Exists(filePath))
            {
                // Handle missing file gracefully
                _numbers = new List<int>(); // Initialize an empty list
                Console.WriteLine("The file 'scores.txt' is missing.");
            }
            else
            {
                _numbers = System.IO.File.ReadAllLines(filePath).Select(int.Parse).ToList();
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(int targetNumber)
        {
            SearchAlgorithms searchAlgorithms = new SearchAlgorithms(_numbers);

            int linearResult = searchAlgorithms.LinearSearch(targetNumber);
            int binaryResult = searchAlgorithms.BinarySearch(targetNumber);
            int interpolationResult = searchAlgorithms.InterpolationSearch(targetNumber);

            ViewBag.Target = targetNumber;
            ViewBag.LinearResult = linearResult != -1 ? $"Found at index {linearResult}" : "Not Found";
            ViewBag.BinaryResult = binaryResult != -1 ? $"Found at index {binaryResult}" : "Not Found";
            ViewBag.InterpolationResult = interpolationResult != -1 ? $"Found at index {interpolationResult}" : "Not Found";

            return View("Index");
        }
    }
}
