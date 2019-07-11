using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NomNoms.Core;

namespace NomNoms.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }
        public void OnGet(int restaurantId)
        {
            Restaurant = new Restaurant();
            Restaurant.Id = restaurantId;
        }
    }
}