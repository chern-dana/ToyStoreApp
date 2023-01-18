using System.Windows;

namespace ToyStore
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static bool user;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();

            if (txtLogin.Text == "" || pswPassword.Password == "")
                MessageBox.Show("Не все данные введены");
            else
            {
                if (txtLogin.Text == "admin" && pswPassword.Password == "admin")
                {
                    user = true;
                    mw.Show();
                    Close();
                }
                else
                {
                    if (txtLogin.Text == "customer" && pswPassword.Password == "customer")
                    {
                        user = false;
                        mw.Show();
                        Close();
                    }
                    else
                        MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (chkShow.IsChecked.Value)
            {
                txtPassword.Text = pswPassword.Password;
                txtPassword.Visibility = Visibility.Visible;
                pswPassword.Visibility = Visibility.Hidden;
            }
            else
            {
                pswPassword.Password = txtPassword.Text;
                pswPassword.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Hidden;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
