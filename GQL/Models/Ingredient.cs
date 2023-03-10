using System.ComponentModel.DataAnnotations;

namespace GQL.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DrinkId { get; set; }

        public Drink Drink { get; set; }
    }
}
