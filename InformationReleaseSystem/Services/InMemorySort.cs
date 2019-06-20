using System.Collections.Generic;
using System.Linq;
using InformationReleaseSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationReleaseSystem.Services
{
    public class InMemorySort : ISort<Sort>
    {
        private readonly DataBaseContext _context;

        public InMemorySort(DataBaseContext context)
        {
            this._context = context;
        }

        public List<Sort> GetAll()
        {
            var query = from s in _context.Sorts
                orderby s.Id
                        select s;

            return query.ToList();
        }

        public bool IsSortExisted(string sortName)
        {
            var qury = from s in _context.Sorts
                where s.Name == sortName
                select s;

            if (qury.ToList().Count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void AddSort(string sortName)
        {
            var newSort = new Sort()
            {
                Name = sortName
            };

            _context.Entry<Sort>(newSort).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DelSort(string sortName)
        {
            var sort = _context.Sorts.FirstOrDefault(s => s.Name == sortName);

            _context.Entry<Sort>(sort).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public int GetSortIdByTextId(int textId)
        {
            var qury = from t in _context.Texts
                where t.Id == textId
                select t.SortId;

            return qury.ToList().FirstOrDefault();
        }
    }
}
