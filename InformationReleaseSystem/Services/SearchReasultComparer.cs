using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationReleaseSystem.ViewModels;

namespace InformationReleaseSystem.Services
{
    public class SearchReasultComparer : IEqualityComparer<SortTextUser>
    {
        public bool Equals(SortTextUser x, SortTextUser y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            return x.Id == y.Id && x.Title == y.Title;
        }

        public int GetHashCode(SortTextUser obj)
        {
            return 0;
        }
    }
}
