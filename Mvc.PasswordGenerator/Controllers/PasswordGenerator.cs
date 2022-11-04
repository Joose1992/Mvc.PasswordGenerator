using Microsoft.AspNetCore.Mvc;
using Mvc.PasswordGenerator.Models;

namespace Mvc.PasswordGenerator.Controllers
{
    public class PasswordGenerator : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            PasswordGeneratorViewModel model = new PasswordGeneratorViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult GeneratePassword(PasswordGeneratorViewModel model)
        {
            Random random = new Random();

            // created different types of password result to add to the PasswordResult
            string result = "";
            string defaultPassword = "";
            string specialChar = "";

            //special characters
            int specialStart = 33;
            int specialEnd = 126;
            
            if (model.SpecialCharacters)
            {
                for(int i = 0; i < model.PasswordLength; i++)
                {
                    int intCharValue = random.Next(specialStart, specialEnd);
                    char c = Convert.ToChar(intCharValue);
                    specialChar += c;
                }
                result = specialChar;
            }
            else
            {
                for(int i = 0; i < model.PasswordLength; i++)
                {
                    string values = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQ1234567890";
                    int intValue = random.Next(0, values.Length);
                    char character = values[intValue];
                    defaultPassword += character;
                }
                result = defaultPassword;
            }

            model.PasswordResult = result;

            return View("Index", model);
        }
    }
}
