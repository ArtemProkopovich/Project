namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reviews
    {
        [Key]
        public int ReviewID { get; set; }

        public int UserID { get; set; }

        public int BookID { get; set; }

        [Required]
        [StringLength(300)]
        public string Header { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Text { get; set; }

        public int Review_Type { get; set; }

        public DateTime Added_Date { get; set; }

        public virtual Books Books { get; set; }

        public virtual Users Users { get; set; }
    }
}
