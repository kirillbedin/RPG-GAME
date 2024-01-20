using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Добро пожаловать в текстовую RPG \"Дикий Запад\"!");
        Console.WriteLine("Вас зовут Стрелок, и вы приехали в маленький городок Десперадо. Ваша цель - найти злодея Бешеного Боба.");

        int playerHealth = 100;
        int playerAmmo = 10;
        int playerGold = 0;

        string[] weapons = { "Револьвер", "Двуствольный дробовик", "Винтовка", "Кольт", "Томагавк" };
        int[] weaponPrices = { 10, 20, 30, 15, 25 };

        string[] enemies = { "Дикий волк", "Лесной гоблин", "Бандит", "Индеец", "Шериф", "Бешеный Боб" };

        while (playerHealth > 0)
        {
            Console.WriteLine($"\nЗдоровье: {playerHealth}  Патроны: {playerAmmo}  Золото: {playerGold}");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Идти в салун");
            Console.WriteLine("2. Поискать следы Бешеного Боба");
            Console.WriteLine("3. Торговец оружием");
            Console.WriteLine("4. Торговец снаряжением");
            Console.WriteLine("5. Выстрелить из оружия");
            Console.WriteLine("6. Уйти из города");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Вы заходите в салун. Бармен рассказывает вам слухи о местонахождении Бешеного Боба.");
                    Console.WriteLine("Ваши действия: 1. Купить напиток  2. Узнать подробности о Бешеном Бобе");
                    int saloonChoice;
                    if (!int.TryParse(Console.ReadLine(), out saloonChoice))
                    {
                        Console.WriteLine("Неверный ввод. Попробуйте снова.");
                        continue;
                    }

                    if (saloonChoice == 1)
                    {
                        Console.WriteLine("Вы купили напиток и укрепили свое здоровье.");
                        playerHealth += 20;
                    }
                    else if (saloonChoice == 2)
                    {
                        Console.WriteLine("Бармен говорит, что слышал, будто Бешеный Боб скрывается в старой шахте на окраине города.");
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    }
                    break;

                case 2:
                    Console.WriteLine("Вы ищете следы Бешеного Боба вокруг города.");
                    int searchResult = new Random().Next(1, 4);
                    if (searchResult == 1)
                    {
                        Console.WriteLine("Вы нашли следы! Бешеный Боб может быть рядом.");
                    }
                    else
                    {
                        Console.WriteLine("Вы не нашли ничего подозрительного.");
                    }
                    break;

                case 3:
                    Console.WriteLine("Торговец оружием предлагает следующее:");
                    for (int i = 0; i < weapons.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {weapons[i]} - {weaponPrices[i]} золота");
                    }

                    Console.WriteLine("Выберите оружие для покупки (или 0 для выхода):");
                    int weaponChoice;
                    if (!int.TryParse(Console.ReadLine(), out weaponChoice) || weaponChoice < 0 || weaponChoice > weapons.Length)
                    {
                        Console.WriteLine("Неверный ввод. Попробуйте снова.");
                        continue;
                    }

                    if (weaponChoice == 0)
                    {
                        Console.WriteLine("Вы решаете не покупать оружие.");
                    }
                    else if (playerGold >= weaponPrices[weaponChoice - 1])
                    {
                        Console.WriteLine($"Вы купили {weapons[weaponChoice - 1]} за {weaponPrices[weaponChoice - 1]} золота.");
                        playerGold -= weaponPrices[weaponChoice - 1];
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно золота.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Торговец снаряжением предлагает следующее:");
                    Console.WriteLine("1. Аптечка - 10 золота");
                    Console.WriteLine("2. Колчан с патронами - 15 золота");

                    int equipmentChoice;
                    if (!int.TryParse(Console.ReadLine(), out equipmentChoice))
                    {
                        Console.WriteLine("Неверный ввод. Попробуйте снова.");
                        continue;
                    }

                    switch (equipmentChoice)
                    {
                        case 1:
                            Console.WriteLine("Вы купили аптечку за 10 золота.");
                            playerGold -= 10;
                            playerHealth += 30;
                            Console.WriteLine("Аптечка восстановила ваше здоровье.");
                            break;
                        case 2:
                            Console.WriteLine("Вы купили колчан с патронами за 15 золота.");
                            playerGold -= 15;
                            playerAmmo += 10;
                            Console.WriteLine("Теперь у вас больше патронов.");
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                    break;

                case 5:
                    Console.WriteLine("Вы решаете выстрелить из оружия.");
                    if (playerAmmo > 0)
                    {
                        Console.WriteLine("Ваш выстрел раздается по городу.");
                        playerAmmo--;
                        int damageDealt = new Random().Next(10, 20);
                        Console.WriteLine($"Вы нанесли {damageDealt} урона!");
                    }
                    else
                    {
                        Console.WriteLine("У вас нет патронов. Попробуйте купить их в салуне или у торговца.");
                    }
                    break;

                case 6:
                    Console.WriteLine("Вы покидаете город Десперадо. Ваше приключение продолжается!");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }

            // Воздействие на здоровье игрока в конце каждого хода
            if (playerHealth <= 0)
            {
                Console.WriteLine("Вы погибли в беспощадном мире Дикого Запада.");
            }
            else if (playerHealth < 50)
            {
                Console.WriteLine("Ваше здоровье низкое. Будьте осторожны!");
            }

            // Враги могут атаковать случайным образом
            if (new Random().Next(1, 5) == 1)
            {
                Console.WriteLine($"Вас атакует {enemies[new Random().Next(enemies.Length)]}!");
                int enemyDamage = new Random().Next(10, 15);
                playerHealth -= enemyDamage;
                Console.WriteLine($"Вы получили {enemyDamage} урона от врага!");
            }

            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();
            Console.Clear();
        }

        Console.WriteLine("Игра окончена. Спасибо за игру!");
    }
}
