using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models.Entity
{
    [Table("OyunDil")]
    public class OyunDil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("OyunFK")]
        [Column("oyun_id")]
        public int OyunID { get; set; }
        public virtual Oyun OyunFK { get; set; }

        [ForeignKey("DilFK")]
        [Column("dil_id")]
        public int DilID { get; set; }
        public virtual Tag DilFK { get; set; }
    }
}
