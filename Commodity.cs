using System;

namespace buy_sell
{
    class Coin : ICoin
    {
        public double Price { get; private set; }
        public string Name { get; private set; }
        public double Volatility { get; private set; }

        public Coin(double price, string name)
        {
            System.Random rand = new Random();
            this.Price = price;
            this.Name = name;
            // Set a random volatility for each commodity created
            this.Volatility = rand.NextDouble() * 5;
        }
        public double GetPrice()
        {
            return Math.Round(Price, 2);
        }

        public double ChangePrice()
        {
            System.Random rand = new Random();
            if (rand.Next(1, 3) == 1)
            {
                this.Price = (rand.Next(1, 3) * -1) * this.Volatility;
                if (this.Price <= 0)
                {
                    this.Price = rand.NextDouble();

                    return this.Price;
                }
                else
                {
                    return this.Price;
                }
            }
            else
            {
                return this.Price = this.Price * (rand.Next(1, 5) * this.Volatility);
            }

        }

        public string Getname()
        {
            return this.Name;
        }
    }
}