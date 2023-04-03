using FizzBuzzLeap.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzzLeap.Forms;

namespace FizzBuzzLeap.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public IList<FizzBuzzForm> ListOfSessions { get; set; } = new List<FizzBuzzForm>();
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
            {
                ListOfSessions = JsonConvert.DeserializeObject<List<FizzBuzzForm>>(Data);
            }
        }
    }
}