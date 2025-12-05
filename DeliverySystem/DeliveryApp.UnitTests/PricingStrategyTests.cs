using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.UnitTests;

public class PricingStrategyTest
{
    private MenuItem cake;
    private MenuItem iceCream;
    private List<MenuItem> items;
    private OrderBuilder builder;
    private OrderCompletion order_completion;
    private Order order;
    public PricingStrategyTest()
    {
        cake = new MenuItem("Торт", "Шоколадный торт", 300.00m, 10);
        iceCream = new MenuItem("Мороженое", "Ванильное", 150.00m, 5);
        items = new List<MenuItem>() { cake, iceCream };
        builder = new OrderBuilder();
        order_completion = builder.AddMenuItems(items).AddExtraSauce().AddExtraSpice().Build();

        order = new StandardOrderFactory(45, order_completion).PlanCreation();
    }
    [Fact]
    public void StandardPrice_Price_IsStandard()
    {
        PricingContext pricing = new PricingContext(new StandardPricing());
        decimal actual_price = pricing.CountPrice(order, 15);
        decimal expected_price = 558.9000m;
        Assert.Equal(expected_price, actual_price);
    }
    [Fact]
    public void ExpressPrice_Price_IsExpress()
    {
        PricingContext pricing = new PricingContext(new ExpressPricing());
        decimal actual_price = pricing.CountPrice(order, 15);
        decimal expected_price = 563.557500m;
        Assert.Equal(expected_price, actual_price);
    }
    [Fact]
    public void BarterPrice_Price_IsBarter()
    {
        PricingContext pricing = new PricingContext(new BarterPricing());
        decimal actual_price = pricing.CountPrice(order, 15);
        decimal expected_price = 0;
        Assert.Equal(expected_price, actual_price);
    }
} 
