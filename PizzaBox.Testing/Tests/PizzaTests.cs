using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaTests
  {
    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_VeganPizzaCrust()
    {
      // arrange
      var sut = new VeganPizza();

      // act
      var actual = sut.Crust;

      // assert
      Assert.NotNull(sut.Crust);
    }

    [Fact]
    public void Test_MeatCrust()
    {
      // arrange
      var sut = new MeatPizza();

      // act
      var actual = sut.Crust;

      // assert
      Assert.NotNull(sut.Crust);
    }

    [Fact]
    public void Test_CustomPizzaCrust()
    {
      // arrange
      var sut = new CustomPizza();

      // act
      var actual = sut.Crust;

      // assert
      Assert.Null(sut.Crust);
    }



   [Fact]
    public void Test_VeganPizzaSize()
    {
      // arrange
      var sut = new VeganPizza();

      // act
      var actual = sut.Size;

      // assert
      Assert.NotNull(actual);
    }

       [Fact]
    public void Test_MeatPizzaSize()
    {
      // arrange
      var sut = new MeatPizza();

      // act
      var actual = sut.Size;

      // assert
      Assert.NotNull(actual);
    }

     [Fact]
    public void Test_CustomPizzaSize()
    {
      // arrange
      var sut = new CustomPizza();

      // act
      var actual = sut.Size;

      // assert
      Assert.Null(actual);
    }

   [Fact]
    public void Test_VeganPizzaToppings()
    {
      // arrange
      var sut = new VeganPizza();

      // act
      var actual = sut.Toppings;

      // assert
      Assert.NotNull(actual);
    }

   [Fact]
    public void Test_MeatPizzaToppings()
    {
      // arrange
      var sut = new MeatPizza();

      // act
      var actual = sut.Toppings;

      // assert
      Assert.NotNull(actual);
    }

       [Fact]
    public void Test_CustomPizzaToppings()
    {
      // arrange
      var sut = new CustomPizza();

      // act
      var actual = sut.Toppings;

      // assert
      Assert.NotNull(actual);
    }


    [Fact]
    public void Test_MeatPizzaPrice()
    {
      // arrange
      var sut = new MeatPizza();

      // act
      var actual = sut.Price;

      var total = sut.Crust.Price + sut.Size.Price;
      sut.Toppings.ForEach(topping => total += topping.Price);

      // assert
      Assert.Equal(actual, total);
    }

    [Fact]
    public void Test_VeganPizzaPrice()
    {
      // arrange
      var sut = new VeganPizza();

      // act
      var actual = sut.Price;

      var total = sut.Crust.Price + sut.Size.Price;
      sut.Toppings.ForEach(topping => total += topping.Price);

      // assert
      Assert.Equal(actual, total);
    }

    [Fact]
    public void Test_CustomPizzaPrice()
    {
      // arrange
      var sut = new CustomPizza();
      sut.Crust = new DeepDishCrust();
      sut.Size = new LargeSize();
      sut.Toppings.Add(new BaconTopping());
      sut.Toppings.Add(new OnionTopping());

      // act
      var actual = sut.Price;

      var total = sut.Crust.Price + sut.Size.Price;
      sut.Toppings.ForEach(topping => total += topping.Price);

      // assert
      Assert.Equal(actual, total);
    }



  }
}
