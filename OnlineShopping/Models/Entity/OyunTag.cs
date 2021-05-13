using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Models.Entity
{
    [Table("OyunTag")]
    public class OyunTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("OyunFK")]
        [Column("oyun_id")]
        public int OyunID { get; set; }
        public virtual Oyun OyunFK { get; set; }

        [ForeignKey("TagFK")]
        [Column("tag_id")]
        public int TagID { get; set; }
        public virtual Tag TagFK { get; set; }
    }
}
