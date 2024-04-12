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
    /// Логика взаимодействия для BasketWindow.xaml
    /// </summary>
    public partial class BasketWindow : Window
    {
        public DataBaseConnection databaseConnection = new DataBaseConnection();
        public string computerFoldersPATH = Convert.ToString(String.Join("\\", Environment.CurrentDirectory.ToString().Split('\\').Take(
        Environment.CurrentDirectory.ToString().Split('\\').Length - 2))) + "/Images/";

        public int refreshCount = 0;
        public BasketWindow()
        {
            InitializeComponent();
            generateFoodCard();
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

        // Кнопка оплаты
        // Расширение кнолпки оплаты
        public void DoFatPay(object sender, RoutedEventArgs e)
        {
            Border bigBorder = sender as Border;
            bigBorder.Width = 330;
            bigBorder.Height = 105;
            bigBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#936AD2");
        }
        // Уменьшение кнопки оплатв
        public void DoNormalPay(object sender, RoutedEventArgs e)
        {
            Border smallBorder = sender as Border;
            smallBorder.Width = 300;
            smallBorder.Height = 90;
            smallBorder.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#AB7AF5");
        }

        // Уменьшение картинки при отведении мыши с кнопки
        public void PaymentClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(1);
        }

        // Переход к главному окну
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

        private bool canUserProceedToPayment;

        public void generateFoodCard()
        {
            scrollFoodCard.Children.Clear();


            //Если корзина пуста
            Console.WriteLine(Settings.Default["Basket"].ToString().Split(';').Length);
            Console.WriteLine(Settings.Default["Basket"].ToString());
            if (Settings.Default["Basket"].ToString().Length == 0)
            {

                ShowerItems.Child = generateEmptyBasketPicture();
                canUserProceedToPayment = false;

                //Излишнее упоминание ято корзина пуста
                //MessageBox.Show("Корзина пуста", "Тех-поддержка", MessageBoxButton.OK);

                return;
            }

            foreach (var food in Settings.Default["Basket"].ToString().Split(';'))
            {
                if (food.Length > 0)
                {
                    TextBlock Title = new TextBlock();
                    TextBlock cost = new TextBlock();
                    TextBlock weight = new TextBlock();
                    Image picture = new Image();
                    Grid cardBorder = generateGrid();

                    StackPanel cardPanel = new StackPanel();
                    cardPanel = generateStackTextPanel();
                    Console.WriteLine(food);

                    foreach (var informationPoint in databaseConnection.returnBasketFoodInf(food.Split('|')[0]))
                    {


                        Console.WriteLine(informationPoint.Key + ": " + informationPoint.Value);
                        switch (informationPoint.Key)
                        {
                            case ("Название"):
                                Title = generateTitleText(informationPoint.Value);
                                break;
                            case ("Цена"):
                                cost = generateNormalText("Цена: " + informationPoint.Value);
                                break;
                            case ("Вес"):
                                weight = generateNormalText("Вес: " + informationPoint.Value);
                                break;
                            case ("Фото"):
                                picture = generateFoodImage(informationPoint.Value);
                                break;

                        }


                        Console.WriteLine("\n");

                    }
                    cardPanel.Children.Add(Title);
                    cardPanel.Children.Add(cost);
                    cardPanel.Children.Add(weight);
                    cardBorder.Children.Add(picture);
                    cardPanel.Children.Add(ReturnCount("В заказе: " + food.Split('|')[1] + "шт."));

                    string MinusFoodName = String.Join("_", food.Split('|')[0].ToString().Split(' '));
                    string PlusFoodName = String.Join("R", food.Split('|')[0].ToString().Split(' '));


                    cardBorder.Children.Add(createBottomBorder());
                    cardBorder.Children.Add(cardPanel);

                    cardBorder.Children.Add(MinusFood(MinusFoodName, Convert.ToInt32(food.Split('|')[1].ToString())));
                    cardBorder.Children.Add(PlusFood(PlusFoodName, Convert.ToInt32(food.Split('|')[1].ToString())));



                    scrollFoodCard.Children.Add(cardBorder);
                }



            }
        }

        // Перерассчет количества
        public void TakeOrderClick(string refreshFoodName)
        {
            Console.WriteLine("TakeOrder");
            // Добавление в КЕШ
            if (refreshCount == -1)
            {

                if (MessageBox.Show("Вы хотите удалить блюдо?", "Тех-поддержка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    List<string> deleteArray = spliter(refreshFoodName);
                    Settings.Default["Basket"] = String.Join(";", deleteArray);
                    Settings.Default.Save();


                    generateFoodCard();
                }

                return;
            }

            // Увеличение количества добавленных в корзину блюд
            refreshCount++;

            // Создание списка с добаленными блюдами и их количеством
            List<string> BasketFoodArray = spliter(refreshFoodName);
            BasketFoodArray.Add($"{refreshFoodName.ToString()}|{refreshCount}");
            BasketFoodArray.Sort();
            Settings.Default["Basket"] = String.Join(";", BasketFoodArray);
            Settings.Default.Save();

            generateFoodCard();

        }

        // Разделение строки кеша на отдельные компоненты
        private List<string> spliter(string refreshFoodName)
        {
            // Разделение кеша на отдельные блюда
            string[] array = Settings.Default["Basket"].ToString().Split(';');
            List<string> returnArray = new List<string>();
            foreach (string arrayElement in array)
            {
                if (arrayElement.Split('|')[0] != refreshFoodName.ToString() && arrayElement.Length != 0)
                {
                    returnArray.Add(arrayElement);
                }
            }

            return returnArray;
        }

        // WPF ---------------------------------------------------------------

        private TextBlock ReturnCount(string message)
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

        // Удаление блюда
        private Border MinusFood(string buttonName, int count)
        {
            Console.WriteLine(buttonName);
            Border minusFoodButton = new Border()
            {
                Name = buttonName,
                Height = 100,
                Width = 100,
                CornerRadius = new CornerRadius(25),
                Background = new SolidColorBrush(Colors.Red),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, 30, 30),

            };

            Border minus = new Border()
            {
                Height = 20,
                Width = 50,
                CornerRadius = new CornerRadius(5),
                Background = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,


            };

            minusFoodButton.Child = minus;
            minusFoodButton.MouseDown += (sender, args) =>
            {
                refreshCount = count - 2;
                Console.WriteLine("Подробнее");
                TakeOrderClick(String.Join(" ", buttonName.Split('_')));
            };

            return minusFoodButton;
        }

        // Добавление блюда

        private Border PlusFood(string buttonName, int count)
        {
            Console.WriteLine(buttonName);
            Border plusFoodButton = new Border()
            {
                Name = buttonName,
                Height = 100,
                Width = 100,
                CornerRadius = new CornerRadius(25),
                Background = new SolidColorBrush(Colors.Green),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 30, 30, 0),

            };
            Grid grid = new Grid()
            {
                Height = 50,
                Width = 50,


                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,


            };

            Border PlusH = new Border()
            {
                Height = 20,
                Width = 50,
                CornerRadius = new CornerRadius(5),
                Background = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,


            };

            Border PlusV = new Border()
            {
                Height = 50,
                Width = 20,
                CornerRadius = new CornerRadius(5),
                Background = new SolidColorBrush(Colors.White),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,


            };

            grid.Children.Add(PlusV);
            grid.Children.Add(PlusH);

            plusFoodButton.Child = grid;
            plusFoodButton.MouseDown += (sender, args) =>
            {
                refreshCount = count;
                Console.WriteLine("Подробнее");
                TakeOrderClick(String.Join(" ", buttonName.Split('R')));
            };

            return plusFoodButton;
        }
        private TextBlock generateTitleText(string titleText)
        {
            TextBlock Title = new TextBlock()
            {
                FontSize = 40,
                Height = 50,
                TextWrapping = TextWrapping.Wrap,
                Text = titleText,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Top,
                Padding = new Thickness(50, 0, 0, 0)
            };
            return Title;
        }

        //Создание границы для кнопок
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

        //Создание границы для кнопок
        private StackPanel generateStackTextPanel()
        {
            StackPanel textSetter = new StackPanel()
            {
                Width = 420,
                Height = 200,
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
        private Grid generateGrid()
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
                Height = 280,
                Width = 280,
                Source = new BitmapImage(
                new Uri(
                       $@"{computerFoldersPATH}{foodImageName}")),
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(50, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,

            };
            return foodCardPicture;
        }

        // Генерация картинки пустой корзины
        private Image generateEmptyBasketPicture()
        {

            Image foodCardPicture = new Image()
            {
                Height = 300,
                Width = 300,
                Source = new BitmapImage(
                new Uri(
                       $@"{computerFoldersPATH}Корзина пуста.png")),
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,


            };
            return foodCardPicture;
        }

        // Переход к окну Оплаты
        public void GoPaymentWindow(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Settings.Default["Basket"].ToString()))
            {

                InitializeComponent();
                if (UserAccount.UserIsAutorizated)
                {
                    Console.WriteLine("open PaymentWindow");
                    PaymentWindow PaymentWindow = new PaymentWindow()
                    {
                        WindowStartupLocation = WindowStartupLocation.Manual,
                        Left = Left,
                        Top = Top
                    };
                    this.Visibility = Visibility.Collapsed;
                    PaymentWindow.Show();
                }
                else
                {
                    Console.WriteLine("Корзина пуста, оплата невозможна");
                    MessageBox.Show("Перед оплатой необходимо авторизоваться");
                }
            }
            else
            {
                Console.WriteLine("Корзина пуста, оплата невозможна");
                MessageBox.Show("Перед оплатой поместите товары в корзину");
            }
        }
    }
}
//UserIsAutorizated