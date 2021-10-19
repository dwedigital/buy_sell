using System.Collections.Generic;

namespace buy_sell
{
    interface Iperson
    {
        string Name { get; }
        double Balance { get; }
        Dicitionary<Commodity, int> Inventory { get; }
        // Methods
        void Buy(Dictionary<Commodity, int> commodities);
        List<Commodity> GetInventory();
        double AddCash(double amount);

    }
}