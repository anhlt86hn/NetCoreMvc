using NetCoreMvc.WebApp.Enums;
using NetCoreMvc.WebApp.Interface;
using NetCoreMvc.WebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMvc.Domain
{
    public class Function : ISwitchable, ISortable, IHasName
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public int SortOrder { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ParentId { get; set; }

        public int? Level { set; get; }
        public Status Status { set; get; }

        [Column(TypeName = "varchar(50)")]
        public string Icon { get; set; }
    }
}
