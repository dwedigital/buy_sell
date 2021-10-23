using System.Collections.Generic;

namespace buy_sell
{
    interface IPerson
    {
        string Name { get; }
        double Balance { get; }
        Dictionary<ICommodity, int> Inventory { get; }
        // Methods
        Dictionary<ICommodity, int> Buy(Dictionary<ICommodity, int> commodities);

        void Sell(Dictionary<ICommodity, int> sellOrder);
        Dictionary<ICommodity, int> GetInventory();
        double AddCash(double amount);

    }
}