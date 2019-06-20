using System;

namespace InformationReleaseSystem.ViewModels
{
    public class SortTextUser
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string SortName { get; set; }
        public string PublisherName { get; set; }
        public DateTime Time { get; set; }
    }
}
