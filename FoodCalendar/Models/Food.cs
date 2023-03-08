using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCalendar.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Display(Name = "Dish")]
        public string? FoodName { get; set; }
        [Display(Name = "Last Ate")]
        [DataType(DataType.Date)]
        public DateTime LastAte { get; set; }
        [Display(Name = "Dish Type")]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public DishType? DishType { get; set; }
        [Display(Name = "# of People")]
        public int NumofPeople { get; set; }
        public string? Recipe { get; set; }
    }

    public class DishType
    { 
        public int Id { get; set; }
        [Display(Name = "Dish Type")]
        public string DishTypeName { get; set; } = string.Empty;
    }
}
