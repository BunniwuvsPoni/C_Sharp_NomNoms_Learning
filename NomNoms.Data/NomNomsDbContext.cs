using Microsoft.EntityFrameworkCore;
using NomNoms.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NomNoms.Data
{
    public class NomNomsDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
