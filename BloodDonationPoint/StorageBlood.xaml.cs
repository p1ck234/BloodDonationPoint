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
    /// Логика взаимодействия для BloodStorage.xaml
    /// </summary>
    public partial class StorageBlood : Page
    {
        public StorageBlood()
        {
            InitializeComponent();
            AvtorizationWindow.bd.BloodStorage.Load();
            dtgBloodStorage.ItemsSource = AvtorizationWindow.bd.BloodStorage.Local;
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.BloodStorage.Load();
            BloodStorage select = new BloodStorage();
            if (dtgBloodStorage.SelectedItem != null)
            {
                select = (BloodStorage)dtgBloodStorage.SelectedItem;
                if (MessageBox.Show("Вы действительно хотите удалить этот элемент из базы данных?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        AvtorizationWindow.bd.BloodStorage.Remove(select);
                        AvtorizationWindow.bd.SaveChanges();

                    }
                    catch
                    {
                        AvtorizationWindow.Exp("Что-то пошло не так!");
                    }
                }
            }
            else
            {
                AvtorizationWindow.Exp("Вы ничего не выбрали!");
            }
        }

        private void btnRel_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.BloodStorage.Load();
            dtgBloodStorage.ItemsSource = AvtorizationWindow.bd.BloodStorage.Local.OrderBy(x => x.ID);
            AvtorizationWindow.Inf("Страница была обновлена");
        }
    }
}
