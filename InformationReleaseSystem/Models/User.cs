using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InformationReleaseSystem.Models
{
    [Table("user")]
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "用户名不能为空。")]
        public string Name { get; set; }

        [Required(ErrorMessage = "密码不能为空。")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int Permission { get; set; }
    }
}
