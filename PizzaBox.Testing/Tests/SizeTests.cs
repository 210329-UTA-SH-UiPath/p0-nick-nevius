using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  /// <summary>
  /// 
  /// </summary>
  public class SizeTests
  {
    [Fact]
    public void Test_MediumSizeName()
    {
      // arrange
      var sut = new MediumSize();

      // act
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "Medium Size");
    }
    [Fact]
    public void Test_MediumSizeToString()
    {
      // arrange
      var sut = new MediumSize();

      // act
      var actual = sut.ToString();

      // assert
      Assert.Equal(actual, "Medium Size");
    }
        [Fact]
    public void Test_MediumSizePrice()
    {
      // arrange
      var sut = new MediumSize();

      // act
      var actual = sut.Price;

      // assert
      Assert.Equal(actual, 4.0m);
    }

    [Fact]
    public void Test_LargeSizeName()
    {
      // arrange
      var sut = new LargeSize();

      // act
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "Large Size");
    }
    [Fact]
    public void Test_LargeSizeToString()
    {
      // arrange
      var sut = new LargeSize();

      // act
      var actual = sut.ToString();

      // assert
      Assert.Equal(actual, "Large Size");
    }
        [Fact]
    public void Test_LargeSizePrice()
    {
      // arrange
      var sut = new LargeSize();

      // act
      var actual = sut.Price;

      // assert
      Assert.Equal(actual, 4.5m);
    }

    [Fact]
    public void Test_SmallSizeName()
    {
      // arrange
      var sut = new SmallSize();

      // act
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "Small Size");
    }
    [Fact]
    public void Test_SmallSizeToString()
    {
      // arrange
      var sut = new SmallSize();

      // act
      var actual = sut.ToString();

      // assert
      Assert.Equal(actual, "Small Size");
    }
        [Fact]
    public void Test_SmallSizePrice()
    {
      // arrange
      var sut = new SmallSize();

      // act
      var actual = sut.Price;

      // assert
      Assert.Equal(actual, 3.0m);
    }
  }
}
