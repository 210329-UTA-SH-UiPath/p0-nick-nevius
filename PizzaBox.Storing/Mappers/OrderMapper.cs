using System.Collections.Generic;
using PizzaBox.Storing.Entities;
using System;

namespace PizzaBox.Storing.Mappers
{
    public class OrderMapper : IMapper<Entities.Order, Domain.Models.Order>
    {
        private CustomerMapper customerMapper = new CustomerMapper();
        private PizzaMapper pizzaMapper = new PizzaMapper();
        private StoreMapper storeMapper = new StoreMapper();

        public Domain.Models.Order Map(Entities.Order model)
        {
            Domain.Models.Order order = new Domain.Models.Order();
            order.Customer = customerMapper.Map(model.Customer);

            List<Domain.Abstracts.APizza> apizzas = new List<Domain.Abstracts.APizza>();
            model.Pizzas.ForEach(p => apizzas.Add(pizzaMapper.Map(p)));
            order.Pizzas = apizzas;

            order.Price = model.TotalPrice;
            order.Store = storeMapper.Map(model.Store);
            order.TimePlaced = model.TimePlaced;

            order.ID = model.ID;
            return order;
        }

        public Entities.Order Map(Domain.Models.Order model, Entities.AnimalsDbContext context)
        {
            Entities.Order order = new Entities.Order();

            order.Customer = customerMapper.Map(model.Customer, context);
            foreach (Domain.Abstracts.APizza pizza in model.Pizzas)
            {
                var mappedPizza = pizzaMapper.Map(pizza, context);
                mappedPizza.Orders.Add(order);
                order.Pizzas.Add(mappedPizza);
            }

            //model.Pizzas.ForEach(p => pizzas.Add(pizzaMapper.Map(p, context)));

            order.Store = storeMapper.Map(model.Store, context);
            order.TotalPrice = model.Price;
            order.TimePlaced = DateTime.Now;
            return order;
        }
    }
}