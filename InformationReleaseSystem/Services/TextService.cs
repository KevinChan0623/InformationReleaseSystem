using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationReleaseSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InformationReleaseSystem.Services
{
    public class TextService : IText<Text>
    {
        private readonly DataBaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TextService(DataBaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Text> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Text> GetTitleBySortId(int sortId)
        {
            throw new NotImplementedException();
        }

        public Text ShowTextById(int textId)
        {
            throw new NotImplementedException();
        }

        public void AddText(Text newText)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            newText.PublisherId = (int)session.GetInt32("UserId");
            newText.Time = DateTime.Now;

            _context.Entry(newText).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DelText(int textId)
        {
            throw new NotImplementedException();
        }
    }
}
