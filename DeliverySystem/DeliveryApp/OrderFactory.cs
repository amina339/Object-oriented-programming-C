using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

public abstract class OrderFactory //factory method
{
    public int Id { get; set; }
    public OrderCompletion OrderCompletion { get; set; }
    public abstract Order CreateOrder();

    // Шаблонный метод
    public Order PlanCreation()
    {
        var order = CreateOrder();
        return order;
    }
    public OrderFactory(int id, OrderCompletion orderCompletion) { Id = id; OrderCompletion = orderCompletion; }
}

public class StandardOrderFactory : OrderFactory
{
    public override Order CreateOrder() => new StandardOrder(Id, OrderCompletion, "Created");
    public StandardOrderFactory(int id, OrderCompletion orderCompletion) : base(id, orderCompletion) { }
}

public class ExpressOrderFactory : OrderFactory
{
    public override Order CreateOrder() => new ExpressOrder(Id, OrderCompletion, "Created");
    public ExpressOrderFactory(int id, OrderCompletion orderCompletion) : base(id, orderCompletion) { }
}

public class SpecialOrderFactory : OrderFactory
{
    public override Order CreateOrder() => new BarterOrder(Id, OrderCompletion, "Created");
    public SpecialOrderFactory(int id, OrderCompletion orderCompletion) : base(id, orderCompletion) { }
}
