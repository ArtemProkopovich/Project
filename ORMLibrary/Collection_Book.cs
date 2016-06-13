namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Collection-Book")]
    public partial class Collection_Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Collection_Book()
        {
            Bookmarks = new HashSet<Bookmarks>();
            Quotes = new HashSet<Quotes>();
        }

        public int Collection_BookID { get; set; }

        public int CollectionID { get; set; }

        public int BookID { get; set; }

        public bool? IsRead { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bookmarks> Bookmarks { get; set; }

        public virtual Books Books { get; set; }

        public virtual Collections Collections { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quotes> Quotes { get; set; }
    }
}
