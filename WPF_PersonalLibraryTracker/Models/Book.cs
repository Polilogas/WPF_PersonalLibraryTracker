using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_PersonalLibraryTracker.Models
{
    internal class Book
    {
        public string CoverImagePath { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string TotalPages { get; set; }
        public string CurrentPage { get; set; }
        public string Progress { get; set; }
    }
}
