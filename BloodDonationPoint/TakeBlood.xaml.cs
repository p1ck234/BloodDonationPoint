using BloodDonationPoint.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
using System.Windows.Shapes;

namespace BloodDonationPoint
{
    /// <summary>
    /// Логика взаимодействия для TakeBlood.xaml
    /// </summary>
    public partial class TakeBlood : Window
    {
        public TakeBlood()
        {
            InitializeComponent();
            List<string> list = new List<string>();
            list.Add("Кровь");
            list.Add("Плазма");
            cbComponent.ItemsSource = list;
            cbComponent.SelectedIndex = 0;
            tbIDDonor.Text = RecepientPage.selectEntites.ID.ToString();
            tbBloodType.Text = RecepientPage.selectEntites.Blood.ToString();
            tbRH.Text = RecepientPage.selectEntites.RH.ToString();
        }

        private void tbIDDonor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbBloodType_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbRH_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.Patients.Load();
            AvtorizationWindow.bd.BloodStorage.Load();
            BloodStorage current = new BloodStorage();
            if (tbIDDonor.Text != "")
            {
                current.ID_Donor = int.Parse(tbIDDonor.Text);
            }
            else AvtorizationWindow.Exp("Вы не указали ID донора");
            if (tbBloodType.Text != "")
            {
                current.Group = tbBloodType.Text;
            }
            else AvtorizationWindow.Exp("Вы не указали группу крови");

            if (tbRH.Text != "")
            {
                current.Rh = tbRH.Text;
            }
            else AvtorizationWindow.Exp("Вы не указали резус фактор");
            if (cbComponent.SelectedIndex == 0)
            {
                current.Component = "Кровь";
            }
            else if (cbComponent.SelectedIndex == 1)
            {
                current.Component = "Плазма";
            }
            current.Date_Sbora = DateTime.Now;
            try
            {
                AvtorizationWindow.bd.BloodStorage.Add(current);
                AvtorizationWindow.bd.SaveChanges();
            }
            catch
            {
                AvtorizationWindow.Exp("Что-то пошло не так!");
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
