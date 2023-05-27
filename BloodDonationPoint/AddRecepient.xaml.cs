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
    /// Логика взаимодействия для AddRecepient.xaml
    /// </summary>
    public partial class AddRecepient : Window
    {
        public AddRecepient()
        {
            InitializeComponent();
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

        private void tbSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TbPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[[0-9\+]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbBloodType_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[[1-4]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void tbRH_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex input = new Regex(@"[[0-1]");
            Match match = input.Match(e.Text);
            if (!match.Success)
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            AvtorizationWindow.bd.Patients.Load();
            Patients current = new Patients();
            if (tbName.Text != "")
            {
                current.Name = tbName.Text;
                counter++;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали имя");
            }
            if (tbSurname.Text != "")
            {
                current.Surname = tbSurname.Text;
                counter++;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали фамилию");
            }
            if (tbFatherhood.Text != "")
            {
                current.Fatherhood = tbFatherhood.Text;
                counter++;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали отчество");
            }
            if (TbPhoneNumber.Text != "")
            {
                current.PhoneNumber = long.Parse(TbPhoneNumber.Text);
                counter++;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали номер телефона");
            }
            if (tbEmail.Text != "")
            {
                current.Email = tbEmail.Text;
                counter++;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали почту");
            }
            if (cbAntigenGipB.IsChecked == true && cbAntigenGipC.IsChecked == true && cbAntitelBIC.IsChecked == true && cbAntitelGipC.IsChecked == true &&
                cbAtigenBIC.IsChecked == true && cbBloodType.IsChecked == true && cbSifilic.IsChecked == true)
            {
                current.HepatitisBVirusAntigen = true;
                current.BloodType = true;
                current.HepatitisCVirusAntigen = true;
                current.HepatitisCVirusAntibodies = true;
                current.HIVAntigen = true;
                current.HIVAntibodies = true;
                current.Syphilis = true;
                counter++;
            }
            else
            {
                AvtorizationWindow.Exp("Обследования пройдены не все!");
            }
            if (tbDoctor.Text != "")
            {
                current.ID_Doctors = int.Parse(tbDoctor.Text);
                counter++;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали индификатор врача");
            }
            if (tbRH.Text != "")
            {
                current.RH = tbRH.Text;
                counter++;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали резус фактор");
            }
            if (tbBloodType.Text != "")
            {
                current.Blood = tbBloodType.Text;
                counter++;
            }
            else
            {
                AvtorizationWindow.Exp("Вы не указали группу крови");
            }

            if (counter == 9)
            {
                try
                {
                    AvtorizationWindow.bd.Patients.Add(current);
                    AvtorizationWindow.bd.SaveChanges();
                    AvtorizationWindow.Inf("Информация сохранена!");
                    this.Close();
                }
                catch
                {
                    AvtorizationWindow.Exp("Что-то пошло не так!");
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
