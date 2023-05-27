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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddDoctor mw = new AddDoctor();
            mw.Show();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.Doctors.Load();
            selectEntites = (Doctors)lvDoctor.SelectedItem;
            if (selectEntites != null)
            {
               if (MessageBox.Show("Вы действительно хотите удалить этот элемент из базы данных?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        AvtorizationWindow.bd.Doctors.Remove(selectEntites);
                        AvtorizationWindow.bd.SaveChanges();
                        lvDoctor.ItemsSource = AvtorizationWindow.bd.Doctors.Local.OrderBy(x => x.ID);
                        AvtorizationWindow.Inf("Элемент удален");
                    }
                    catch(Exception ex) 
                    {
                        AvtorizationWindow.Exp(ex.Message);
                    }
                }
            }
            else
            {
                AvtorizationWindow.Exp("Вы ничего не выбрали");
            }
        }

        private void btnRel_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.Doctors.Load();
            lvDoctor.ItemsSource = AvtorizationWindow.bd.Doctors.Local;
            AvtorizationWindow.Inf("Страница была обновлена!");
        }
    }
}
