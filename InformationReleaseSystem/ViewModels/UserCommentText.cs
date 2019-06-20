using System;
using System.ComponentModel.DataAnnotations;

namespace InformationReleaseSystem.ViewModels
{
    public class UserCommentText
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "评论不能为空")]
        public string Text { get; set; }
        public string TextTitleName { get; set; }
        public string UserName { get; set; }
        public DateTime Time { get; set; }

        public int State { get; set; }
    }
}
