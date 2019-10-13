using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SuperMarketRegister
{
    public class Receipt : IReceipt
    {
        public List<Item> Items { get; set; }
        public Receipt()
        {
            Items = new List<Item>();
        }

        private float tax = 10f;
        private double SubTotal { get; set; }
        private double TaxAmount { get; set; }

        private double Total { get; set; }

        public void AddItem(int quantity, string name, double price)
        {
            Items.Add(new Item() { Quantity = quantity, Name = name, Price = price, Total = quantity * price });
        }

        public override string ToString()
        {
            SubTotal = !Items.Any() ? 0 : Items.Sum(x => x.Total);
            TaxAmount = Items.Sum(x => x.Total) * (tax / 100);
            Total = !Items.Any() ? 0 : SubTotal + TaxAmount;

            StringBuilder s = new StringBuilder();
            Items.ForEach(x =>
            {
                s.Append(x.Quantity + " " + x.Name + " @ $" + x.Price.ToString("F2") + " = $" + x.Total.ToString("F2") + "\r\n");
            });
            s.Append("SubTotal = $" + SubTotal.ToString("F2") + "\r\n");
            s.Append("Tax (" + tax + "%) = $" + TaxAmount.ToString("F2") + "\r\n");
            s.Append("Total = $" + Total.ToString("F2"));
            return s.ToString();
        }
    }
}
