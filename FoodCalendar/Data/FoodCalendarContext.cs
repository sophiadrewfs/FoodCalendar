using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodCalendar.Models;

namespace FoodCalendar.Data
{
    public class FoodCalendarContext : DbContext
    {
        public FoodCalendarContext (DbContextOptions<FoodCalendarContext> options)
            : base(options)
        {
        }

        public DbSet<FoodCalendar.Models.Food> Food { get; set; } = default!;
    }
}
