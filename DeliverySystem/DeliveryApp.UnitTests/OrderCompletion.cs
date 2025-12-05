namespace DeliveryApp.UnitTests;

public class OrderCompletionTests
{
    [Fact]
    public void OrderBuilder_Build_BuildsSuccessfully()
    {
        var cake = new MenuItem("Торт", "Шоколадный торт", 300.00m, 10);
        var iceCream = new MenuItem("Мороженое", "Ванильное", 150.00m, 5);
        List<MenuItem> items = new List<MenuItem>() { cake, iceCream};
        OrderBuilder builder = new OrderBuilder();
        OrderCompletion order = builder.AddMenuItems(items).AddExtraSauce().AddExtraSpice().Build();
        Assert.Equal(order.MenuItems.Count, items.Count);
        Assert.True(order._hasExtraSauce);
        Assert.True(order._hasExtraSpice);
        Assert.False(order._hasExtraCultre);
    }
}
