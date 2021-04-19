using System.Xml.Serialization;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class ASellable
    {
        public abstract decimal Price { get; set; }
        public int ID { get; set; }
        public ASellable()
        {
            ID = -1;
        }
    }
}
