namespace DeliveryApp.UnitTests;

public class MenuCategoryTests
{
    [Fact]
    public void MenuCategory_Add_AddsComponentSuccessfully()
    {
        var category = new MenuCategory("Супы", "Горячие супы");
        var soup = new MenuItem("Борщ", "Красный борщ", 250.00m, 20);

        category.Add(soup);

        Assert.Contains(soup, category.Dishes);
    }

    [Fact]
    public void MenuCategory_Remove_RemovesComponentSuccessfully()
    {
        var category = new MenuCategory("Десерты", "Сладкие десерты");
        var cake = new MenuItem("Торт", "Шоколадный торт", 300.00m, 10);
        var iceCream = new MenuItem("Мороженое", "Ванильное", 150.00m, 5);

        category.Add(cake);
        category.Add(iceCream);

        category.Remove(cake);

        Assert.DoesNotContain(cake, category.Dishes);
    }
}
