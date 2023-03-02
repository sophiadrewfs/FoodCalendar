using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodCalendar.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string? FoodName { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastAte { get; set; }
        public string? Type { get; set; }
        //[ForeignKey("DishType")]
        public DishType? DishType { get; set; } 
        public int NumofPeople { get; set; }
    }

    public class DishType
    { 
        public int Id { get; set; }
        public string DishTypeName { get; set; } = string.Empty;
    }
}
