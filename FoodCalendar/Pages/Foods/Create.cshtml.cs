﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodCalendar.Data;
using FoodCalendar.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodCalendar.Pages.Foods
{
    public class CreateModel : PageModel
    {
        private readonly FoodCalendar.Data.FoodCalendarContext _context;

        public SelectList DishTypeSL { get; set; }

        public void PopulateDishTypeDropDownList(FoodCalendar.Data.FoodCalendarContext context, object selectDishType = null)
        {
            var dishtypequery = from d in context.DishType orderby d.DishTypeName select d;
            DishTypeSL = new SelectList(dishtypequery.AsNoTracking(), nameof(DishType.Id), nameof(DishType.DishTypeName), selectDishType);
        }
        public CreateModel(FoodCalendar.Data.FoodCalendarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDishTypeDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Food Food { get; set; }

        [BindProperty]
        public DishType DishType { get; set; }
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
