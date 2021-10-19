namespace buy_sell{
    class Commodity: ICommodity
    {
        public double Price { get; private set;}
        public string Name { get; private set; }

        public double VolatilityFactor{get; private set;}

        public Commodity(double price, string name, double volatilityFactor){
            this.Price = price;
            this.Name = name;
            this.VolatilityFactor = volatilityFactor;
        }
        public double GetPrice(){
            return Price;
        }

        public double ChangePrice(double price){
            return this.Price = price;
        }

        public string Getname(){
            return this.Name;
        }
    }
}