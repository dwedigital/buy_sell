﻿using System;
using System.Collections.Generic;
using System.Linq;
using Sharprompt;
namespace buy_sell
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommodity[] commodities = {
                new Commodity(0.45,"ETH",1.8),
                new Commodity(200.50,"BTC",1.2),
                new Commodity(10.33,"SOL",2.5),
                new Commodity(5.47,"XRP",3),
                new Commodity(0.45,"DOG",5),
                new Commodity(0.22,"SHIB",5)
            };

            Person person = CreatePlayer();
            Console.WriteLine($"Welcome to the DWE Exchange {person.Name}\n");
            Console.WriteLine("TICKER: Show prices");
            Console.WriteLine("LIST: List owned inventory");
            Console.WriteLine("BALANCE: Show current balance");
            Console.WriteLine("BUY: Buy crypto");
            Console.WriteLine("SELL: Sell crypto");
            Console.WriteLine("END: End turn\n");
            // TODO create random events in-between goes
            while (true)
            {
                // Create a turn and show menu and take input
                // trigger event to make price changes
                string input = Prompt.Select("Select your option", new[] { "TICKER", "LIST", "BALANCE", "BUY", "SELL", "END" });

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

                }
            }

            static void ListCommodities(ICommodity[] commodities)
            {
                for (int i = 0; i < commodities.Length; i++)
                {
                    Console.WriteLine($"{i} - {commodities[i].Name}: £{commodities[i].Price}");
                }
                Console.ReadLine();
            }

            static Person CreatePlayer()
            {
                Console.WriteLine("\nName?");
                string name = Console.ReadLine();
                Console.WriteLine("\nOpening balance?");
                double balance = Convert.ToDouble(Console.ReadLine());

                return new Person(name, balance);
            }

            static void ListInventory(Person person)
            {
                Dictionary<ICommodity, int> inventory = person.GetInventory();

                if (!inventory.Any())
                {
                    Console.WriteLine("No inventory");
                }
                else
                {
                    foreach (KeyValuePair<ICommodity, int> item in inventory)
                    {
                        Console.WriteLine($"{item.Value} x {item.Key.Name}: {item.Key.Price}");
                    }
                }
                Console.ReadLine();
            }

            static void Buy(Person person, ICommodity[] commodities)
            {

                Dictionary<ICommodity, int> buyOrder = new Dictionary<ICommodity, int>();
                Console.WriteLine("\nHow many types of coins do you want to buy?");
                int noOfBuys = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < noOfBuys; i++)
                {
                    Console.WriteLine("\nEnter the index number of the coin you want to buy...");
                    int coin = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("\nEnter the quantity...");
                    int quantity = Convert.ToInt16(Console.ReadLine());
                    buyOrder[commodities[coin]] = quantity;
                }

                person.Buy(buyOrder);
                Console.WriteLine("Order placed");
                Console.ReadLine();

            }

            static void ShowBalance(Person person)
            {
                Console.WriteLine($"{person.Name}'s balance = {person.Balance}");
                Console.ReadLine();
            }
            static void Sell(Person person)
            {

                /* 
                - display current portfolio 
                - ask what they want to sell
                - ask how many
                - check this does not exceed amount the own
                - call the Sell method on Person class 
                */

            }
        }
    }
}
