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
    /// Логика взаимодействия для RecepientPage.xaml
    /// </summary>
    public partial class RecepientPage : Page
    {
        public static Patients selectEntites = new Patients();
        public RecepientPage()
        {
            InitializeComponent();
            AvtorizationWindow.bd.Patients.Load();
            dtgRecepient.ItemsSource = AvtorizationWindow.bd.Patients.Local.OrderBy(x => x.ID);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddRecepient mw = new AddRecepient();
            mw.Show();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.Patients.Load();
            selectEntites = (Patients)dtgRecepient.SelectedItem;
            if (selectEntites != null)
            {
                try
                {
                    if (MessageBox.Show("Вы действительно хотите удалить этот элемент из базы данных?","Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        AvtorizationWindow.bd.Patients.Remove(selectEntites);
                        AvtorizationWindow.bd.SaveChanges();
                        dtgRecepient.ItemsSource = AvtorizationWindow.bd.Patients.OrderBy(x => x.ID);
                        AvtorizationWindow.Inf("Информация сохранена!");
                    }
                }
                catch (Exception ex)
                {
                    AvtorizationWindow.Exp(ex.Message);
                }
            }
            else
            {
                AvtorizationWindow.Exp("Вы ничего не выбрали!");
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dtgRecepient_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            AvtorizationWindow.bd.Patients.Load();
            dtgRecepient.ItemsSource = AvtorizationWindow.bd.Patients.Local.OrderBy(x => x.ID);
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.Patients.Load();
            dtgRecepient.ItemsSource = AvtorizationWindow.bd.Patients.Local.OrderBy(x => x.ID);
        }
    }
}
