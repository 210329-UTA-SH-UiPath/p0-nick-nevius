using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  /// <summary>
  /// 
  /// </summary>
  public class StoreTests
  {
    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_ChicagoStoreName()
    {
      // arrange
      var sut = new ChicagoStore();

      // act
      var actual = sut.Name;

      // assert
      Assert.True(actual == "ChicagoStore");
    }
      [Fact]
    public void Test_NewYorkStoreName()
    {
      // arrange
      var sut = new NewYorkStore();

      // act
      var actual = sut.Name;

      // assert
      Assert.True(actual == "NewYorkStore");
    }
  }
}
