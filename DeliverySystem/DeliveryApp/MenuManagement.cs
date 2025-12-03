using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public abstract class MenuComponent //composite - hierarchy of the menu for administrators
{
    public string Name { get; set; }
    public string Description { get; set; }
    public MenuComponent(string name, string description)
    {
        Name = name;
        Description = description;
    }

}

public class MenuCategory : MenuComponent
{
    private List<MenuComponent> _dishes = new List<MenuComponent>();
    public IEnumerable<MenuComponent> GetDishes() => _dishes.AsReadOnly();

    public void Add(MenuComponent component) => _dishes.Add(component);
    public void Remove(MenuComponent component) => _dishes.Remove(component);
    public MenuCategory(string name, string description) : base(name, description) { }
}
public class MenuItem : MenuComponent
{
    public decimal Price { get; set; }
    public int PreparatoryTime { get; set; }
    public MenuItem(string name, string description, decimal price, int preparatoryTime) : base(name, description)
    {
        Price = price;
        PreparatoryTime = preparatoryTime;
    }
}


