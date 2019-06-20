using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySqlX.XDevAPI.Relational;

namespace InformationReleaseSystem.Models
{
    [Table("text")]
    public class Text
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "标题")]
        public string Title { get; set; }
        [Required(ErrorMessage = "新闻内容")]
        public string Content { get; set; }
        public int SortId { get; set; }
        public int PublisherId { get; set; }
        public DateTime Time { get; set; }
    }
}
