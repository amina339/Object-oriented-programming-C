using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

public class UserSelectProductUI
{
    public List<Product> Products;

    public static void PrintVendingMachine(List<Product> Products) // Красивый вывод продуктов
    {
        var sb = new StringBuilder(); // Полная строка вывода, чтобы продукты выводились сразу

        for (int i = 0; i < Products.Count; i += 4) //шагами по 4, тк в каждом ряду 4 товара
        {
            // Первая строка – эмодзи продукта
            for (int j = i; j < i + 4; j++) // берем такой j, чтобы идти по списку продуктов
            {
                sb.Append($"{Products[j].ProductType,-7}"); // с выравниванием
            }
            sb.AppendLine();

            // Вторая строка – ID
            for (int j = i; j < i + 4; j++)
            {
                sb.Append($"ID {Products[j].Id,-4}");
            }
            sb.AppendLine();

            // Третья строка – цены
            for (int j = i; j < i + 4; j++)
            {
                sb.Append($"Р. {Products[j].Price,-4}");
            }
            sb.AppendLine(); // пустая строка между рядами, чтобы было красиво
        }

        Console.WriteLine(sb.ToString()); // Выводим продукты
    }
    public Product? SelectProduct() // Метод, который может возвратить продукт, а может и нет (нулл)
    {   while (true)
        {
            Console.WriteLine("Выберите Id продукта для приобретения: ");
            string string_Id = Console.ReadLine();

            if (int.TryParse(string_Id, out int Id))
            {
                for (int i = 0; i < Products.Count; i++) // Ищем продукт
                {
                    if (Products[i].Id == Id)
                    {
                        if (Products[i].ChooseProduct())
                        {
                            return Products[i]; 
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("Некорректный ввод.Попробуйте еще раз");
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Попробовать еще раз (д/н):");
                string answer = Console.ReadLine();
                if (answer == "н")
                {
                    return null;
                }
            }
        }
    }
    public UserSelectProductUI(List<Product> products)
    {
    Products = products;
    }
}