namespace buy_sell{

    interface ICommodity
    {
        double price{get;}
        string name{get;}

        // Methods
        double GetPrice();

        void ChangePrice();

        string Getname();
    }
}