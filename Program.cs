using System;
using System.Collections.Generic;
using System.Linq;
using Sharprompt;
namespace buy_sell
{
    class Program
    {
        static void Main(string[] args)
        {

            ICoin[] commodities = {
                new Coin("ETH"),
                new Coin("BTC"),
                new Coin("SOL"),
                new Coin("XRP"),
                new Coin("DOG")
            };

            Person person = CreatePlayer();
            Console.WriteLine($"Welcome to the DWE Exchange {person.Name}\n");
            Console.WriteLine("TICKER: Show prices");
            Console.WriteLine("LIST: List owned inventory");
            Console.WriteLine("BALANCE: Show current balance");
            Console.WriteLine("BUY: Buy crypto");
            Console.WriteLine("SELL: Sell crypto");
            Console.WriteLine("END: End turn\n");

            int round = 1;

            // TODO create random events in-between goes
            while (true)
            {
                // Create a turn and show menu and take input
                // trigger event to make price changes
                string input = Prompt.Select("Select your option", new[] {
                    "TICKER",
                    "LIST",
                    "BALANCE",
                    "BUY",
                    "SELL",
                    "END"
                    });

                switch (input)
                {
                    case "TICKER":
                        ListCommodities(commodities);
                        break;
                    case "LIST":
                        ListInventory(person);
                        break;
                    case "BUY":
                        Buy(person, commodities);
                        break;
                    case "BALANCE":
                        ShowBalance(person);
                        break;
                    case "SELL":
                        Sell(person);
                        break;

                    case "END":
                        round++;
                        NewRound(commodities, person, round);
                        break;

                }

            }


            static void ListCommodities(ICoin[] commodities)
            {
                for (int i = 0; i < commodities.Length; i++)
                {
                    Console.WriteLine($"{i} - {commodities[i].Name}: £{Math.Round(commodities[i].Price, 2)}");
                }
                Console.ReadLine();
            }


            static Person CreatePlayer()
            {
                Console.WriteLine("\nName?");
                string name = Console.ReadLine();
                return new Person(name);
            }


            static void ListInventory(Person person)
            {
                Dictionary<ICoin, int> inventory = person.GetInventory();
                double portfolioValue = 0.0;

                if (!inventory.Any())
                {
                    Console.WriteLine("\nNo inventory");
                }
                else
                {
                    foreach (KeyValuePair<ICoin, int> item in inventory)
                    {
                        Console.WriteLine($"{item.Value} x {item.Key.Name}: £{Math.Round(item.Key.Price * item.Value, 2)}");
                        portfolioValue += item.Key.Price * item.Value;
                    }
                    Console.WriteLine($"Portfolio Value: £{Math.Round(portfolioValue, 2)}");
                }
            }


            static void Buy(Person person, ICoin[] commodities)
            {
                Dictionary<ICoin, int> buyOrder = new Dictionary<ICoin, int>();

                Console.WriteLine("\nWhat coin do you want to buy...");
                string coin = Prompt.Select("Select your option",
                    // Use Linq to get the name of each coin and convert to an array
                    commodities.Select(x => x.Name).ToArray()
                );
                Console.WriteLine("\nEnter the quantity...");
                int quantity = Convert.ToInt16(Console.ReadLine());
                foreach (ICoin commodity in commodities)
                {
                    if (commodity.Name == coin)
                    {
                        person.Buy(commodity, quantity);
                    }
                }
                Console.ReadLine();

            }


            static void ShowBalance(Person person)
            {
                Console.WriteLine($"{person.Name}'s balance = {Math.Round(person.Balance, 2)}");
                Console.ReadLine();
            }


            static void Sell(Person person)
            {
                Dictionary<ICoin, int> sellOrder = new Dictionary<ICoin, int>();

                if (person.Inventory.Count == 0)
                {
                    Console.WriteLine("Hey punk, you have nothing to sell!");
                }
                else
                {
                    ListInventory(person);
                    Console.WriteLine("What would you like to sell?");
                    string coin = Prompt.Select("Select your option",
                    // Use Linq to get the name of each coin and convert to an array
                    person.GetInventory().Select(x => x.Key.Name).ToArray()
                );
                    Console.WriteLine("How many?");
                    int amount = Convert.ToInt16(Console.ReadLine());

                    // Run through the user's inventory
                    foreach (KeyValuePair<ICoin, int> commodity in person.Inventory)
                    {
                        // Check they own the coin
                        if (commodity.Key.Name == coin)
                        {
                            // Check they own enough
                            if (commodity.Value >= amount)
                            {
                                // Add the coin and the amount to seel to Dictionary
                                sellOrder.Add(commodity.Key, amount);
                            }
                            else
                            {
                                Console.WriteLine($"You do not have that much of {commodity.Key.Name}, try another amount");
                                amount = Convert.ToInt16(Console.ReadLine());
                                sellOrder.Add(commodity.Key, amount);

                            }

                        }
                        else
                        {
                            Console.WriteLine($"You do not own {commodity.Key.Name}");
                        }
                    }
                    person.Sell(sellOrder);
                    ListInventory(person);


                }

            }

            static void NewRound(ICoin[] commodities, Person person, int round)
            {

                person.EndRound();
                if (person.IsAlive())
                {
                    foreach (ICoin coin in commodities)
                    {
                        coin.ChangePrice();
                    }

                    Console.WriteLine($"Round {round}\n");
                    Console.WriteLine($"Your Current NET Worth - £{person.Worth()} || {(person.Worth() > person.StartBalance ? "+" : "-")}£{(person.Worth() - person.StartBalance < 0 ? (Math.Round(person.Worth() - person.StartBalance, 2)) * -1 : Math.Round(person.Worth() - person.StartBalance, 2))}");
                    ListInventory(person);
                    round++;
                }
                else
                {
                    Console.WriteLine($"\nThe Crypto World Has You Now... You Have Lost! You lasted {round} rounds");
                }

            }

        }
    }
}

