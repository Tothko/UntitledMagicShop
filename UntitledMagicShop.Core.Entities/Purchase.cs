using System;
using System.Collections.Generic;
using System.Text;

namespace UntitledMagicShop.Core.Entities
{
    public class Purchase
    {
        public int ID { get; set; }
        public User user { get; set; }
        public List<Item> items { get; set; }
        public double TotalPrice { get; set; }

    }
}
