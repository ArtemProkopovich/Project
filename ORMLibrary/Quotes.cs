namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Quotes
    {
        [Key]
        public int QuoteID { get; set; }

        public int Collection_BookID { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Text { get; set; }

        public virtual Collection_Book Collection_Book { get; set; }
    }
}
