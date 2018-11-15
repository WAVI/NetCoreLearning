using Microsoft.AspNetCore.Mvc;
using OdeTofood.Models;
using OdeTofood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeTofood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
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


        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

       

        public IActionResult Index()
        {
            var model = _restaurantData.GetAll();
            
            return View(model);
        }
    }
}
