using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCoreMvc.Domain
{
    [Table("CommandInFunctions")]
    public class CommandInFunction
    {
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string CommandId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string FunctionId { get; set; }
    }
}
