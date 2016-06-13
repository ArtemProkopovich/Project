namespace ORMLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserProfiles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(255)]
        public string Photo_Path { get; set; }

        public bool? Male { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? Points { get; set; }

        public int? Level { get; set; }

        public virtual Users Users { get; set; }
    }
}
