using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
namespace DeliveryApp.UnitTests;

public class OrderStatusTest
{
    private MenuItem cake;
    private MenuItem iceCream;
    private List<MenuItem> items;
    private OrderBuilder builder;
    private OrderCompletion order_completion;
    private Order order;
    private OrderStatusService service;
    public OrderStatusTest()
    {
        cake = new MenuItem("Торт", "Шоколадный торт", 300.00m, 10);
        iceCream = new MenuItem("Мороженое", "Ванильное", 150.00m, 5);
        items = new List<MenuItem>() { cake, iceCream };
        builder = new OrderBuilder();
        order_completion = builder.AddMenuItems(items).AddExtraSauce().AddExtraSpice().Build();

        order = new StandardOrderFactory(45, order_completion).PlanCreation();
        service = new OrderStatusService(order);
    }
    [Fact]
    public void OrderStatusService_SetState_SetSuccess()
    {
        IOrderState state = new WaitingCourierState();
        service.SetState(state);
        Assert.Equal("Prepared and waiting for the courier", order.Status);
    }

    [Fact]
    public void  OrderStatusService_Cycle_FinalStageReached()
    {
        service.NextState();
        service.NextState();
        service.NextState();
        service.NextState();
        Assert.Equal("Delivered", order.Status);

    }
}
