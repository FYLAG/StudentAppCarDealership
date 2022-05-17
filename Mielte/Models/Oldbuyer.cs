using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Oldbuyer
    {
        public int Buyer { get; set; }
        public string Car { get; set; }
        public DateTime? DateSale { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public decimal Price { get; set; }
    }
}
