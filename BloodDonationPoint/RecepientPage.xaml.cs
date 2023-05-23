﻿using System;
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
        public RecepientPage()
        {
            InitializeComponent();
            AvtorizationWindow.bd.Patients.Load();
            dtgRecepient.ItemsSource = AvtorizationWindow.bd.Patients.Local.OrderBy(x => x.ID);
        }
    }
}
