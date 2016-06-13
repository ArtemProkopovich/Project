namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bookmarks
    {
        [Key]
        public int BookmarkID { get; set; }

        public int Collection_BookID { get; set; }

        public int Page { get; set; }

        public virtual Collection_Book Collection_Book { get; set; }
    }
}
