using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodCalendar.Data;
using FoodCalendar.Models;

namespace FoodCalendar.Pages.DishTypes
{
    public class IndexModel : PageModel
    {
        private readonly FoodCalendar.Data.FoodCalendarContext _context;

        public IndexModel(FoodCalendar.Data.FoodCalendarContext context)
        {
            _context = context;
        }

        public IList<DishType> DishType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DishType != null)
            {
                DishType = await _context.DishType.ToListAsync();
            }
        }
    }
}
