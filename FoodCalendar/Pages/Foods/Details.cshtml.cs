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
    public class DetailsModel : PageModel
    {
        private readonly FoodCalendar.Data.FoodCalendarContext _context;

        public DetailsModel(FoodCalendar.Data.FoodCalendarContext context)
        {
            _context = context;
        }

      public Food Food { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Food == null)
            {
                return NotFound();
            }

            //var food = await _context.Food.FirstOrDefaultAsync(m => m.Id == id);
            Food = await _context.Food.Include(c => c.DishType).FirstOrDefaultAsync(m => m.Id == id);
            if (Food == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
