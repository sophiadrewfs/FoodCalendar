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
    public class DeleteModel : PageModel
    {
        private readonly FoodCalendar.Data.FoodCalendarContext _context;

        public DeleteModel(FoodCalendar.Data.FoodCalendarContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DishType DishType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DishType == null)
            {
                return NotFound();
            }

            var dishtype = await _context.DishType.FirstOrDefaultAsync(m => m.Id == id);

            if (dishtype == null)
            {
                return NotFound();
            }
            else 
            {
                DishType = dishtype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.DishType == null)
            {
                return NotFound();
            }
            var dishtype = await _context.DishType.FindAsync(id);

            if (dishtype != null)
            {
                DishType = dishtype;
                _context.DishType.Remove(DishType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
