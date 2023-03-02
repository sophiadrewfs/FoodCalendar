using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodCalendar.Data;
using FoodCalendar.Models;

namespace FoodCalendar.Pages.DishTypes
{
    public class EditModel : PageModel
    {
        private readonly FoodCalendar.Data.FoodCalendarContext _context;

        public EditModel(FoodCalendar.Data.FoodCalendarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DishType DishType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DishType == null)
            {
                return NotFound();
            }

            var dishtype =  await _context.DishType.FirstOrDefaultAsync(m => m.Id == id);
            if (dishtype == null)
            {
                return NotFound();
            }
            DishType = dishtype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DishType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishTypeExists(DishType.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DishTypeExists(int id)
        {
          return _context.DishType.Any(e => e.Id == id);
        }
    }
}
