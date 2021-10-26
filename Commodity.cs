using System;

namespace buy_sell
{
    class Coin : ICoin
    {
        public double Price { get; private set; }
        public string Name { get; private set; }
        public double Volatility { get; private set; }

        public Coin(string name)
        {
            System.Random rand = new Random();

            this.Name = name;
            this.Price = ApiCall.Api(this.Name);
            // Set a random volatility for each commodity created
            this.Volatility = rand.Next(1,4);
        }
        public double GetPrice()
        {
            return Math.Round(Price, 2);
        }

        public double ChangePrice()
        {
            System.Random rand = new Random();
            if (rand.Next(1, 5) == 1)
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
                return this.Price = this.Price * (rand.Next(1, 4) * this.Volatility);
            }

        }

        public string Getname()
        {
            return this.Name;
        }
    }
}