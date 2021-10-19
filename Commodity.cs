namespace buy_sell{
    class Commodity: ICommodity
    {
        public double Price { get; private set;}
        public string Name { get; private set; }

        public Commodity(double price, string name){
            this.Price = price;
            this.Name = name;
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