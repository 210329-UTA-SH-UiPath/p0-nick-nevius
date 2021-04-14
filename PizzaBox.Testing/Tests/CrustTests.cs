using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  /// <summary>
  /// 
  /// </summary>
  public class CrustTests
  {
    [Fact]
    public void Test_CheeseStuffedCrustName()
    {
      // arrange
      var sut = new CheeseStuffedCrust();

      // act
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "Cheese Stuffed Crust");
    }
        [Fact]
    public void Test_CheeseStuffedCrustPrice()
    {
      // arrange
      var sut = new CheeseStuffedCrust();

      // act
      var actual = sut.Price;

      // assert
      Assert.Equal(actual, 1.5m);
    }
        [Fact]
    public void Test_DeepDishCrustName()
    {
      // arrange
      var sut = new DeepDishCrust();

      // act
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "Deep Dish Crust");
    }
        [Fact]
    public void Test_DeepDishCrustPrice()
    {
      // arrange
      var sut = new DeepDishCrust();

      // act
      var actual = sut.Price;

      // assert
      Assert.Equal(actual, 1.5m);
    }
        [Fact]
    public void Test_TraditionalCrustName()
    {
      // arrange
      var sut = new TraditionalCrust();

      // act
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "Traditional Crust");
    }
        [Fact]
    public void Test_TraditionalCrustPrice()
    {
      // arrange
      var sut = new TraditionalCrust();

      // act
      var actual = sut.Price;

      // assert
      Assert.Equal(actual, 1.0m);
    }

  }

}