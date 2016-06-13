namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Likes
    {
        [Key]
        public int LikeID { get; set; }

        public int UserID { get; set; }

        public int BookID { get; set; }

        public bool Like { get; set; }

        public virtual Books Books { get; set; }

        public virtual Users Users { get; set; }
    }
}
