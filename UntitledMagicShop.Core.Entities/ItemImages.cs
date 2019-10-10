using System;
using System.Collections.Generic;
using System.Text;

namespace UntitledMagicShop.Core.Entities
{
    public class ItemImages
    {
        public Item Item{ get; set; }
        public Image Image { get; set; }
        public int ImageID { get; set; }
        public int ItemID { get; set; }
    }
}
