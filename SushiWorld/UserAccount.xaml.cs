using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SushiWorld.Properties;

namespace SushiWorld
{
    /// <summary>
    /// Логика взаимодействия для UserAccount.xaml
    /// </summary>
    public partial class UserAccount : Window
    {
        public static bool UserIsAutorizated = false;
        public TextBlock clearTextBlock = null;
        public TextBox enterTextBox = null;
        public UserAccount()
        {
            InitializeComponent();
        }
        // Расширение кнупки возврата назад
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

            MainWindow mainWindow = new MainWindow()
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = Left,
                Top = Top
            };

            this.Visibility = Visibility.Collapsed;
            mainWindow.Show();
        }

        // АВТОРИЗАЦИЯ
        // Авторизовать пользоавтеля
        public void AuthorizationUser(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("do authorization");

            //Старая очистка корзины
            /*            Settings.Default["Basket"] = "";
                        Settings.Default.Save();
            */

            bool CheckAuorization = true;

            // Проверка на ввод 11 цифр
            if (!Regex.IsMatch(PhoneNumberAutorization.Text, @"^\d{11}$"))
            {
                MessageBox.Show("Пожалуйста введите 11-значный номер телефона");
                CheckAuorization = false;
                Console.WriteLine(3);
            }

            if (UserPasswordAutorization.Password.Length == 0)
            {
                MessageBox.Show("Please enter a password.");
                CheckAuorization = false;
                Console.WriteLine(4);
            }

            // Проверяем правильность ввода
            bool CheckUserDataInDataBase = new DataBaseConnection().CheckUserDataInDataBase(
                PhoneNumberAutorization.Text.ToString(), UserPasswordAutorization.Password.ToString());

            if (CheckAuorization && CheckUserDataInDataBase)
            {
                Console.WriteLine(6);
                GoMainWindow(null, null); // Переход на окно авторизации
                UserIsAutorizated = true;
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный логин или пароль");
            }
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

        // Проверка что поле не пустое
        public void checkEmptyTextBox(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox checkPasswordBox)
            {
                if (checkPasswordBox.Password.Length == 0)
                {
                    clearTextBlock.Visibility = Visibility.Visible;
                }
            }

            if (sender is TextBox checkTextBox)
            {
                if (checkTextBox.Text.Length == 0)
                {
                    clearTextBlock.Visibility = Visibility.Visible;
                }
            }
        }

        // Добавляем обработчик события LostFocus к TextBox
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (enterTextBox != null)
            {
                checkEmptyTextBox(sender, e);
            }
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

        // Переход к окну главному 
        public void GoMainWindow(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("open main window");
            MainWindow mainWindow = new MainWindow()
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = Left,
                Top = Top
            };

            this.Visibility = Visibility.Collapsed;
            mainWindow.Show();
        }


        /*//АВТОРИЗАЦИЯ ПОЛЬЗОВАТЕЛЯ
        public void AutorizationProcess(object sender, RoutedEventArgs e)
        {
            bool CheckAuorization = true;

            // Проверка на ввод 11 цифр
            if (!Regex.IsMatch(PhoneNumberAutorization.Text, @"^\d{11}$"))
            {
                MessageBox.Show("Please enter a valid phone number with 11 digits.");
                CheckAuorization = false;
                Console.WriteLine(3);
            }

            if (UserPasswordAutorization.Password.Length == 0)
            {
                MessageBox.Show("Please enter a password.");
                CheckAuorization = false;
                Console.WriteLine(4);
            }


            // Переход на окно Главное
            if (CheckAuorization)
            {
                Console.WriteLine("Успешная авторизация");
                GoMainWindow(null, null); // Переход на окно авторизации
            }
        }*/
    }
}
