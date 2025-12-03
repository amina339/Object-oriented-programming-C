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
    public abstract OrderType CreateOrder();

    // Шаблонный метод
    public OrderType PlanCreation()
    {
        var order = CreateOrder();
        return order;
    }
    public OrderFactory(int id, OrderCompletion orderCompletion) { Id = id; OrderCompletion = orderCompletion; }
}

public class StandardOrderFactory : OrderFactory
{
    public override OrderType CreateOrder() => new StandardOrder(Id, OrderCompletion);
    public StandardOrderFactory(int id, OrderCompletion orderCompletion) : base(id, orderCompletion) { }
}

public class ExpressOrderFactory : OrderFactory
{
    public override OrderType CreateOrder() => new StandardOrder(Id, OrderCompletion);
    public ExpressOrderFactory(int id, OrderCompletion orderCompletion) : base(id, orderCompletion) { }
}

public class SpecialOrderFactory : OrderFactory
{
    public override OrderType CreateOrder() => new StandardOrder(Id, OrderCompletion);
    public SpecialOrderFactory(int id, OrderCompletion orderCompletion) : base(id, orderCompletion) { }
}
