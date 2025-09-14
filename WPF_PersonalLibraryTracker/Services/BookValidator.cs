using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace WPF_PersonalLibraryTracker.Services
{
    internal class BookValidator
    {
        internal static void ShowWarning(TextBox box, TextBlock warning, string warningMessage = "")
        {
            box.BorderBrush = Brushes.Red;
            warning.Visibility = Visibility.Visible;
            warning.Foreground = Brushes.Red;
            warning.Text = warningMessage;

        }

        internal static void ClearWarnings(TextBox box, TextBlock warning)
        {
            box.ClearValue(Border.BorderBrushProperty); // reset color
            warning.Visibility = Visibility.Collapsed;
        }

        public static bool ValidateInputs(MainWindow window, out int totalPages, out int currentPage)
        {
            totalPages = 0;
            currentPage = 0;

            // Title
            if (string.IsNullOrWhiteSpace(window.inputBookTitle.Text))
            {
                ShowWarning(window.inputBookTitle, window.titleWarning, "* Title is required.");
                return false;
            }
            else
            {
                ClearWarnings(window.inputBookTitle, window.titleWarning);
            }

            // Total Pages
            if (!int.TryParse(window.inputBookTotalPages.Text, out totalPages) || totalPages <= 0)
            {
                ShowWarning(window.inputBookTotalPages, window.totalPagesWarning, "* Total pages should be more than 0.");
                return false;
            }
            else
            {
                window.inputBookTotalPages.ClearValue(Border.BorderBrushProperty);
                window.totalPagesWarning.Visibility = Visibility.Collapsed;
            }

            // Current Page
            if (!string.IsNullOrWhiteSpace(window.inputBookCurrentPage.Text))
            {
                if (!int.TryParse(window.inputBookCurrentPage.Text, out currentPage) || currentPage < 0)
                {
                    ShowWarning(window.inputBookCurrentPage, window.currentPageWarning, "* Current page must be 0 or more.");
                    return false;
                }

                if (currentPage > totalPages)
                {
                    ShowWarning(window.inputBookCurrentPage, window.currentPageWarning, "* Current page cannot exceed Total Pages.");
                    return false;
                }
            }
            else
            {
                currentPage = 0; // default
            }

            return true;
        }
    }
}
