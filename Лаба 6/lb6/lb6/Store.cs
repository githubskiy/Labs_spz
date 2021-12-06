using System;
using System.Threading;
using System.Collections.Generic;

using System.IO;
using System.Xml.Serialization;


namespace StoreFunctionality
{
    public class Store
    {
        decimal Budget;
        decimal PrevBudget;
        decimal Payment;
        int PrevBuyers;
        bool FirstLaunch;

        [Serializable]

        public struct InvertoryRecord
        {
            public decimal Profit;
            public int NumberOfLastBuyers;
        }
        List<InvertoryRecord> InvertoryHistory = new List<InvertoryRecord>();

        public class Warehouse
        {
            [Serializable]
            public struct Product
            {
                public string Title;
                public int Number;
                public decimal ProducerPrice;
                public decimal StorePrice;
            }
            public List<Product> ProductsInStock = new List<Product>();
        }
        Warehouse StoreWarehouse = new Warehouse();

        public Store()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Warehouse.Product[]));

            using (FileStream fs = new FileStream("C:\\Users\\unknown\\Store\\Products.xml",
                FileMode.Open))
            {
                StoreWarehouse.ProductsInStock.AddRange((Warehouse.Product[])formatter.Deserialize(fs));
            }

            Budget = 0m;
        }

        public void PrintInventoryHistory()
        {
            foreach (var el in InvertoryHistory)
            {
                Console.WriteLine($"Profit: {el.Profit}.\tNumber of last buyers: {el.NumberOfLastBuyers}");
            }
        }

        public void EmulateBuyers()
        {
            PrevBudget = Budget;
            Payment = 0m;

            int last = new Random().Next(1, 10);
            PrevBuyers = last;

            for (int first = 1; first <= last; ++first)
            {
                if (StoreWarehouse.ProductsInStock.Count == 0) break;

                int productID = new Random().Next(0, StoreWarehouse.ProductsInStock.Count);
                int number = new Random().Next(1, StoreWarehouse.ProductsInStock[productID].Number);

                Warehouse.Product tmp = StoreWarehouse.ProductsInStock[productID];
                tmp.Number -= number;
                StoreWarehouse.ProductsInStock[productID] = tmp;

                Budget += number * StoreWarehouse.ProductsInStock[productID].StorePrice;
                Payment += number * StoreWarehouse.ProductsInStock[productID].ProducerPrice;

                if (StoreWarehouse.ProductsInStock[productID].Number == 0)
                {
                    StoreWarehouse.ProductsInStock.RemoveAt(productID);
                }
                Thread.Sleep(500);
            }
        }

        public void EmulateInventory()
        {
            XmlSerializer format = new XmlSerializer(typeof(InvertoryRecord[]));
            if (!File.Exists("C:\\Users\\unknown\\Store\\Records.xml"))
            {
                using (FileStream fs = new FileStream("C:\\Users\\unknown\\Store\\Records.xml",
                    FileMode.Create))
                {
                    InvertoryHistory.Add(new InvertoryRecord() { Profit = 0m, NumberOfLastBuyers = 0 });
                    format.Serialize(fs, InvertoryHistory.ToArray());

                    FirstLaunch = true;
                }
            }

            InvertoryHistory.Clear();

            using (FileStream fs = new FileStream("C:\\Users\\unknown\\Store\\Records.xml",
                   FileMode.Open))
            {
                InvertoryHistory.AddRange((InvertoryRecord[])format.Deserialize(fs));
            }

            if (FirstLaunch)
            {
                InvertoryHistory.RemoveAt(0);
                FirstLaunch = false;
            }
            InvertoryHistory.Add(new InvertoryRecord()
            {
                Profit = Budget - PrevBudget - Payment,
                NumberOfLastBuyers = PrevBuyers
            });
            using (FileStream fs = new FileStream("C:\\Users\\unknown\\Store\\Records.xml",
                   FileMode.Create))
            {
                format.Serialize(fs, InvertoryHistory.ToArray());
            }

            XmlSerializer format2 = new XmlSerializer(typeof(Warehouse.Product[]));

            using (FileStream fs = new FileStream("C:\\Users\\unknown\\Store\\Products.xml",
                   FileMode.Open))
            {
                StoreWarehouse.ProductsInStock.Clear();
                StoreWarehouse.ProductsInStock.AddRange((Warehouse.Product[])format2.Deserialize(fs));
            }
        }
    }
}

