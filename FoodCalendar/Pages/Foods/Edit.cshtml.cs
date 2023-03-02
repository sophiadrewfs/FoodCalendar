﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodCalendar.Data;
using FoodCalendar.Models;

namespace FoodCalendar.Pages.Foods
{
    public class EditModel : PageModel
    {
        private readonly FoodCalendar.Data.FoodCalendarContext _context;
        public SelectList DishTypeSL { get; set; }
        public void PopulateDishTypeDropDownList(FoodCalendar.Data.FoodCalendarContext context, object selectDishType = null)
        {
            var dishtypequery = from d in context.DishType orderby d.DishTypeName select d;
            DishTypeSL = new SelectList(dishtypequery.AsNoTracking(), nameof(DishType.Id), nameof(DishType.DishTypeName), selectDishType);
        }
        public EditModel(FoodCalendar.Data.FoodCalendarContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Food Food { get; set; } = default!;
        [BindProperty]
        public DishType DishType { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Food == null)
            {
                return NotFound();
            }

            var food =  await _context.Food.FirstOrDefaultAsync(m => m.Id == id);
            if (food == null)
            {
                return NotFound();
            }
            Food = food;
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

            _context.Attach(Food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(Food.Id))
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

        private bool FoodExists(int id)
        {
          return _context.Food.Any(e => e.Id == id);
        }
    }
}
