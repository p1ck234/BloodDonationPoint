﻿using System;
using System.Collections.Generic;
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

        }
    }
}
