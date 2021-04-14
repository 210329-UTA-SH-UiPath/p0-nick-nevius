using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  /// <summary>
  /// 
  /// </summary>
  public class OrderTests
  {
    [Fact]
    public void Test_OrderTimePlaced()
    {
      // arrange
      var sut = new Order();

      // act
      var actual = sut.TimePlaced;

      // assert
      Assert.NotNull(actual);
    }
    [Fact]
    public void Test_OrderPizzas()
    {
      // arrange
      var sut = new Order();

      // act
      var actual = sut.Pizzas;

      // assert
      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_OrderPrice()
    {
      // arrange
      var sut = new Order();
      sut.Pizzas.Add(new MeatPizza());
      sut.Pizzas.Add(new VeganPizza());

      // act
      var actual = sut.Price;
      var total = 0.0m;
      sut.Pizzas.ForEach(pizza => total += pizza.Price);

      // assert
      Assert.Equal(actual, total);
    }


  }
}