using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InformationReleaseSystem.ViewModels
{
    public class UserComment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "评论不能为空")]
        public string Text { get; set; }
        public int TextId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Time { get; set; }
        public int State { get; set; }
    }
}
