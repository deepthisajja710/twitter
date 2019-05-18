namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Follow")]
    public partial class Follow
    {
        [Key]
        public int demo_id { get; set; }

        [Required]
        [StringLength(25)]
        public string user_id { get; set; }

        [Required]
        [StringLength(25)]
        public string Follow_id { get; set; }

        public virtual Client PERSON { get; set; }

        public virtual Client PERSON1 { get; set; }
    }
}
