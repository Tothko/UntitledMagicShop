using System;
using System.Collections.Generic;
using System.Text;

namespace UntitledMagicShop.Core.Entities
{
    public class Purchase
    {
        public int ID { get; set; }
        public User User { get; set; }
        public List<Item> Items { get; set; }
        public double TotalPrice { get; set; }

    }
}
