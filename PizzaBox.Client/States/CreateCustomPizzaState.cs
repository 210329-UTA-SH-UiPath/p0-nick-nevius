using PizzaBox.Client.Contexts;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using System;

namespace PizzaBox.Client.States
{

    public class CreateCustomPizzaState : AState
    {
        private APizza currentPizza = null;

        private void SelectSize(Context context)
        {
            var index = 0;
            SizeSingleton.Instance.Sizes.ForEach(size =>
                Console.WriteLine($"{++index} - {size} - {size.Price}"));
            var input = 0;
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                }
            } while (input <= 0 || input > SizeSingleton.Instance.Sizes.Count);

            currentPizza.Size = SizeSingleton.Instance.Sizes[input - 1];
        }

        private void SelectCrust(Context context)
        {
            var index = 0;
            CrustSingleton.Instance.Crusts.ForEach(crust =>
                Console.WriteLine($"{++index} - {crust} - {crust.Price}"));
            var input = 0;
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                }
            } while (input <= 0 || input > CrustSingleton.Instance.Crusts.Count);

            currentPizza.Crust = CrustSingleton.Instance.Crusts[input - 1];
        }

        private bool AddTopping(Context context)
        {
            var index = 0;
            ToppingSingleton.Instance.Toppings.ForEach(topping =>
                Console.WriteLine($"{++index} - {topping} - {topping.Price}"));
            bool displayDone = currentPizza.Toppings.Count >= 2;
            if (displayDone)
            {
                Console.WriteLine($"{++index} - Done");
            }
            var input = 0;
            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                }
            } while (input <= 0 || input > index);
            if (displayDone && input == index)
            {
                return false;
            }
            currentPizza.Toppings.Add(ToppingSingleton.Instance.Toppings[input - 1]);
            return true;
        }

        private void AddToppings(Context context)
        {
            while (currentPizza.Toppings.Count < 5 && AddTopping(context)) { }
        }


        public override void Handle(Context context)
        {
            currentPizza = context.Order.Pizzas[context.Order.Pizzas.Count - 1];
            SelectSize(context);
            SelectCrust(context);
            AddToppings(context);

            context.State = StateSingleton.Instance.GetState<CheckOrderTotalState>();
        }
    }
}