using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeTofood.Services;

namespace OdeTofood.Pages
{
    public class GreetingModel : PageModel
    {
        private readonly IGreeter _greeter;

        public string CurrentGreeter { get; set; }

        public GreetingModel(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public void OnGet(string name)
        {
            CurrentGreeter = $"{name} : {_greeter.GetMessageOfTheDay()}";
        }
    }
}