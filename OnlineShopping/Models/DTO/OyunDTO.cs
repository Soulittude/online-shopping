using OnlineShopping.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models.DTO
{
    public class OyunDTO
    {
        public string Ad { get; set; }

        public DateTime CikisTarihi { get; set; }

        public int Fiyat { get; set; }

        public int FirmaID { get; set; }

        public int PlatformID { get; set; }
    }
}
