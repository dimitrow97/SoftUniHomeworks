﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Products_Migration
{
    public class StoreLocation
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public List<Sale> SalesInStore { get; set; }
    }
}
