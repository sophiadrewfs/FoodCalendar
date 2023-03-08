using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodCalendar.Data;
using FoodCalendar.Models;

namespace FoodCalendar.Pages.Foods
{
    public class CreateModel : PageModel
    {
        private readonly FoodCalendar.Data.FoodCalendarContext _context;

        public CreateModel(FoodCalendar.Data.FoodCalendarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TypeId"] = new SelectList(_context.DishType, "Id", "DishTypeName");
            return Page();
        }

        [BindProperty]
        public Food Food { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Food.Add(Food);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
