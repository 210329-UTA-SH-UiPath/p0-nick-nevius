using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(MeatPizza))]
    [XmlInclude(typeof(VeganPizza))]
    public abstract class APizza : ASellable
    {
        public Crust Crust { get; set; }
        public Size Size { get; set; }

        // This stupid crap needs to be here so I it doesn't
        // serialize the Toppings then add them in using
        // the default constructors ending up with duplicates
        // TODO: find a better way to handle this
        [XmlIgnore]
        public List<Topping> Toppings { get; set; }
        public string Name { get; set; }
        private decimal price = 0.0m;
        public override decimal Price
        {
            get
            {
                if (price != 0.0m)
                {
                    return price;
                }
                price += Crust.Price;
                price += Size.Price;
                foreach (Topping topping in Toppings)
                {
                    price += topping.Price;
                }
                return price;
            }
            set
            {
                price = value;
            }
        }

        public override string ToString()
        {
            if (this is CustomPizza)
            {
                string output = $"Custom Pizza - {Price}" + Environment.NewLine + $"\tCrust: {Crust}" + Environment.NewLine + $"\tSize: {Size}" + Environment.NewLine + "\tToppings: ";
                Toppings.ForEach(topping => output += topping.ToString() + ", ");
                var lastIndex =  output.LastIndexOf(", ");
                if (lastIndex != -1)
                {
                    output = output.Substring(0, lastIndex);
                }
                return output;
            }

            return $"{Name} - {Price}";
        }

        protected APizza(String name)
        {
            Name = name;
            Factory();
        }

        private void Factory()
        {
            Toppings = new List<Topping>();

            AddCrust();
            AddSize();
            AddToppings();
        }

        public abstract void AddCrust();

        public abstract void AddSize();

        public abstract void AddToppings();

        public abstract APizza Clone();
    }
}
