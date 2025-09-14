using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_PersonalLibraryTracker.Models;

namespace WPF_PersonalLibraryTracker.Services
{
    internal class UIHelper
    {
        internal static void HideLibrary(MainWindow window)
        {
            window.Library.Visibility = Visibility.Hidden;
            window.RemoveBookButton.Visibility = Visibility.Collapsed;
            window.SaveLibraryButton.Visibility = Visibility.Collapsed;
            window.AddBookButton.Visibility = Visibility.Collapsed;
            window.RemoveBookButton.Visibility = Visibility.Collapsed;
        }

        internal static void ShowLibrary(MainWindow window)
        {
            window.Library.Visibility = Visibility.Visible;
            window.RemoveBookButton.Visibility = Visibility.Visible;
            window.SaveLibraryButton.Visibility = Visibility.Visible;
            window.AddBookButton.Visibility = Visibility.Visible;
            window.RemoveBookButton.Visibility = Visibility.Visible;
        }
        
        internal static void ShowAddBookElements(MainWindow window)
        {
            window.addBookElementsContainer.Visibility = Visibility.Visible;
            window.bookCoverSelectionContainer.Visibility = Visibility.Visible;
            window.bookCoverPathContainer.Visibility = Visibility.Visible;
            window.bookTitelContainer.Visibility = Visibility.Visible;
            window.bookAuthorContainer.Visibility = Visibility.Visible;
            window.bookTotalPagesContainer.Visibility = Visibility.Visible;
            window.bookCurrentPagesContainer.Visibility = Visibility.Visible;
            window.CancelButton.Visibility = Visibility.Visible;
            window.SaveBookButton.Visibility = Visibility.Visible;
        }

        internal static void HideAddBookElements(MainWindow window)
        {
            window.addBookElementsContainer.Visibility = Visibility.Collapsed;
            window.bookCoverSelectionContainer.Visibility = Visibility.Collapsed;
            window.bookCoverPathContainer.Visibility = Visibility.Collapsed;
            window.bookTitelContainer.Visibility = Visibility.Collapsed;
            window.bookAuthorContainer.Visibility = Visibility.Collapsed;
            window.bookTotalPagesContainer.Visibility = Visibility.Collapsed;
            window.bookCurrentPagesContainer.Visibility = Visibility.Collapsed;
            window.CancelButton.Visibility = Visibility.Collapsed;
            window.SaveBookButton.Visibility = Visibility.Collapsed;
        }

        internal static void ClearInputFields(MainWindow window)
        {
            window.inputBookTitle.Text = string.Empty;
            window.inputBookAuthor.Text = string.Empty;
            window.inputBookTotalPages.Text = string.Empty;
            window.inputBookCurrentPage.Text = string.Empty;
            window.imageCoverPath.Text = string.Empty;
            window.imageCoverPath.Visibility = Visibility.Collapsed;
            window.coverImageContainer.Visibility = Visibility.Collapsed;
        }
    }
}
