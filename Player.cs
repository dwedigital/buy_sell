using System.Collections.Generic;
namespace buy_sell
{
    class Person
    {
        string Name { get; private set; }
        public double Balance { get; private set; }

        public Dicitionary<Commodity, int> Inventory { get; private set; }

        public Person(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public double AddCash(double amount)
        {

            return this.balance += amount;
        }

        public List<Commodity> Buy(Dictionary<Commodity, int> commodities)
        {



        }

        public List<Commodity> GetInventory()
        {
            return Inventory;
        }
    }
}