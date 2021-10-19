namespace buy_sell{

    interface ICommodity
    {
        double Price{get;}
        string Name{get;}

        double VolatilityFactor{get;}

        // Methods
        double GetPrice();

        double ChangePrice(double price);

        string Getname();
    }
}