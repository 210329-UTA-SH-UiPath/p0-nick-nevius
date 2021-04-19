using System.Linq;

namespace PizzaBox.Storing.Mappers
{
    public class CustomerMapper : IMapper<PizzaBox.Storing.Entities.Customer, PizzaBox.Domain.Models.Customer>
    {
        public Domain.Models.Customer Map(Entities.Customer model)
        {
            Domain.Models.Customer cust = new Domain.Models.Customer(model.Name);
            cust.ID = model.ID;
            return cust;
        }

        public Entities.Customer Map(Domain.Models.Customer model, Entities.AnimalsDbContext context)
        {
            var dbCustomer = context.Customers.FirstOrDefault(c => c.Name.Equals(model.Name));
            if (dbCustomer is not null)
            {
                return dbCustomer;
            }

            Entities.Customer customer = new Entities.Customer();
            customer.Name = model.Name;
            return customer;
        }
    }
}