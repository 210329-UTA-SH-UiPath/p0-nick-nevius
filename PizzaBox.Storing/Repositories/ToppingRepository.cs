using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Mappers;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
    public class ToppingRepository : IRepository<Domain.Models.Topping>
    {
        private readonly AnimalsDbContext context;
        private readonly ToppingMapper mapper = new ToppingMapper();
        public ToppingRepository(AnimalsDbContext context)
        {
            this.context = context;
        }

        public void Add(Domain.Models.Topping t)
        {
            context.Toppings.Add(mapper.Map(t, context));
            context.SaveChanges();
        }

        public List<Domain.Models.Topping> GetList()
        {
            return context.Toppings.Select(mapper.Map).ToList();
            //List<Domain.Models.Topping> toppings = new List<Domain.Models.Topping>();
            //context.Toppings.AsEnumerable().GroupBy(t => t.ToppingType).Select(t => t.First()).ToList().ForEach(topping => toppings.Add(mapper.Map(topping)));
            //return toppings;
        }

        public void Remove(Domain.Models.Topping t)
        {
            Entities.Topping dbTopping = mapper.Map(t, context);
            Entities.Topping topping = context.Toppings.ToList().Find(t => t.ToppingType == dbTopping.ToppingType);
            if (topping is not null)
            {
                context.Remove(topping);
                context.SaveChanges();
            }
        }

        public void Update(Domain.Models.Topping existing, Domain.Models.Topping updated)
        {
            Entities.Topping dbTopping = mapper.Map(existing, context);
            Entities.Topping topping = context.Toppings.ToList().Find(t => t.ToppingType == dbTopping.ToppingType);
            if (topping is not null)
            {
                Entities.Topping updatedTopping = mapper.Map(updated, context);
                topping.ToppingType = updatedTopping.ToppingType;
                topping.Price = updatedTopping.Price;
                context.SaveChanges();
            }
        }
    }
}