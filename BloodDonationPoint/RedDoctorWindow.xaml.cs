using BloodDonationPoint.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для RedDoctorWindow.xaml
    /// </summary>
    public partial class RedDoctorWindow : Window
    {
        public RedDoctorWindow()
        {
            InitializeComponent();
            tbSurname.Text = DoctorPage.selectEntites.Surname;
            tbName.Text = DoctorPage.selectEntites.Name;
            tbFatherhood.Text = DoctorPage.selectEntites.Fatherhood;
            tbStage.Text = DoctorPage.selectEntites.Stage.ToString();
            tbMin.Text = DoctorPage.selectEntites.Number_of_patients.ToString();
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

        private void tbMin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[0-9]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
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
                AvtorizationWindow.Exp("Вы не указали фамилию");
            }
            if (tbName.Text != "")
            {
                current.Name = tbName.Text;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали имя");
            }
            if (tbFatherhood.Text != "")
            {
                current.Fatherhood = tbFatherhood.Text;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали отчество");
            }
            if (tbStage.Text != "")
            {
                current.Stage = int.Parse(tbStage.Text);
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали стаж");
            }
            if (tbMin.Text != "")
            {
                current.Number_of_patients = int.Parse(tbMin.Text);
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали занятость");
            }
            current.Manager = DoctorPage.selectEntites.Manager;
            current.Vacation = DoctorPage.selectEntites.Vacation;
            current.Maximum_number_of_patients = DoctorPage.selectEntites.Maximum_number_of_patients;
            current.MainImagePath = DoctorPage.selectEntites.MainImagePath;
            try
            {
                AvtorizationWindow.bd.Doctors.Remove(DoctorPage.selectEntites);
                AvtorizationWindow.bd.Doctors.Add(current);
                AvtorizationWindow.bd.SaveChanges();
                AvtorizationWindow.Inf("Информация изменена!");
                this.Close();
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
