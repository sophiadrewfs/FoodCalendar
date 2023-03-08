using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodCalendar.Data;
using FoodCalendar.Models;

namespace FoodCalendar.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly FoodCalendar.Data.FoodCalendarContext _context;

        public IndexModel(FoodCalendar.Data.FoodCalendarContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Food != null)
            {
                Food = await _context.Food
                .Include(f => f.DishType).ToListAsync();
            }
        }
    }
}
