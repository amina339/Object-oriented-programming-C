using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Order
{
    public int Id { get; set; }
    public OrderCompletion OrderCompletion { get; set; } 
    public string Status { get; set; }
    public decimal DeliveryTimeCoeff { get; set; } = 1.05m;
    public Order(int id, OrderCompletion orderCompletion, string status)
    {
        Id = id;
        OrderCompletion = orderCompletion;
        Status = status;
    }
}

public class StandardOrder: Order
{
    public StandardOrder(int id, OrderCompletion orderCompletion, string status) : base(id, orderCompletion, status)
    {
    }
}

public class ExpressOrder: Order
{
    public ExpressOrder(int id, OrderCompletion orderCompletion, string status) : base(id, orderCompletion, status)
    {
        DeliveryTimeCoeff = 1.15m;
    }
}
public class BarterOrder : Order
{
    public BarterOrder(int id, OrderCompletion orderCompletion, string status) : base(id, orderCompletion, status)
    {
        DeliveryTimeCoeff = 0m;
    }

}
