using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using InformationReleaseSystem.Models;
using InformationReleaseSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace InformationReleaseSystem.Services
{
    public class InMemoryText : IText<SortTextUser>
    {
        private readonly DataBaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private List<SortTextUser> _textUserView;

        public InMemoryText(DataBaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            this._context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public List<SortTextUser> GetAll()
        {
            var query = from t in _context.Texts
                join s in _context.Sorts on t.SortId equals s.Id
                join u in _context.Users on t.PublisherId equals u.Id
                orderby t.Time descending 
                select new SortTextUser() { Id = t.Id, Title = t.Title, Content = t.Content, SortName = s.Name, PublisherName = u.Name, Time = t.Time };

            _textUserView = query.ToList();

            return _textUserView;
        }

        public List<SortTextUser> GetTitleBySortId(int sortId)
        {
            
            var query = from t in _context.Texts
                join s in _context.Sorts on t.SortId equals s.Id
                join u in _context.Users on t.PublisherId equals u.Id
                orderby t.Time descending 
                where t.SortId == sortId
                select new SortTextUser() { Id = t.Id, Title = t.Title, Content = t.Content, SortName = s.Name, PublisherName = u.Name, Time = t.Time };

            _textUserView = query.ToList();

            return _textUserView;
        }

        public SortTextUser ShowTextById(int textId)
        {
            var query = from t in _context.Texts
                join s in _context.Sorts on t.SortId equals s.Id
                join u in _context.Users on t.PublisherId equals u.Id
                where t.Id == textId
                select new SortTextUser() { Id = t.Id, Title = t.Title, Content = t.Content, SortName = s.Name, PublisherName = u.Name, Time = t.Time };

            return query.ToList()[0];
        }

        public void AddText(Text newText)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            newText.PublisherId = (int) session.GetInt32("UserId");
            newText.Time = DateTime.Now;

            _context.Entry(newText).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DelText(int textId)
        {
            var Text = _context.Texts.FirstOrDefault(t => t.Id == textId);

            _context.Entry<Text>(Text).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
