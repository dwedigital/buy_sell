namespace buy_sell{

    interface ICoin
    {
        double Price{get;}
        string Name{get;}
        double Volatility{ get;}

        // Methods
        double GetPrice();

        double ChangePrice();

        string Getname();
    }
}