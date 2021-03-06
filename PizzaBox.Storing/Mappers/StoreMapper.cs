using PizzaBox.Storing.Entities;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System;
using System.Linq;

namespace PizzaBox.Storing.Mappers
{
    public class StoreMapper : IMapper<Store, AStore>
    {
        public AStore Map(Store model)
        {
            AStore aStore = null;
            switch(model.StoreType)
            {
                case STORE_TYPE.Chicago:
                    aStore = new ChicagoStore();
                    break;
                case STORE_TYPE.NewYork:
                    aStore = new NewYorkStore();
                    break;
                case STORE_TYPE.Unknown:
                    // TODO: add logging to these last 2
                default:
                    throw new ArgumentException("Store mapper is attempting to map a store type that does not exist in the codebase");
            }
            aStore.Name = model.Name;
            aStore.ID = model.ID;
            return aStore;
        }

        public Store Map(AStore model, Entities.AnimalsDbContext context)
        {
            if (model.ID != -1)
            {
                var dbStore = context.Stores.FirstOrDefault(s => s.ID == model.ID);
                if (dbStore is not null)
                {
                    return dbStore;
                }
            }

            STORE_TYPE storeType;
            switch(model)
            {
                case ChicagoStore:
                    storeType = STORE_TYPE.Chicago;
                    break;
                case NewYorkStore:
                    storeType = STORE_TYPE.NewYork;
                    break;
                default:
                    throw new ArgumentException("Store mapper is attempting to map a store instance that does not exist in the database");
            }
            Store store = new Store();
            store.Name = model.Name;
            store.StoreType = storeType;
            return store;
        }
    }
}