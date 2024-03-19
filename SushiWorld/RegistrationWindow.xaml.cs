using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SushiWorld
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public TextBlock clearTextBlock = null;
        public TextBox enterTextBox = null;
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        // Расширить кнопку НАЗАД
        public void DoFat(object sender, RoutedEventArgs e)
        {
            Border bigBorder = sender as Border;
            bigBorder.Width = 120;
            Back.Opacity = 1;
            bigBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#936AD2");

        }
        // Уменьшение картинки при отведении мыши с кнопки
        public void DoNormal(object sender, RoutedEventArgs e)
        {
            Border smallBorder = sender as Border;
            smallBorder.Width = 100;
            Back.Opacity = 0;
            smallBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#AB7AF5");

        }

        // Уыеличение картинки при наведении на кнопку
        public void DoBig(object sender, RoutedEventArgs e)
        {
            Border bigBorder = sender as Border;
            bigBorder.Width = 300;
            bigBorder.Height = 300;
            bigBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#936AD2");

        }
        // Уменьшение картинки при отведении мыши с кнопки
        public void DoSmall(object sender, RoutedEventArgs e)
        {
            Border smallBorder = sender as Border;
            smallBorder.Width = 290;
            smallBorder.Height = 290;
            smallBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#AB7AF5");

        }

        // Переход к окну регистрации
        public void GoBack(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("go back");
            Console.WriteLine("open registration window");
            MainWindow mainWindow = new MainWindow()
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = Left,
                Top = Top
            };

            this.Visibility = Visibility.Collapsed;
            mainWindow.Show();
        }

        // Зарегистрировать пользоавтеля
        public void RegistrationUser(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("do registration");
        }

        
        // Очистка текстового ввода
        public void ClearTextBox(object sender, RoutedEventArgs e)
        {
            clearTextBlock = sender as TextBlock;
            clearTextBlock.Visibility = Visibility.Hidden;
        }

        // Возвращение подсказки
        public void FillTextBox(object sender, RoutedEventArgs e)
        {
            if (clearTextBlock == null)
                return;
            
            if (enterTextBox.Text.Length == 0)
            {
                clearTextBlock.Visibility = Visibility.Visible;
            }
        }

        public void checkEmptyTextBox(object sender, RoutedEventArgs e)
        {

            enterTextBox = sender as TextBox;
            if (clearTextBlock == null)
                return;

            if (enterTextBox.Text.Length == 0)
            {
                clearTextBlock.Visibility = Visibility.Visible;
            }

        }

        // Переход к окну авторизации
        public void GoAuthorizationWindow(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("open registration window");
            UserAccount userAccount = new UserAccount()
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = Left,
                Top = Top
            };

            this.Visibility = Visibility.Collapsed;
            userAccount.Show();
        }
    }
}
