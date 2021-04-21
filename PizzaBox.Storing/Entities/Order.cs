using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PizzaBox.Storing.Entities
{
    public class Order
    {
        public Order()
        {
            Pizzas = new List<Pizza>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public virtual Store Store { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
        [Required]
        public virtual ICollection<Pizza> Pizzas { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime TimePlaced { get; set; }
    }
}