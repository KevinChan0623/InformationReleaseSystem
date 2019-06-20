using System.Collections.Generic;

namespace InformationReleaseSystem.Services
{
    public interface ISort<T> where T : class
    {
        List<T> GetAll();

        bool IsSortExisted(string sortName);
        void AddSort(string sortName);
        void DelSort(string sortName);
        int GetSortIdByTextId(int textId);
    }
}
