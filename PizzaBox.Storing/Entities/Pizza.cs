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
            //Toppings = new List<Topping>();
            PizzaToppings = new List<PizzaTopping>();
            Orders = new List<Order>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public PIZZA_TYPE PizzaType { get; set; }
        [Required]
        public virtual Crust Crust { get; set; }
        [Required]
        public virtual Size Size { get; set; }
        [Required]
        //public virtual ICollection<Topping> Toppings { get; set; }
        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public virtual ICollection<Order> Orders { get; set; }
    }
}