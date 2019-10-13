using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarketRegister
{
    public interface IReceipt
    {
        void AddItem(int quantity, string name, double price);
    }
}
