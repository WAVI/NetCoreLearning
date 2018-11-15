﻿using OdeTofood.Models;
using System.Collections.Generic;

namespace OdeTofood.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}
