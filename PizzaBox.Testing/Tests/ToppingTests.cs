using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  /// <summary>
  /// 
  /// </summary>
  public class ToppingTests
  {
    [Fact]
    public void Test_BaconToString()
    {
      // arrange
      var sut = new BaconTopping();

      // act
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "Bacon");
    }
    [Fact]
    public void Test_BaconPrice()
    {
      // arrange
      var sut = new BaconTopping();

      // act
      var actual = sut.Price;

      // assert
      Assert.Equal(actual, 0.5m);
    }

    [Fact]
    public void Test_MushroomToString()
    {
      // arrange
      var sut = new MushroomTopping();

      // act
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "Mushroom");
    }

    [Fact]
    public void Test_MushroomPrice()
    {
      // arrange
      var sut = new MushroomTopping();

      // act
      var actual = sut.Price;

      // assert
      Assert.Equal(actual, 0.6m);
    }
    [Fact]
    public void Test_OnionToString()
    {
      // arrange
      var sut = new OnionTopping();

      // act
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "Onion");
    }
    [Fact]
    public void Test_OnionPrice()
    {
      // arrange
      var sut = new OnionTopping();

      // act
      var actual = sut.Price;

      // assert
      Assert.Equal(actual, 0.45m);
    }
    [Fact]
    public void Test_PepperoniToString()
    {
      // arrange
      var sut = new PepperoniTopping();

      // act
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "Pepperoni");
    }
    [Fact]
    public void Test_PepperoniPrice()
    {
      // arrange
      var sut = new PepperoniTopping();

      // act
      var actual = sut.Price;

      // assert
      Assert.Equal(actual, 0.50m);
    }
  }
}