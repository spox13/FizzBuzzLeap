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
        public Session SessionFizzBuzz { get; set; } = new Session();
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
            {
                SessionFizzBuzz = JsonConvert.DeserializeObject<Session>(Data);
                HttpContext.Session.SetString("Current", JsonConvert.SerializeObject(SessionFizzBuzz));
            }
        }
    }
}