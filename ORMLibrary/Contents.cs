namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contents
    {
        [Key]
        public int ContentID { get; set; }

        public int BookID { get; set; }

        public int UserID { get; set; }

        [Column(TypeName = "ntext")]
        public string Text { get; set; }

        public virtual Books Books { get; set; }

        public virtual Users Users { get; set; }
    }
}
