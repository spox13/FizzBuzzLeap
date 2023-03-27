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
        public string Name { get; set; }
        public int? Year { get; set; }
        public string IfLeap { get; set; }
        public List<FizzBuzzForm> FizzBuzzList { get; set; }
        public void OnGet()
        {
            Name = HttpContext.Session.GetString("name");
            Year = HttpContext.Session.GetInt32("year");
            IfLeap = HttpContext.Session.GetString("Leap");

            //var Data = HttpContext.Session.GetString("Data");
            //FizzBuzzList = HttpContext.Session.Get<List<FizzBuzzForm>>("FizzBuzzList");
        }
    }
}