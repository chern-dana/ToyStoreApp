using System;
using System.Windows;
using ToyStore.Windows;

namespace ToyStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginWindow lw = new LoginWindow();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (LoginWindow.user == true)
            {
                btnOrder.Visibility = Visibility.Hidden;
                chkBear.IsEnabled = false;
                chkDoll.IsEnabled = false;
                chkHorse.IsEnabled = false;
                chkHouse.IsEnabled = false;
                chkLego.IsEnabled = false;
                chkRobot.IsEnabled = false;
                lblUser.Content = "Администратор";
            }
            else
            {
                txtBear.IsEnabled = false;
                txtDoll.IsEnabled = false;
                txtHorse.IsEnabled = false;
                txtHouse.IsEnabled = false;
                txtLego.IsEnabled = false;
                txtRobot.IsEnabled = false;
                lblUser.Content = "Покупатель";
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            ReceiptWindow rw = new ReceiptWindow();

            double Sum = 0;     //стоимость покупки

            if (chkBear.IsChecked == true)
                Sum = Sum + 559.99;
            if (chkDoll.IsChecked == true)
                Sum = Sum + 489.99;
            if (chkRobot.IsChecked == true)
                Sum = Sum + 1699.99;
            if (chkHorse.IsChecked == true)
                Sum = Sum + 899.99;
            if (chkLego.IsChecked == true)
                Sum = Sum + 1899.99;
            if (chkHouse.IsChecked == true)
                Sum = Sum + 1499.99;

            if (Sum != 0)
            {
                if (Sum > 4000.00)
                {
                    double Sale = Math.Round(Sum * 0.1, 2);        //скидка
                    double SaleSum = Math.Round(Sum - Sale, 2);    //стоимость покупки с учётом скидки

                    string receipt = $"Чек на покупку в магазине «Toy Store»\n" +   //текст чека
                        $"\nСтоимость вашего заказа: {Sum} руб." +
                        $"\nСкидка: {Sale} руб.\n\nИтого: {SaleSum} руб.";

                    rw.payInbox = receipt;
                    rw.Show();
                    Close();
                }

                else
                {
                    string receipt = $"Чек на покупку в магазине «Toy Store»\n\nИтого: {Sum} руб.";
                    rw.payInbox = receipt;
                    rw.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Корзина пуста.",
                        "Toy Store");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lw.Show();
            Close();
        }
    }
}

