namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Files
    {
        [Key]
        public int FileID { get; set; }

        public int BookID { get; set; }

        [Required]
        [StringLength(255)]
        public string Path { get; set; }

        [Required]
        [StringLength(5)]
        public string Format { get; set; }

        public virtual Books Books { get; set; }
    }
}
