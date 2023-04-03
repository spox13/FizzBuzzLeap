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
        public FizzBuzzForm FizzBuzz { get; set; } = new FizzBuzzForm();
        public IList<FizzBuzzForm> ListOfSessions { get; set; } = new List<FizzBuzzForm>();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            bool isLeapYear = FizzBuzz.Year % 4 == 0 && (FizzBuzz.Year % 100 != 0 || FizzBuzz.Year % 400 == 0);

            if (FizzBuzz.Year % 4 == 0 && (FizzBuzz.Year % 100 != 0 || FizzBuzz.Year % 400 == 0))
            {
                FizzBuzz.Leap = "rok przestępny";
            }
            else
            {
                FizzBuzz.Leap = "rok nieprzestępny";
            }

            string IfLeap = FizzBuzz.Name + " urodził się w " + FizzBuzz.Year + " roku. " + "Był to " + FizzBuzz.Leap;

            if (!String.IsNullOrEmpty(FizzBuzz.Name) && !String.IsNullOrEmpty(FizzBuzz.Year.ToString()) && FizzBuzz.Year >= 1899 && FizzBuzz.Year <= 2022)
            {
                ViewData["Message"] = IfLeap;
                var Data = HttpContext.Session.GetString("Data");
                if (Data != null)
                {
                    ListOfSessions = JsonConvert.DeserializeObject<List<FizzBuzzForm>>(Data);
                }
                ListOfSessions.Add(FizzBuzz);
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(ListOfSessions));
            }
            return Page();
        }
    }
}