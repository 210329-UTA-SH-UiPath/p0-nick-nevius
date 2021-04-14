using PizzaBox.Client.Contexts;
using PizzaBox.Client.Singletons;
using System.Linq;
using System.Collections.Generic;
using PizzaBox.Storing.Entities;
using System;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Client.States
{
    public class DisplayStoreSalesState : AState
    {
        public override void Handle(Context context)
        {
            // get all orders for context.Store from context.FirstDate to context.LastDate
            // then get:
            // number of each type of pizza
            // total revenue
            var validOrders = OrderSingleton.Instance.Orders.Where(order => order.Store.Name.Equals(context.Store.Name))
                .Where(order => order.TimePlaced.CompareTo(context.FirstDay) >=0 && order.TimePlaced.CompareTo(context.LastDay) <= 0).ToList();
            var totalSales = validOrders.Sum(order => order.Price);

            //Pizzas.Include(p => p.Crust).Include(p => p.Size).Include(p => p.Toppings).AsEnumerable().GroupBy(p => p.PizzaType).ToList();

            Console.WriteLine($"Sales totals: {totalSales}");
            Console.WriteLine("Types of pizzas sold: ");
            var listOfTypes = DbContextSingleton.Instance.Context.Orders.Include(o => o.Store).Where(o => o.Store.Name.Equals(context.Store.Name))
                    .Where(order => order.TimePlaced.CompareTo(context.FirstDay) >=0 && order.TimePlaced.CompareTo(context.LastDay) <= 0)
                    .Include(o => o.Pizzas).SelectMany(o => o.Pizzas).AsEnumerable().GroupBy(p => p.PizzaType).ToList();
            foreach(var pizzas in listOfTypes)
            {
                var p0 = pizzas.FirstOrDefault();
                if (p0 is not null)
                {
                    Console.WriteLine($"{p0.PizzaType.ToString()} - {pizzas.Count()}");
                }
            }

            context.State = PizzaBox.Client.Singletons.StateSingleton.Instance.GetState<StoreSelectedState>();
        }
    }
}