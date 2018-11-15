using Microsoft.AspNetCore.Mvc;
using OdeTofood.Models;
using OdeTofood.Services;
using OdeTofood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeTofood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;
        #region GOOD WHEN WE BUILD API
        /*
        public IActionResult Index()
        {
            var model = new Restaurant
            {
                Id = 1 ,
                Name = "Scott's Pizza Place"
            };

            //this returns JSON. Good for APIS
            return new ObjectResult( model );
        }
        */
        #endregion

        public HomeController(IRestaurantData restaurantData,
                              IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Restaurants = _restaurantData.GetAll() ,
                CurrentMessage = _greeter.GetMessageOfTheDay()
            };
            
            //by default its looking after Views folder compared to the controller/model where the name doesn't matter
            return View(model);
        }
    }
}
