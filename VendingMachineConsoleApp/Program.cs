//
class MyProgram
{
    private static string user_type;

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<Product> products = new List<Product>();
        bool shouldContinue = true;
        Random random = new Random();

        for (int i = 0; i < 20; i++) // Создаем продукты (в машине не больше 20 ячеек для товаров (в каждой ячейке до 5 товаров))
        {
            string food_emoji = Product.Food[random.Next(Product.Food.Length)];
            int id = i + 1;
            int quantity = random.Next(1, 5);
            decimal price = random.Next(20, 50);

            Product product = new Product(id, food_emoji, price, quantity);
            products.Add(product);
        }

        while (shouldContinue)
        {
            Console.WriteLine("Выберите пользователя (клиент/администратор): "); // Выбор роли
            string user_type = Console.ReadLine();
            if (user_type != "клиент" && user_type != "администратор")
            {
                Console.WriteLine("Некорректный ввод");
            }
            else if (user_type == "клиент")
            {   // Ветка клиента (выбор, покупка продукта и тд)
                UserSelectProductUI user = new UserSelectProductUI(products);
                bool flag = true;
                while (flag)
                {
                    UserSelectProductUI.PrintVendingMachine(products); // Показываем продукты
                    Product selected_product = user.SelectProduct();
                    if (selected_product != null)
                    {
                        decimal sum = CoinPay.AcceptGiveCoins(selected_product);
                        if (sum > 0)
                        {
                            MoneyCollector.AddCoin(sum);
                        }
                    }
                    Console.WriteLine("Выйти из клиентского режима (д/н или другая кнопка)");
                    string answer = Console.ReadLine();
                    if (answer == "д")
                    {
                        flag = false;
                        Console.WriteLine("Вы вышли из клиентского режима");
                    }
                    else { flag = true; }
                }
                
            }
            else if (user_type == "администратор") // Ветка администратора
            {
                Console.WriteLine("Введите код доступа: ");// Проверяем администратора
                string input_password = Console.ReadLine();
                AdministratorUser? admin = AdministratorUser.Create(input_password);
                if (admin != null)
                {
                    bool flag = true;
                    while (flag)
                    {
                        Console.WriteLine("Выберите действие: Пополнить ассортимент (0), сбор собранных средств (1)");
                        string action = Console.ReadLine(); // Выбираем действие администратора
                        if (action == "0")
                        {
                            UserSelectProductUI.PrintVendingMachine(products);
                            bool cont = true;
                            while (cont)
                            {
                                Console.WriteLine("Выберите Id товара: ");
                                string fill_id = Console.ReadLine();

                                if (int.TryParse(fill_id, out int Id))
                                {
                                    bool found = false;
                                    for (int i = 0; i < products.Count; i++) // Находим нужный продукт
                                    {
                                        if (products[i].Id == Id)
                                        {
                                            admin.RefillProduct(products[i]); // Пополняем его
                                            found = true;
                                            cont = false;
                                        }
                                    }
                                    if (!found) { Console.WriteLine("Был введен неверный Id"); }
                                }
                                else
                                {
                                    Console.WriteLine("Был введен неверный Id");
                                }
                            }
                        }
                        else if (action == "1")
                        {
                            MoneyCollector.GetTotal(); // Забираем деньги
                        }
                        Console.WriteLine("Выйти из администраторского режима (д/н или другая кнопка)");
                        string answer = Console.ReadLine();
                        if (answer == "д")
                        {
                            flag = false;
                            Console.WriteLine("Вы вышли из администраторского режима");
                        }
                        else { flag = true; }
                    }
                }
            }
            Console.WriteLine("Завершить работу (д/н или другая кнопка)");
            string answer_2 = Console.ReadLine();
            if (answer_2 == "д")
            {
                shouldContinue = false;
                Console.WriteLine("Вы завершили работу");
            }
            else { shouldContinue = true; }
        }
    }
}
