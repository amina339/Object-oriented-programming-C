using System.Reflection;
using System.Xml.Linq;

public static class CoinPay
{
    public static decimal AcceptGiveCoins(Product product) // Статический метод для приема и выдачи денег
    {
        decimal price = product.Price;
        Console.WriteLine($"Внесите сумму {product.Price} руб.:");
        decimal[] validCoins = [0.01m, 0.05m, 0.1m, 0.5m, 1, 2, 5, 10];
        decimal sum = 0;

        while (true) // кидаем монеты пока не наберется достаточной суммы
        {
            string input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal coin))
            {
                if (validCoins.Contains(coin)) // Проверяем валидность монет (номиналов)
                {
                    sum += coin;
                    Console.WriteLine($"Вы внесли всего {sum} руб");

                    if (sum >= price)
                    {
                        Console.Write("Осуществить выдачу (д/н): ");
                        string answer = Console.ReadLine();
                        if (answer == "д")
                        {
                            if (product.ReduceProductQuantity()) // Если все хорошо - отдаем продукт
                            {
                                decimal change = sum - price;
                                Console.WriteLine($"🪙 Выдана сдача: {change} руб");
                                return sum;
                            }
                        }
                        else 
                        {
                            Console.WriteLine($"❌ Операция отменена. Заберите {sum} руб"); // Отмена операции и возврат средств
                            return 0;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Нет такой монеты, вставьте другую");
                    Console.WriteLine("Действующие номиналы в руб: 0,01; 0,05; 0,1; 0,5; 1; 2; 5; 10");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
        }
    }

}
