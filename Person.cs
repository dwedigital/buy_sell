using System.Collections.Generic;
namespace buy_sell
{
    class Person : IPerson
    {
        public string Name { get; private set; }
        public double Balance { get; private set; }
        public double StartBalance { get; private set; }

        public bool InGame { get; private set; } = true;

        public Dictionary<ICoin, int> Inventory { get; set; }

        public Person(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
            this.StartBalance = balance;
            this.Inventory = new Dictionary<ICoin, int>();
        }

        public double AddCash(double amount)
        {

            return this.Balance += amount;
        }

        public Dictionary<ICoin, int> Buy(ICoin coin, int qty)
        {


            if (this.Balance < (coin.Price * qty))
            {
                System.Console.WriteLine("Sorry, insufficent funds, try again");
            }
            else
            {
                if (this.Inventory.ContainsKey(coin))
                {
                    this.Inventory[coin] += qty;
                }
                else
                {
                    this.Inventory.Add(coin, qty);
                }
                this.Balance -= coin.Price * qty;
                System.Console.WriteLine("Order placed");
            }

            return this.Inventory;
        }

        // need to create a Sell method
        public void Sell(Dictionary<ICoin, int> sellOrder)
        {
            foreach (KeyValuePair<ICoin, int> sellCoin in sellOrder)
            {
                System.Console.WriteLine(sellCoin.Key.Name);

                foreach (KeyValuePair<ICoin, int> heldCoin in Inventory)
                {
                    if (sellCoin.Key.Name == heldCoin.Key.Name)
                    {
                        // TODO need to fix this
                        this.Inventory[heldCoin.Key] -= sellCoin.Value;
                        this.Balance += sellCoin.Key.Price * sellCoin.Value;
                        if (this.Inventory[heldCoin.Key] == 0)
                        {
                            Inventory.Remove(heldCoin.Key);
                        }
                    }
                }
            }
        }

        public Dictionary<ICoin, int> GetInventory()
        {
            return this.Inventory;
        }

        public void EndRound()
        {
            this.Balance -= 20;
            if (this.Balance <= 0)
            {
                this.InGame = false;
            }
        }

        public bool IsAlive()
        {
            return this.InGame;
        }

        public double Worth()
        {
            double portfolioValue = 0;
            foreach (KeyValuePair<ICoin, int> coin in Inventory)
            {
                portfolioValue += coin.Key.Price * coin.Value;
            }
            return System.Math.Round(portfolioValue + this.Balance, 2);
        }
    }
}