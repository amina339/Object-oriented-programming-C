using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PricingContext
{
    private IPricingStrategy _strategy;

    public PricingContext(IPricingStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IPricingStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal CountPrice(Order order, int deliveryTime)
    {
        _strategy.SetPrice(order, deliveryTime);
        return _strategy.GetPrice();
    }
}
