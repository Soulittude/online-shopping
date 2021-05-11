using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    [Table("Firma")]
    public class Firma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("ad")]
        public string Ad { get; set; }

        [Column("ulke")]
        [Required]
        public string Ulke { get; set; }

        [Column("website")]
        public string Website { get; set; }
    }
}
