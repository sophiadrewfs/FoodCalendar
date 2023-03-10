using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodCalendar.Data;
using FoodCalendar.Models;

namespace FoodCalendar.Pages.DishTypes
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
            return Page();
        }

        [BindProperty]
        public DishType DishType { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DishType.Add(DishType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
