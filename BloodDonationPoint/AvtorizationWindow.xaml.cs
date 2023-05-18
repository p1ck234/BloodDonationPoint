using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BloodDonationPoint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AvtorizationWindow : Window
    {
        public static DataBase.BDBloodDonationEntities bd = new DataBase.BDBloodDonationEntities();
        public AvtorizationWindow()
        {
            InitializeComponent();
            bd.Manager.Load();
        }

        private void btnMinus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MainWindowBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void tbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (tbPassword.Password.Length > 0)
            {
                passWatermark.Visibility = Visibility.Collapsed;
            }
            else
            {
                passWatermark.Visibility = Visibility.Visible;
            }
        }

        int counter = 0;
        DispatcherTimer timer = new DispatcherTimer();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bd.Manager.Load();
            try
            {
                if (bd.Manager.Local.Where(x => x.Login == tbLogin.Text && x.Password == tbPassword.Password).FirstOrDefault() != null)
                {
                    MainWindow win = new MainWindow();
                    win.Show();
                    this.Close();
                }
                else
                {
                    Exp("Пользователя с такими данными нет!");
                    counter++;
                }
                if (counter >= 3)
                {
                    Inf("Вы ввели 3 раза неправильно пароль\nВвод пароля будет доступен через 10 секунд");
                    counter = 0;
                    timer = new DispatcherTimer();
                    timer.Tick += new EventHandler(timer_Tick);
                    timer.Interval = new TimeSpan(0, 0, 10);
                    btnLogin.Visibility = Visibility.Hidden;
                    timer.Start();
                }
            }
            catch (Exception ex)
            {
                Exp(ex.ToString());
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            btnLogin.Visibility = Visibility.Visible;
        }
        public static void Exp(string error)
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void Inf(string inf)
        {
            MessageBox.Show(inf, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnExitWin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbLogin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[a-zA-Z0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success) 
                { 
                    e.Handled = true;   
                }
        }
    }
}
