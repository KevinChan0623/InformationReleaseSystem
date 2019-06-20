using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationReleaseSystem.Models;
using InformationReleaseSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace InformationReleaseSystem.Services
{
    public class InMemoryComment : IComment<UserComment>
    {
        private readonly DataBaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InMemoryComment(DataBaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<UserComment> GetAllByTextId(int textId)
        {
            var query = from c in _context.Comments
                orderby c.Time descending 
                where c.TextId == textId && c.State == 1
                join u in _context.Users on c.UserId equals u.Id 
                select new UserComment(){ Id = c.Id, Text = c.Text, TextId = c.TextId, Time = c.Time, UserId = c.UserId, UserName = u.Name};

            return query.ToList();
        }

        public void AddComment(Comment model)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            _context.Entry<Comment>(model).State = EntityState.Added;
            _context.SaveChanges();
        }

        public List<UserCommentText> GetNotCheckedCommentCount()
        {
            var query = from c in _context.Comments
                orderby c.Time
                where c.State == 0
                join u in _context.Users on c.UserId equals u.Id
                join t in _context.Texts on c.TextId equals t.Id 
                select new UserCommentText(){ Id = c.Id, State = c.State, Text = c.Text, TextTitleName = t.Title, Time = c.Time, UserName = u.Name};

            return query.ToList();
        }

        public void AllowComment(int commentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);
            comment.State = 1;

            _context.Entry<Comment>(comment).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
