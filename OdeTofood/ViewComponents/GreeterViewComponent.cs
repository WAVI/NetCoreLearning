using Microsoft.AspNetCore.Mvc;
using OdeTofood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeTofood.ViewComponents
{
    public class GreeterViewComponent : ViewComponent
    {
        private readonly IGreeter _greeter;

        public GreeterViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetMessageOfTheDay();
            //if we have View(model) and the model is a string, ./net core will go out there looking for a Scott/iustin etc .cshtml
            return View("Default", model);
        }
    }
}
