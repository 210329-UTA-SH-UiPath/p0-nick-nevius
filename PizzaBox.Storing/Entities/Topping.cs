using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public enum TOPPING_TYPE
    {
        Bacon,
        Mushroom,
        Onion,
        Pepperoni
    }
    public class Topping
    {
        public Topping()
        {
            Pizzas = new List<Pizza>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public TOPPING_TYPE ToppingType { get; set; }
        [Required]
        public decimal Price { get; set; }
        public ICollection<Pizza> Pizzas { get; set; }
    }
}