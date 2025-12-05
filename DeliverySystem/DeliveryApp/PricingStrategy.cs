using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPricingStrategy
{
    void SetPrice(Order order, int deliveryTime);
    decimal GetPrice();
}
public class StandardPricing : IPricingStrategy
{
    private decimal TotalPrice = 0;
    private const decimal TaxRate = 0.20m;
    public void SetPrice(Order order, int deliveryTime)
    {
        foreach (MenuItem item in order.OrderCompletion.MenuItems)
        {
            TotalPrice += item.Price;
        }
        TotalPrice += (deliveryTime * order.DeliveryTimeCoeff);
        TotalPrice += TotalPrice * TaxRate;
    }
    public decimal GetPrice()
        { return TotalPrice; }

}
public class ExpressPricing : IPricingStrategy
{
    private decimal TotalPrice = 0;
    private const decimal TaxRate = 0.20m;
    public void SetPrice(Order order, int deliveryTime)
    {
        foreach (MenuItem item in order.OrderCompletion.MenuItems)
        {
            TotalPrice += item.Price;
        }
        TotalPrice += (deliveryTime * order.DeliveryTimeCoeff);
        TotalPrice += TotalPrice * TaxRate * 1.05m;
    }
    public decimal GetPrice()
    { return TotalPrice; }

}
public class BarterPricing : IPricingStrategy
{
    private decimal TotalPrice = 0;
    public void SetPrice(Order order, int deliveryTime)
    {
    }
    public decimal GetPrice()
    { return TotalPrice; }
}

