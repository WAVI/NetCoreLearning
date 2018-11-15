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

        public HomeController( IRestaurantData restaurantData ,
                              IGreeter greeter )
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
            //if this is being returned in the Index() method, then its gonna look for Index.cshtml
            return View( model );
        }

        public IActionResult Details( int id )
        {
            var model = _restaurantData.Get( id );
            if ( model is null )
            {
                ////return a http response with 404. its good with API
                //return NotFound();

                return RedirectToAction( nameof( Index ) );
            }
            return View( model );
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create( RestaurantEditModel model ) 
        {
            var newRestaurant = new Restaurant
            {
                Name = model.Name ,
                Cuisine = model.Cuisine
            };

            newRestaurant = _restaurantData.Add( newRestaurant );

            return View( "Details", newRestaurant );
        }
    }
}
