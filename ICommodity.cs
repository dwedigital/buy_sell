namespace buy_sell{

    interface ICommodity
    {
        double Price{get;}
        string Name{get;}

        // Methods
        double GetPrice();

        double ChangePrice(double price);

        string Getname();
    }
}