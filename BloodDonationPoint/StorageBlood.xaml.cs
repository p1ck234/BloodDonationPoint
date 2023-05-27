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

        }

        private void btnRel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
