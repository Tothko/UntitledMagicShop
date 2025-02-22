﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UntitledMagicShop.Core.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<Purchase> Purchases { get; set; }
    }
}
