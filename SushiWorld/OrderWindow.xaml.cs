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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public DataBaseConnection databaseConnection = new DataBaseConnection();

        public string computerFoldersPATH = Convert.ToString(String.Join("\\", Environment.CurrentDirectory.ToString().Split('\\').Take(
    Environment.CurrentDirectory.ToString().Split('\\').Length - 2))) + "/Images/";
        public OrderWindow()
        {
            InitializeComponent();
            
            generateFoodCard(databaseConnection.returnFoodInformation("ВОДА"));

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
            
            MainWindow mainWindow = new MainWindow()
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = Left,
                Top = Top
            };

            this.Visibility = Visibility.Collapsed;
            mainWindow.Show();
        }
        // Переход в карточку товара
        public void openFoodCard(string cardFoodName)
        {
            Console.WriteLine("go карточка товара");
            Settings.Default["FoodName"] = String.Join(" ", cardFoodName.Split('_'));
            Settings.Default.Save();

            FoodCardWindow foodCardWindow = new FoodCardWindow()
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = Left,
                Top = Top
            };

            this.Visibility = Visibility.Collapsed;
            foodCardWindow.Show();
        }
        // Подкнимаем пункт меню
        public void Up(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(sender);
            Border menuPoint = sender as Border;
            Console.WriteLine(menuPoint.Name.ToString());
            menuPoint.Height = 150;
            menuPoint.Margin = new Thickness(0, -50, 20, 0);
            menuPoint.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#5134A8");
            menuPoint.BorderBrush = new SolidColorBrush(Colors.Black);
            menuPoint.BorderThickness = new Thickness(3);
        }

        // Опускаем пункит меню
        public void Down(object sender, RoutedEventArgs e)
        {
            Border menuPoint = sender as Border;
            menuPoint.Height = 100;
            menuPoint.Margin = new Thickness(0, 0, 20, 0);
            menuPoint.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#5D00CC");
            menuPoint.BorderBrush = new SolidColorBrush(Colors.Transparent);
            menuPoint.BorderThickness = new Thickness(0);
        }

        // Выбор пункта
        public void ChooseFood(object sender, RoutedEventArgs e)
        {
            Border foodCategory = sender as Border;
            Dictionary<string, Dictionary<string, string>> returnedFoodInformation;
            returnedFoodInformation =
                databaseConnection.returnFoodInformation(foodCategory.Name.ToString());
            generateFoodCard(returnedFoodInformation);
            

        }

        

        public void generateFoodCard(Dictionary<string, Dictionary<string, string>> returnedFoodInformation)
        {
            scrollFoodCard.Children.Clear();
            Image foodPicture = new Image();
            TextBlock Title = new TextBlock();
            TextBlock cost = new TextBlock();
            TextBlock weight = new TextBlock();
            TextBlock rating = new TextBlock();
            TextBlock count = new TextBlock();
            foreach (var food in returnedFoodInformation)
            {
                Console.WriteLine(food.Key);
                
                Grid cardBorder = generateBorder();
                Title = generateTitleText(food.Key);
                StackPanel cardPanel = new StackPanel();
                cardPanel = generateStackTextPanel();
                foreach (var inf in food.Value)
                {
                    Console.WriteLine(inf.Key + ": " + inf.Value);
                    switch(inf.Key)
                    {
                        case ("Фото"):
                            foodPicture = generateFoodImage(inf.Value);
                            break;
                        case ("Цена"):
                            cost = generateNormalText("Цена: " + inf.Value);
                            break;
                        case ("Вес"):
                            weight = generateNormalText("Вес: " + inf.Value);
                            break;
                        case ("Рейтинг"):
                            rating = generateNormalText("Оценка: " + inf.Value);
                            break;
                        case ("Количество"):
                            count = generateNormalText("В наборе: " + inf.Value + " шт.");
                            break;

                    }
                    
                }
                Console.WriteLine("\n");
                cardPanel.Children.Add(Title);
                cardPanel.Children.Add(cost);
                cardPanel.Children.Add(weight);
                cardPanel.Children.Add(rating);
                cardPanel.Children.Add(count);
                
                string orderBRNnasme = String.Join("_", food.Key.ToString().Split(' '));
               
                cardBorder.Children.Add(createBottomBorder());
                cardBorder.Children.Add(cardPanel);
                cardBorder.Children.Add(foodPicture);
                cardBorder.Children.Add(createOrderButton(orderBRNnasme));
                
                

                scrollFoodCard.Children.Add(cardBorder);
            }
        }

        // WPF ---------------------------------------------------------------
        private Border createOrderButton(string buttonName)
        {
            Console.WriteLine(buttonName);
            Border orderButton = new Border()
            {
                Name = buttonName,
                Height = 200,
                Width = 200,
                CornerRadius = new CornerRadius(10),
                Background = new SolidColorBrush(Colors.Black),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 30, 0),

            };

            TextBlock content = new TextBlock()
            {
                Text = "Подробнее",
                Foreground = new SolidColorBrush(Colors.White),
                FontSize = 30,
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            orderButton.Child = content;

            orderButton.MouseDown += (sender, args) =>
            {
                Console.WriteLine("Подробнее");
                openFoodCard(buttonName);
            };

            return orderButton;
        }
        private TextBlock generateTitleText(string titleText)
        {
            TextBlock Title = new TextBlock()
            {
                FontSize = 40,
                
                TextWrapping = TextWrapping.Wrap,
                Text = titleText,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Top,
                Padding = new Thickness(50, 0, 0, 0)
            };
            return Title;
        }

        private Border createBottomBorder()
        {
            Border TopB = new Border
            {
                Height = 10,
                Background = new SolidColorBrush(Colors.Black),
                VerticalAlignment = VerticalAlignment.Bottom
            };
            return TopB;
        }

        private StackPanel generateStackTextPanel()
        {
            StackPanel textSetter = new StackPanel()
            {
                Width = 420,
                VerticalAlignment= VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                
            };
            return textSetter;
        }
        private TextBlock generateNormalText(string message)
        {
            TextBlock normalText = new TextBlock()
            {
                FontSize = 25,
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Top,
                Padding = new Thickness(50, 0, 0, 0)
            };
            return normalText;
        }
        private Grid generateBorder()
        {
            Grid cardBorder = new Grid()
            {
                Height = 300,
                Width = 1000,
                HorizontalAlignment = HorizontalAlignment.Right,
                Background = new SolidColorBrush(Colors.Pink),

            };

            return cardBorder;
        }

        private Image generateFoodImage(string foodImageName)
        {
            Console.WriteLine(foodImageName);
            Image foodCardPicture = new Image()
            {
                Height = 250,
                Width = 280,
                Source = new BitmapImage(
                new Uri(
                       $@"{computerFoldersPATH}{foodImageName}")),
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(50,0,0,0),
                VerticalAlignment = VerticalAlignment.Center,

            };
            return foodCardPicture;
        }


    }


}
