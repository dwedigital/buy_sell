using System.Collections.Generic;
using System.Linq;
namespace buy_sell
{
    class Person : IPerson
    {
        public string Name { get; private set; }
        public double Balance { get; private set; }

        public Dictionary<ICommodity, int> Inventory { get; private set; } = new Dictionary<ICommodity, int>();

        public Person(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public double AddCash(double amount)
        {

            return this.Balance += amount;
        }

        public Dictionary<ICommodity, int> Buy(Dictionary<ICommodity, int> commodities)
        {
            if (!this.Inventory.Any())
            {
                foreach (KeyValuePair<ICommodity, int> commodity in commodities)
                {
                    this.Inventory[commodity.Key] = commodity.Value;
                    this.Balance = -commodity.Key.Price;
                }

            }
            else
            {
                foreach (KeyValuePair<ICommodity, int> commodity in commodities)
                {
                    this.Inventory[commodity.Key] += commodity.Value;
                    this.Balance -= commodity.Key.Price;
                }
            }


            return this.Inventory;
        }

        // need to create a Sell method
        public void Sell(Dictionary<string, int> sellOrder){

        }

        public Dictionary<ICommodity, int> GetInventory()
        {
            return this.Inventory;
        }
    }
}