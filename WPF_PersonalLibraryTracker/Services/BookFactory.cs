using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_PersonalLibraryTracker.Models;

namespace WPF_PersonalLibraryTracker.Services
{
    internal class BookFactory
    {
        public static Book Create(MainWindow window, int totalPages, int currentPage)
        {
            int progress = (int)((double)currentPage / totalPages * 100);

            string coverPath = string.IsNullOrWhiteSpace(window.imageCoverPath.Text)
                ? "resources\\defaultCover.png"
                : window.imageCoverPath.Text;

            if (string.IsNullOrWhiteSpace(window.inputBookCurrentPage.Text))
                window.inputBookCurrentPage.Text = "0";

            return new Book
            {
                CoverImagePath = coverPath,
                Title = window.inputBookTitle.Text,
                Author = window.inputBookAuthor.Text,
                CurrentPage = $"Page {window.inputBookCurrentPage.Text} / {window.inputBookTotalPages.Text}",
                Progress = $"Progress: {progress}%"
            };
        }
    }
}
