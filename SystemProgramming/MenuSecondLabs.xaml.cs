using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SystemProgramming.second_labs.forms.lab2;

namespace SystemProgramming
{
    /// <summary>
    /// Interaction logic for MenuSecondLabs.xaml
    /// </summary>
    public partial class MenuSecondLabs : Window
    {
        public MenuSecondLabs()
        {
            InitializeComponent();
        }

        private void open_lab2_second_Click(object sender, RoutedEventArgs e)
        {
            switch(Config.Variant)
            {
                case 1:
                    var win1 = new Lab2_Variant_1_Second_Window();
                    win1.Show();
                    break;

                case 18:
                    var win18 = new Lab2_Variant_18_Second_Window();
                    win18.Show();
                    break;
            }

            
        }

        private void open_lab3_second_Click(object sender, RoutedEventArgs e)
        {

        }

        private void open_lab4_5_second_Click(object sender, RoutedEventArgs e)
        {

        }

        private void open_lab6_second_Click(object sender, RoutedEventArgs e)
        {

        }

        private void open_lab7_second_Click(object sender, RoutedEventArgs e)
        {

        }

        private void open_lab8_second_Click(object sender, RoutedEventArgs e)
        {

        }

        private void open_lab10_second_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
