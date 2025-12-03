using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

public abstract class OrderFactory //factory method
{
    public int Id { get; set; }
    public List<MenuItem> Products { get; set; }
    public abstract Order CreateOrder();

    // Шаблонный метод
    public Order PlanCreation()
    {
        var order = CreateOrder();
        return order;
    }
    public OrderFactory(int id, List<MenuItem> products) { Id = id; Products = products; }
}

public class StandardOrderFactory : OrderFactory
{
    public override Order CreateOrder() => new StandardOrder(Id, Products);
    public StandardOrderFactory(int id, List<MenuItem> products): base(id, products) { }
}

public class ExpressOrderFactory : OrderFactory
{
    public override Order CreateOrder() => new StandardOrder(Id, Products);
    public ExpressOrderFactory(int id, List<MenuItem> products) : base(id, products) { }
}

public class SpecialOrderFactory : OrderFactory
{
    public override Order CreateOrder() => new StandardOrder(Id, Products);
    public SpecialOrderFactory(int id, List<MenuItem> products) : base(id, products) { }
}
