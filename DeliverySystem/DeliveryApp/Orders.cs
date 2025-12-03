using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Order
{
    public int Id { get; set; }
    public List<MenuItem> Products { get; set; }
    public int DeliveryTime { get; set; } = 25;
    protected decimal Price { get; set;}
    public Order(int id, List<MenuItem> products)
    {
        Id = id;
        Products = products;
    }
    public virtual void SetPrice()
    {
        foreach (MenuItem item in Products)
        {
            Price = Price + item.Price;
        }
        Price = Price + DeliveryTime * 5;
    }
    public virtual decimal GetPrice() { return Price; }
}

public class StandardOrder: Order
{
    public StandardOrder(int id, List<MenuItem> products) : base(id, products)
    {
    }
}

public class ExpressOrder: Order
{
    public ExpressOrder(int id, List<MenuItem> products) : base(id, products)
    {
        DeliveryTime = 15;
    }
    public override void SetPrice()
    {
        foreach (MenuItem item in Products)
        {
            Price = Price + item.Price;
        }
        Price = Price + DeliveryTime * 30;
    }
}
public class BarterOrder : Order
{
    public BarterOrder(int id, List<MenuItem> products) : base(id, products)
    {
    }
    public override void SetPrice()
    {
        Price = 0;
    }
}
