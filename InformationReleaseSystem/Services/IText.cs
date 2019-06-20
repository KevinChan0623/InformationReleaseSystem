using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationReleaseSystem.Models;

namespace InformationReleaseSystem.Services
{
    public interface IText<T> where  T : class
    {
        List<T> GetAll();
        List<T> GetTitleBySortId(int sortId);
        T ShowTextById(int textId);
        void AddText(Text newText);
        void DelText(int textId);
    }
}
