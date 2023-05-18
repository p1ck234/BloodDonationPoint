using BloodDonationPoint.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace BloodDonationPoint
{
    /// <summary>
    /// Логика взаимодействия для DoctorPage.xaml
    /// </summary>
    public partial class DoctorPage : Page
    {
        public static Doctors selectEntites = new Doctors();
        public DoctorPage()
        {
            InitializeComponent();
            AvtorizationWindow.bd.Doctors.Load();
            lvDoctor.ItemsSource = AvtorizationWindow.bd.Doctors.Local;
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            selectEntites = (Doctors)lvDoctor.SelectedItem;
            if (selectEntites != null)
            {
                //BuyWindow bw = new BuyWindow();
               // bw.Show();
            }
        }
    }
}
