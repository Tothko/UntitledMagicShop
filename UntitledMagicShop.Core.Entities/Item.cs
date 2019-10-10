using System;
using System.Collections.Generic;
using System.Text;

namespace UntitledMagicShop.Core.Entities
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int OnStock { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
