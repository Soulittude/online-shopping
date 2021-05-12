using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models.Entity
{
    [Table("Oyun")]
    public class Oyun
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("ad")]
        public string Ad { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Column("cikis_tarihi")]
        public DateTime CikisTarihi { get; set; }

        [Column("fiyat")]
        public int Fiyat { get; set; }

        [ForeignKey("FirmaFK")]
        [Column("firma_id")]
        public int FirmaID { get; set; }


        [ForeignKey("PlatformFK")]
        [Column("platform_id")]
        public int PlatformID { get; set; }

    }
}
