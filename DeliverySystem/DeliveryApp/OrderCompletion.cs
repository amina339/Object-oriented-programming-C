using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OrderCompletion //FluentBuilder
{
    public bool _hasExtraSauce { get; }
    public bool _hasExtraSpice { get; }
    public bool _hasExtraCultre { get; }
    public List<MenuItem> MenuItems { get; }

    public OrderCompletion(bool hasExtraSauce, bool hasExtraSpice, bool hasExtraCultre, List<MenuItem> menuItems)
    {
        _hasExtraSauce = hasExtraSauce;
        _hasExtraSpice = hasExtraSpice;
        _hasExtraCultre = hasExtraCultre;
        MenuItems = menuItems;
    }
}
public interface IOrderCompletionBuilder
{
    IOrderCompletionBuilder AddExtraSauce();
    IOrderCompletionBuilder AddExtraSpice();
    IOrderCompletionBuilder AddExtraCultre();
    IOrderCompletionBuilder AddMenuItems(List<MenuItem> menuItems);  
    OrderCompletion Build();
}
public class OrderBuilder : IOrderCompletionBuilder
{
    private bool _hasExtraSauce;
    private bool _hasExtraSpice;
    private bool _hasExtraCultre;
    private List<MenuItem> MenuItems;

    public IOrderCompletionBuilder AddExtraSauce()
    {
        _hasExtraSauce = true;
        return this;
    }
    public IOrderCompletionBuilder AddExtraSpice()
    {
        _hasExtraSpice = true;
        return this; 
    }
    public IOrderCompletionBuilder AddExtraCultre()
    {
        _hasExtraCultre = true;
        return this;
    }

    public IOrderCompletionBuilder AddMenuItems(List<MenuItem> menuItems)
    {
        MenuItems = menuItems;
        return this;
    }
    public OrderCompletion Build()
    {
        return new OrderCompletion(_hasExtraSauce, _hasExtraSpice, _hasExtraCultre, MenuItems);
    }
}