namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Authors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Authors()
        {
            Books = new HashSet<Books>();
        }

        [Key]
        public int AuthorID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime? Birth_Date { get; set; }

        public DateTime? Death_Date { get; set; }

        [Column(TypeName = "ntext")]
        public string Biography { get; set; }

        [StringLength(255)]
        public string Photo_Path { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Books> Books { get; set; }
    }
}
