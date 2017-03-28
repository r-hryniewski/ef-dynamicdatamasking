namespace ef_dynamicdatamasking
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Rating { get; set; }
    }
}
