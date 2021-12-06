using System;
using System.Threading;


namespace lb6
{
    class Program
    {
        public static void Main()
        {
            StoreFunctionality.Store store = new StoreFunctionality.Store();

            int until = new Random().Next(1, 5);
            for (int from = 1; from <= until; ++from)
            {
                Thread buyers = new Thread(store.EmulateBuyers);
                buyers.Start();
                while (buyers.IsAlive) Thread.Sleep(500);

                Thread inventory = new Thread(store.EmulateInventory);
                inventory.Start();
                while (inventory.IsAlive) Thread.Sleep(500);
            }

            Console.Write("Do you want to revise history of inventories? y/n: ");
            if (Console.ReadLine() == "y")
            {
                store.PrintInventoryHistory();
            }

            Console.ReadKey();
        }
    }

}
