using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public enum PIZZA_TYPE
    {
        Custom,
        Meat,
        Vegan
    }

    public class Pizza
    {
        public Pizza()
        {
            Toppings = new List<Topping>();
            Orders = new List<Order>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public PIZZA_TYPE PizzaType { get; set; }
        [Required]
        public Crust Crust { get; set; }
        [Required]
        public Size Size { get; set; }
        [Required]
        public List<Topping> Toppings { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public ICollection<Order> Orders { get; set; }
    }
}