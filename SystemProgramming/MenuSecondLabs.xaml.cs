using System.Windows;
using SystemProgramming.second_labs.forms.lab10;
using SystemProgramming.second_labs.forms.lab2;
using SystemProgramming.second_labs.forms.lab3;
using SystemProgramming.second_labs.forms.lab4_5;
using SystemProgramming.second_labs.forms.lab7;
using SystemProgramming.second_labs.forms.lab8;

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
            switch (Config.Variant)
            {
                case 18:
                    var win18 = new Lab3_Variant_18_Second_Window();
                    win18.Show();
                    break;
            }
        }

        private void open_lab4_5_second_Click(object sender, RoutedEventArgs e)
        {
            switch (Config.Variant)
            {
                case 18:
                    var win18 = new Lab4_5_Variant_18_Second_Window();
                    win18.Show();
                    break;
            }
        }

        private void open_lab6_second_Click(object sender, RoutedEventArgs e)
        {

        }

        private void open_lab7_second_Click(object sender, RoutedEventArgs e)
        {
            switch (Config.Variant)
            {
                case 18:
                    var win18 = new Lab7_second();
                    win18.Show();
                    break;
            }
        }

        private void open_lab8_second_Click(object sender, RoutedEventArgs e)
        {
            if (Config.Variant % 2 == 0)
            {
                var win1 = new Lab8_Even_Variants_Second();
                win1.Show();
            }
            else
            {
                var win2 = new Lab8_Odd_Variants_Second();
                win2.Show();
            }
        }

        private void open_lab10_second_Click(object sender, RoutedEventArgs e)
        {
            var win = new Lab10();
            win.Show();
        }
    }
}
