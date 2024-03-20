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
using SushiWorld.Properties;

namespace SushiWorld
{
    /// <summary>
    /// Логика взаимодействия для FoodCardWindow.xaml
    /// </summary>
    public partial class FoodCardWindow : Window
    {
        public DataBaseConnection dataBaseConnection = new DataBaseConnection();
        int countOfFood = 0;
        public string computerFoldersPATH = Convert.ToString(String.Join("\\", Environment.CurrentDirectory.ToString().Split('\\').Take(
    Environment.CurrentDirectory.ToString().Split('\\').Length - 2))) + "/Images/";

        public FoodCardWindow()
        {
            InitializeComponent();
            fillFoodCard();
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

        // Переход к окну регистрации
        public void GoBack(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("go back");

            OrderWindow orderWindow = new OrderWindow()
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = Left,
                Top = Top
            };

            this.Visibility = Visibility.Collapsed;
            orderWindow.Show();
        }

        // Увеличение картинки при наведении на кнопку
        public void DoBig(object sender, RoutedEventArgs e)
        {
            Border bigBorder = sender as Border;
            bigBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#936AD2");

        }
        // Уменьшение картинки при отведении мыши с кнопки
        public void DoSmall(object sender, RoutedEventArgs e)
        {
            Border smallBorder = sender as Border;
            smallBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#AB7AF5");
        }

        // Добавление в корзину
        public void TakeOrderClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("TakeOrder");
            
            // Добавление в КЕШ
            if (countOfFood == 0)
            {
                countOfFood++;
                Settings.Default["Basket"] += $"{Settings.Default["FoodName"].ToString()}|{countOfFood};";
                Settings.Default.Save();
                return;
            }

            countOfFood++;

            List<string> newArray = spliter();
            Settings.Default["Basket"] = String.Join(";", newArray);
            Settings.Default.Save();
            Settings.Default["Basket"] += $"{Settings.Default["FoodName"].ToString()}|{countOfFood};";
            Settings.Default.Save();

            /*List<string> BasketFoodArray = spliter();
            BasketFoodArray.Add($"{Settings.Default["FoodName"].ToString()}|{countOfFood}");
            BasketFoodArray.Sort();
            Settings.Default["Basket"] = String.Join(";", BasketFoodArray);
            Settings.Default.Save();*/

        }

        // Разделение строки кеша на отдельные компоненты
        private List<string> spliter()
        {
            // Разделение кеша на отдельные блюда
            string[] array = Settings.Default["Basket"].ToString().Split(';');
            List<string> returnArray = new List<string>();
            foreach (string arrayElement in array)
            {
                if (arrayElement.Split('|')[0] != Settings.Default["FoodName"].ToString() && arrayElement.Length != 0)
                {
                    returnArray.Add(arrayElement);
                }
            }

            return returnArray;
        }

        // WPF--------------------------------------
        private void fillFoodCard()
        {
            Ingridient.Children.Add(createIngridientBorder("Ингридиенты"));
            foreach (var item in dataBaseConnection.returnAllFoodInformation(Settings.Default["FoodName"].ToString()))
            {
                switch (item.Key)
                {
                    case ("Название"):
                        Title.Child = createTitle(item.Value);
                        break;
                    case ("Цена"):
                        Cost.Child = NormalText("Цена: " + item.Value);
                        break;
                    case ("Вес"):
                        Weight.Child = NormalText("Вес: " + item.Value);
                        break;
                    case ("Рейтинг"):
                        Rating.Child = NormalText("Оценка: " + item.Value);
                        break;
                    case ("Время"):
                        Time.Child = createTimeTextBlock(item.Value);
                        break;
                    case ("Ингридиент"):
                        foreach (var word in item.Value.Split('-'))
                        {
                            if (word.Length != 0)
                                Ingridient.Children.Add(createIngridientBorder(word));
                        }
                        
                        break;
                    case ("Фото"):
                        Photo.Child = generateFoodImage(item.Value);
                        break;
                }
            }
        }


        private TextBlock createTitle(string Title)
        {
            TextBlock titleText = new TextBlock()
            {
                FontSize = 40,
                
                TextWrapping = TextWrapping.Wrap,
                Text = Title,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                
            };
            return titleText;
        }

        private TextBlock createTimeTextBlock(string Time)
        {
            TextBlock timer = new TextBlock()
            {
                FontSize = 20,
                
                TextWrapping = TextWrapping.Wrap,
                Text = $"Время готовки:\n{Time.Split(':')[0]} час\n{Time.Split(':')[1]} мин\n{(Time.Split(':')[2]).Split('.')[0]} сек",
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            return timer;
        }

        private TextBlock NormalText(string message)
        {
            TextBlock normalText = new TextBlock()
            {
                FontSize = 20,
                
                TextWrapping = TextWrapping.Wrap,
                Text = message,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            return normalText;
        }

        private Image generateFoodImage(string foodImageName)
        {
            Image foodCardPicture = new Image()
            {
                Height = 280,
                Width = 430,
                Source = new BitmapImage(
                new Uri(
                       $@"{computerFoldersPATH}{foodImageName}")),
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,

            };
            return foodCardPicture;
        }

        private Border createIngridientBorder(string ingridient)
        {
            Border showerIng = new Border()
            {
                Height = 50,
                Width=150,
                HorizontalAlignment = HorizontalAlignment.Left,
                Background = new SolidColorBrush(Colors.White),
                CornerRadius = new CornerRadius(15),
                Margin =new Thickness(10, 5, 0, 0),
                BorderBrush = new SolidColorBrush(Colors.Black),
                BorderThickness = new Thickness(2)
            };

            TextBlock ingr = new TextBlock()
            {
                FontSize = 15,
                
                TextWrapping = TextWrapping.Wrap,
                Text = ingridient,
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = new SolidColorBrush(Colors.Black)
            };

            showerIng.Child = ingr;
            return showerIng;
        }
    }
}
