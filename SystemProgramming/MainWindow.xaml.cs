using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace SystemProgramming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Menu_First_Labs(object sender, RoutedEventArgs e)
        {
            var win = new MenuFirstLabs();
            win.Show();
        }

        private void Open_Menu_Second_Labs(object sender, RoutedEventArgs e)
        {
            var win = new MenuSecondLabs();
            win.Show();
        }

        private void Variant_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            string selectedItem = Variant_ComboBox.SelectedItem.ToString()
                .Split(new string[] { ": " }, StringSplitOptions.None).Last();

            // TODO: FIX this later
            try
            {
                Config.Variant = int.Parse(selectedItem);
            } 
            catch { }
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
