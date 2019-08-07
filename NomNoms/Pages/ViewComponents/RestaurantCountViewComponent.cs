using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NomNoms.Data;

namespace NomNoms.Pages.ViewComponents
{
    public class RestaurantCountViewComponent
        : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

         public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRestaurants();
            //   Pass the model to the view
            return View(count);
        }
    }
}
