using System.Collections.Generic;

namespace buy_sell
{
    interface Iperson
    {
        string Name { get; }
        double Balance { get; }
        List<Commodity> Inventory { get; }
        // Methods
        void Buy(List<Commodity> order);
        List<Commodity> List();
        double AddCash(double amount);

    }
}