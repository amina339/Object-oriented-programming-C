using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DeliveryApp.UnitTests;

public class OrderFactoryTest
{
    private MenuItem cake;
    private MenuItem iceCream;
    private List<MenuItem> items;
    private OrderBuilder builder;
    private OrderCompletion order_completion;
    private Order order;

    public OrderFactoryTest()
    {
        cake = new MenuItem("Торт", "Шоколадный торт", 300.00m, 10);
        iceCream = new MenuItem("Мороженое", "Ванильное", 150.00m, 5);
        items = new List<MenuItem>() { cake, iceCream };
        builder = new OrderBuilder();
        order_completion = builder.AddMenuItems(items).AddExtraSauce().AddExtraSpice().Build();

        order = new StandardOrderFactory(45, order_completion).PlanCreation();
    }
        
    [Fact]
    public void PlainCreation_Order_CreatesOrderSuccessfuly()
    {
        Assert.NotNull(order);
    }
    [Fact]
    public void PlainCreation_Order_InitialStatusCreated()
    {
        Assert.Equal("Created", order.Status);
    }
}


