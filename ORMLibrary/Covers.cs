namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Covers
    {
        [Key]
        public int CoverID { get; set; }

        public int BookID { get; set; }

        [Required]
        [StringLength(255)]
        public string Path { get; set; }

        public virtual Books Books { get; set; }
    }
}
