using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationReleaseSystem.ViewModels
{
    public class Search
    {
        public int TextId { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public string SortName { get; set; }
        public string PublisherName { get; set; }
        public DateTime Time { get; set; }
        public string SearchText { get; set; }
    }
}
