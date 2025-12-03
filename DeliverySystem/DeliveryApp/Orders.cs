using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class OrderType
{
    public int Id { get; set; }
    public OrderCompletion OrderCompletion { get; set; } 
    protected float DeliveryTimeCoeff { get; set; } = 1.05f;
    public OrderType(int id, OrderCompletion orderCompletion)
    {
        Id = id;
        OrderCompletion = orderCompletion;
    }
}

public class StandardOrder: OrderType
{
    public StandardOrder(int id, OrderCompletion orderCompletion) : base(id, orderCompletion)
    {
    }
}

public class ExpressOrder: OrderType
{
    public ExpressOrder(int id, OrderCompletion orderCompletion) : base(id, orderCompletion)
    {
        DeliveryTimeCoeff = 1.15f;
    }
}
public class BarterOrder : OrderType
{
    public BarterOrder(int id, OrderCompletion orderCompletion) : base(id, orderCompletion)
    {
        DeliveryTimeCoeff = 0f;
    }

}
