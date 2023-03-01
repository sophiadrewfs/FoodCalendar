using System.ComponentModel.DataAnnotations;

namespace FoodCalendar.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string? FoodName { get; set; }
        [DataType(DataType.Date)]
        public DateTime lastAte { get; set; }
        public string? Type { get; set; }
        public int NumofPeople { get; set; }
    }
}
