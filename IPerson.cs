using System.Collections.Generic;

namespace buy_sell
{
    interface IPerson
    {
        string Name { get; }
        double Balance { get; }
        double StartBalance { get; }

        bool InGame { get; }
        Dictionary<ICoin, int> Inventory { get; }
        // Methods
        Dictionary<ICoin, int> Buy(ICoin coin, int qty);

        void Sell(Dictionary<ICoin, int> sellOrder);
        Dictionary<ICoin, int> GetInventory();
        double AddCash(double amount);

        void EndRound();

        bool IsAlive();

        double Worth();

    }
}