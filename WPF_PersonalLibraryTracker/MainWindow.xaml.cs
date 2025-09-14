using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using WPF_PersonalLibraryTracker.Models;
using WPF_PersonalLibraryTracker.Services;

namespace WPF_PersonalLibraryTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Book> bookList = new ObservableCollection<Book>();
        // Track the book being edited (null if adding a new one)
        private Book editingBook = null;
        public MainWindow()
        {
            InitializeComponent();

            Library.ItemsSource = bookList;
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            editingBook = null; // new book
            UIHelper.HideLibrary(this);
            UIHelper.ShowAddBookElements(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            UIHelper.HideAddBookElements(this);
            UIHelper.ClearInputFields(this);
            UIHelper.ShowLibrary(this);
        }

        private void SaveBookButton_Click(object sender, RoutedEventArgs e)
        {
            var coverPath = string.IsNullOrWhiteSpace(imageCoverPath.Text) ? "pack://application:,,,/resources/defaultCover.png" : imageCoverPath.Text;

            if (!BookValidator.ValidateInputs(this, out int totalPages, out int currentPage))
                return;

            // Calculate progress
            int progress = (int)((double)currentPage / totalPages * 100);

            if (inputBookCurrentPage.Text == "")
                inputBookCurrentPage.Text = "0";

            if (editingBook == null)
            {
                // NEW book
                bookList.Add(new Book
                {
                    CoverImagePath = coverPath,
                    Title = inputBookTitle.Text,
                    Author = inputBookAuthor.Text,
                    CurrentPage = $"Page {inputBookCurrentPage.Text} / {inputBookTotalPages.Text}",
                    Progress = $"Progress: {progress}%"
                });
            }
            else
            {
                // UPDATE existing book
                editingBook.CoverImagePath = coverPath;
                editingBook.Title = inputBookTitle.Text;
                editingBook.Author = inputBookAuthor.Text;
                editingBook.CurrentPage = $"Page {inputBookCurrentPage.Text} / {inputBookTotalPages.Text}";
                editingBook.Progress = $"Progress: {progress}%";

                // Force refresh in ListBox
                Library.Items.Refresh();

                editingBook = null; // reset
            }

            UIHelper.HideAddBookElements(this);
            UIHelper.ClearInputFields(this);
            UIHelper.ShowLibrary(this);
        }



        private void SelectCoverImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";

            if (openFileDialog.ShowDialog() == true) // user clicked OK
            {
                string selectedFilePath = openFileDialog.FileName;

                // For example, put it into a textbox for now:
                imageCoverPath.Text = selectedFilePath;
                imageCoverPath.Visibility = Visibility.Visible;
                coverImagePreview.Source = new BitmapImage(new Uri(selectedFilePath));
                coverImageContainer.Visibility = Visibility.Visible;
            }
        }

        private void RemoveBookButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = Library.SelectedItem as Book;

            if (selectedBook != null)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete \"{selectedBook.Title}\" by {selectedBook.Author}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    (Library.ItemsSource as ObservableCollection<Book>)?.Remove(selectedBook);
                }
            }
            else
            {
                MessageBox.Show("No book selected.");
            }
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = Library.SelectedItem as Book;

            if (selectedBook != null) 
            {
                editingBook = selectedBook;

                UIHelper.HideLibrary(this);
                UIHelper.ShowAddBookElements(this);

                inputBookTitle.Text = selectedBook.Title;
                inputBookAuthor.Text = selectedBook.Author;
                // start
                string pages = selectedBook.CurrentPage;
                string[] pageParts = pages.Split(new string[] { "Page ", " / " }, StringSplitOptions.RemoveEmptyEntries);

                inputBookCurrentPage.Text = pageParts[0];
                inputBookTotalPages.Text = pageParts[1];

                // end

                imageCoverPath.Text = selectedBook.CoverImagePath;
                if (!string.IsNullOrWhiteSpace(selectedBook.CoverImagePath))
                    coverImagePreview.Source = new BitmapImage(new Uri(selectedBook.CoverImagePath));
                coverImageContainer.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No book selected.");
            }
        }
    }
}