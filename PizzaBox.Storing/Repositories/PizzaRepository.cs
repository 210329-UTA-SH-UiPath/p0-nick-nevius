using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Mappers;
using PizzaBox.Storing.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
    public class PizzaRepository : IRepository<APizza>
    {
        private readonly PizzaMapper mapper = new PizzaMapper();
        private readonly AnimalsDbContext context;
        public PizzaRepository(AnimalsDbContext context)
        {
            this.context = context;
        }

        public void Add(APizza t)
        {
            context.Pizzas.Add(mapper.Map(t, context));
            context.SaveChanges();
        }

        public List<APizza> GetList()
        {
            return context.Pizzas.Include(p => p.Crust).Include(p => p.Size).Include(p => p.PizzaToppings).AsEnumerable().GroupBy(p => p.PizzaType).Select(p => p.First()).Select(mapper.Map).ToList();
            //List<APizza> pizzas = new List<APizza>();
            //context.Pizzas.Include(p => p.Crust).Include(p => p.Size).Include(p => p.Toppings).AsEnumerable().GroupBy(p => p.PizzaType).Select(p => p.First()).ToList().ForEach(pizza => pizzas.Add(mapper.Map(pizza)));
            //ontext.Pizzas.Include(p => p.Crust).Include(p => p.Size).Include(p => p.Toppings).ToList().ForEach(pizza => pizzas.Add(mapper.Map(pizza)));
            //return pizzas;
        }

        public void Remove(APizza t)
        {
            Pizza dbPizza = mapper.Map(t, context);
            Pizza pizza = context.Pizzas.ToList().Find(p => p.GetHashCode() == dbPizza.GetHashCode());
            if (pizza is not null)
            {
                context.Remove(pizza);
                context.SaveChanges();
            }
        }

        public void Update(APizza existing, APizza updated)
        {
            Pizza dbPizza = mapper.Map(existing, context);
            Pizza pizza = context.Pizzas.ToList().Find(p => p.GetHashCode() == dbPizza.GetHashCode());
            if (pizza is not null)
            {
                Pizza updatedPizza = mapper.Map(updated, context);
                pizza.Crust = updatedPizza.Crust;
                pizza.Size = updatedPizza.Size;
                pizza.PizzaType = updatedPizza.PizzaType;
                pizza.Price = updatedPizza.Price;
                pizza.PizzaToppings = updatedPizza.PizzaToppings;
                context.SaveChanges();
            }
        }
    }
}