using System.Collections.Generic;
using System.Linq;
namespace buy_sell
{
    class Person : IPerson
    {
        public string Name { get; private set; }
        public double Balance { get; private set; }

        public Dictionary<ICommodity, int> Inventory { get; set; }

        public Person(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
            this.Inventory = new Dictionary<ICommodity, int>();
        }

        public double AddCash(double amount)
        {

            return this.Balance += amount;
        }

        public Dictionary<ICommodity, int> Buy(Dictionary<ICommodity, int> commodities)
        {

                foreach (KeyValuePair<ICommodity, int> commodity in commodities)
                {
                    if (this.Inventory.ContainsKey(commodity.Key))
                    {
                        this.Inventory[commodity.Key] += commodity.Value;
                    }
                    else
                    {
                        this.Inventory.Add(commodity.Key, commodity.Value);
                    }
                    this.Balance -= commodity.Key.Price * commodity.Value;
                }
            


            return this.Inventory;
        }

        // need to create a Sell method
        public void Sell(Dictionary<ICommodity, int> sellOrder)
        {
            foreach (KeyValuePair<ICommodity, int> sellCoin in sellOrder){
                System.Console.WriteLine(sellCoin.Key.Name);

                foreach (KeyValuePair<ICommodity, int> heldCoin in Inventory){
                    if(sellCoin.Key.Name == heldCoin.Key.Name){
                        // TODO need to fix this
                        this.Inventory[heldCoin.Key] -= sellCoin.Value;
                        this.Balance += sellCoin.Key.Price * sellCoin.Value;
                        if(this.Inventory[heldCoin.Key] == 0){
                            Inventory.Remove(heldCoin.Key);
                        }
                    }
                }
            }
        }

        public Dictionary<ICommodity, int> GetInventory()
        {
            return this.Inventory;
        }
    }
}