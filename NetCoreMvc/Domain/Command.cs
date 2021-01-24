using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCoreMvc.Domain
{
    [Table("Commands")]
    public class Command
    {
        [Column(TypeName = "varchar(50)")]
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
