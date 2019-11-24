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

namespace X4StationPlannerWpf
{
    /// <summary>
    /// Interaction logic for Factions.xaml
    /// </summary>
    public partial class Factions : Window
    {
        public Factions()
        {
            InitializeComponent();
            Closing += Factions_Closing;
        }

        public bool timeToClose = false;

        private void Factions_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!timeToClose)
            {
                Hide();
                e.Cancel = true;
            }
        }
    }
}
