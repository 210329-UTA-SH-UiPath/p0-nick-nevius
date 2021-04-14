using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  /// <summary>
  /// 
  /// </summary>
  public class CustomerTests
  {
    [Fact]
    public void Test_CustomerName()
    {
      // arrange
      var sut = new Customer("Input1");

      // act
      var actual = sut.Name;

      // assert
      Assert.Equal(actual, "Input1");
    }
    [Fact]
    public void Test_CustomerToString()
    {
      // arrange
      var sut = new Customer("Input1");

      // act
      var actual = sut.ToString();

      // assert
      Assert.Equal(actual, "Input1");
    }
  }
}