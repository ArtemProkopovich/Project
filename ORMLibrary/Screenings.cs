namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Screenings
    {
        [Key]
        public int ScreeningID { get; set; }

        public int BookID { get; set; }

        [Required]
        [StringLength(200)]
        public string Film_Name { get; set; }

        public DateTime Year { get; set; }

        [StringLength(200)]
        public string Link { get; set; }

        public virtual Books Books { get; set; }
    }
}
