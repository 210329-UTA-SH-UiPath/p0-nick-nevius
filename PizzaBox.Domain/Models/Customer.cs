namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class Customer
  {
    public int ID { get; set; }
    private string _name = null;
    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        _name = value;
      }
    }

    public Customer(string name)
    {
      Name = name;
      ID = -1;
    }

    public override string ToString()
    {
      return $"{Name}";
    }
  
  }
}
