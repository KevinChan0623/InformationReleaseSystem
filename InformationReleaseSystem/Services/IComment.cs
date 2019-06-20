using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationReleaseSystem.Models;
using InformationReleaseSystem.ViewModels;

namespace InformationReleaseSystem.Services
{
    public interface IComment<T> where T : class
    {
        List<T> GetAllByTextId(int textId);
        void AddComment(Comment model);
        List<UserCommentText> GetNotCheckedCommentCount();
        void AllowComment(int commentId);
    }
}
