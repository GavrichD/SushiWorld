using SushiWorld.Properties;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SushiWorld
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        // Уыеличение картинки при наведении на кнопку
        public void DoBig(object sender, RoutedEventArgs e)
        {
            Border bigBorder = sender as Border;
            if (bigBorder.Name.ToString().Trim() == "Заказать")
            {
                Order.Height += 10;
                Order.Width += 20;
            }
            bigBorder.Width = 300;
            bigBorder.Height = 300;
            bigBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#936AD2");
            
        }
        // Уменьшение картинки при отведении мыши с кнопки
        public void DoSmall(object sender, RoutedEventArgs e)
        {
            Border smallBorder = sender as Border;
            if (smallBorder.Name.ToString().Trim() == "Заказать")
            {
                Order.Height -= 10;
                Order.Width -= 20;
            }
            smallBorder.Width = 290;
            smallBorder.Height = 290;
            smallBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#AB7AF5");
            
        }

        // Переход к окну регистрации
        public void GoRegistrationWindow(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("open registration window");
            RegistrationWindow registrationWindow = new RegistrationWindow()
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = Left,
                Top = Top
            };

            this.Visibility = Visibility.Collapsed;
            registrationWindow.Show();
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

        // Переход к окну Заказов
        public void GoOrderWindow(object sender, RoutedEventArgs e)
        {

            Console.WriteLine("open Order window");
            OrderWindow orderWindow = new OrderWindow()
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = Left,
                Top = Top
            };

            this.Visibility = Visibility.Collapsed;
            orderWindow.Show();
        }

        // Переход к окну Корзина
        public void GoBasketWindow(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("open Order window");
            BasketWindow basketWindow = new BasketWindow()
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = Left,
                Top = Top
            };

            this.Visibility = Visibility.Collapsed;
            basketWindow.Show();
        }

        // Переход к окну Акции
        public void GoSaleWindow(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("open Order window");
            SaleWindow saleWindow = new SaleWindow()
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = Left,
                Top = Top
            };

            this.Visibility = Visibility.Collapsed;
            saleWindow.Show();
        }

    }
}
