using FizzBuzzLeap.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzLeap.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzzForm FizzBuzz { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            string Leap;

            bool isLeapYear = FizzBuzz.Year % 4 == 0 && (FizzBuzz.Year % 100 != 0 || FizzBuzz.Year % 400 == 0);

            if (FizzBuzz.Year % 4 == 0 && (FizzBuzz.Year % 100 != 0 || FizzBuzz.Year % 400 == 0))
            {
                Leap = "rok przestępny";
            }
            else
            {
                Leap = "rok nieprzestępny";
            }

            string IfLeap = FizzBuzz.Name + " urodził się w " + FizzBuzz.Year + " roku. " + "Był to " + Leap;
            if (ModelState.IsValid)
            {
                ViewData["Message"] = IfLeap;
                HttpContext.Session.SetString("name", FizzBuzz.Name);
                HttpContext.Session.SetInt32("year", FizzBuzz.Year);
                HttpContext.Session.SetString("Leap", Leap);

                //List<FizzBuzzForm> FizzBuzzList = HttpContext.Session.Get<List<FizzBuzzForm>>("FizzBuzzList") ?? new List<FizzBuzzForm>();
                //FizzBuzzList.Add(FizzBuzz);
                //HttpContext.Session.Set("FizzBuzzList", FizzBuzzList);
            }
            return Page();
        }
    }
}