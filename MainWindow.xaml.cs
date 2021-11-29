using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace lab2
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Agency agency1 = new("Agency1");
        public Agency agency2 = new("Agency2");
        public Author author = new("Test Author");

        public MainWindow()
        {
            InitializeComponent();
            Agency1ListBox.DataContext = agency1.Received;
            Agency2ListBox.DataContext = agency2.Received;
        }

        private void PublishButton_Click(object sender, RoutedEventArgs e)
        {
            var genre = Genre.Text;
            var title = Title.Text;
            var pagesCountString = PagesCount.Text;
            var pagesCount = 0;
            try
            {
                pagesCount = int.Parse(pagesCountString, NumberStyles.Any);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Неправильный формат данных в поле \"{PagesCountLabel.Content}\"!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            var authorWork = new AuthorWork(genre, title, pagesCount);
            if (!authorWork.ValidateData())
                MessageBox.Show("Введена недопустимая информация. Проверьте поля!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            author.Publish(authorWork);
            Agency1ListBox.Items.Refresh();
            Agency2ListBox.Items.Refresh();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Subscribe1Button_Click(object sender, RoutedEventArgs e)
        {
            agency1.Subscribe(author);
        }

        private void Unsubscribe1Button_Click(object sender, RoutedEventArgs e)
        {
            agency1.Unsubscribe(author);
        }

        private void Subscribe2Button_Click(object sender, RoutedEventArgs e)
        {
            agency2.Subscribe(author);
        }

        private void Unsubscribe2Button_Click(object sender, RoutedEventArgs e)
        {
            agency2.Unsubscribe(author);
        }
    }
}