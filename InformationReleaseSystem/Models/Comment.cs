using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InformationReleaseSystem.Models
{
    [Table("comment")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }
        public int TextId { get; set; }
        public int UserId { get; set; }
        public DateTime Time { get; set; }
        public int State { get; set; }
    }
}
