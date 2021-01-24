using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvc.Domain
{
    [Table("Permissions")]
    public class Permission
    {
        public Permission(string functionId, string roleId, string commandId)
        {
            FunctionId = functionId;
            RoleId = roleId;
            CommandId = commandId;
        }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string RoleId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FunctionId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string CommandId { get; set; }
    }
}
