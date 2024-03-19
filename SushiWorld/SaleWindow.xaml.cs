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
    /// Логика взаимодействия для SaleWindow.xaml
    /// </summary>
    public partial class SaleWindow : Window
    {
        public SaleWindow()
        {
            InitializeComponent();
        }
        public string BannerName = null;
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

        // Показать акцию
        public void ShowText(object sender, RoutedEventArgs e)
        {
            Border saleBorder = sender as Border;
            switch (saleBorder.Name.ToString())
            {
                case ("CoolDaysBanner"):
                    BannerName = "CoolDays";
                    CoolDays.Visibility = Visibility.Visible;
                    break;
                case ("HappyBirthdayBanner"):
                    BannerName = "HappyBirthday";
                    HappyBirthday.Visibility = Visibility.Visible;
                    break;
            }
        }

        // Скрыть акцию
        public void HideText(object sender, RoutedEventArgs e)
        {
            Border saleBorder = sender as Border;
            switch (BannerName)
            {
                case ("CoolDays"):
                    BannerName = null;
                    CoolDays.Visibility = Visibility.Hidden;
                    break;
                case ("HappyBirthday"):
                    BannerName = null;
                    HappyBirthday.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}
