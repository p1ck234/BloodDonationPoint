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
    /// Логика взаимодействия для SelectDoctor.xaml
    /// </summary>
    public partial class AddDoctor : Window
    {
        public AddDoctor()
        {
            InitializeComponent();
            AvtorizationWindow.bd.Doctors.Load();
        }
       
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AvtorizationWindow.bd.Doctors.Load();
            Doctors current = new Doctors();
            if (tbSurname.Text != "")
            {
                current.Surname = tbSurname.Text;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали фамилию!");
            }
            if (tbName.Text != "")
            {
                current.Name = tbName.Text;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали имя!");
            }
            if (tbFatherhood.Text != "")
            {
                current.Fatherhood = tbFatherhood.Text;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали отчество!");
            }
            if (tbStage.Text != "")
            {
                current.Stage = int.Parse(tbStage.Text);
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали стаж!");
            }
            if (tbMax.Text != "")
            {
                current.Maximum_number_of_patients = int.Parse(tbMax.Text);
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали максимально кол-во пациентов!");
            }
            current.Number_of_patients = 0;
            current.Vacation = false;
            current.ID_Manager = 1;

            try
            {
                AvtorizationWindow.bd.Doctors.Add(current);
                AvtorizationWindow.bd.SaveChanges();
                AvtorizationWindow.Inf("Информация сохранена!");
                this.Close();
            }
            catch (Exception ex)
            {
                AvtorizationWindow.Exp(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[а-яА-Я]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[а-яА-Я]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbFatherhood_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[а-яА-Я]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbStage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbMax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }
    }
}
