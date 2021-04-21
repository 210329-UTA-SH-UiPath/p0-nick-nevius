using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Storing.Entities
{
    public class PizzaTopping
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public virtual Pizza Pizza { get; set; }
        [Required]
        public virtual Topping Topping { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}