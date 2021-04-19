using System;
using PizzaBox.Domain.Models;
using System.Linq;

namespace PizzaBox.Storing.Mappers
{
    public class CrustMapper : IMapper<PizzaBox.Storing.Entities.Crust, PizzaBox.Domain.Models.Crust>
    {
        public Domain.Models.Crust Map(Entities.Crust model)
        {
            Domain.Models.Crust crust = null;
            switch (model.CrustType)
            {
                case Entities.CRUST_TYPE.CheeseStuffed:
                    crust = new CheeseStuffedCrust();
                    break;
                case Entities.CRUST_TYPE.DeepDish:
                    crust = new DeepDishCrust();
                    break;
                case Entities.CRUST_TYPE.Traditional:
                    crust = new TraditionalCrust();
                    break;
                case Entities.CRUST_TYPE.Unknown:
                // TODO: add logging to these last 2
                default:
                    throw new ArgumentException("CrustMapper ran into an unknown Crust Type when mapping from DB Model to Domain Model");
            }
            crust.Price = model.Price;
            crust.ID = model.ID;
            return crust;
        }

        public Entities.Crust Map(Domain.Models.Crust model, Entities.AnimalsDbContext context)
        {
            Entities.CRUST_TYPE crustType;
            switch (model)
            {
                case CheeseStuffedCrust:
                    crustType = Entities.CRUST_TYPE.CheeseStuffed;
                    break;
                case DeepDishCrust:
                    crustType = Entities.CRUST_TYPE.DeepDish;
                    break;
                case TraditionalCrust:
                    crustType = Entities.CRUST_TYPE.Traditional;
                    break;
                default:
                    throw new ArgumentException("CrustMapper ran into an unknown type of crust when mapping from Domain Model to DB Model");
            }

            var dbCrust = context.Crusts.FirstOrDefault(c => c.CrustType == crustType);
            if (dbCrust is not null)
            {
                return dbCrust;
            }

            Entities.Crust crust = new Entities.Crust();
            crust.CrustType = crustType;
            crust.Price = model.Price;
            return crust;
        }
    }
}