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

namespace SystemProgramming.second_labs.forms.lab7
{
    /// <summary>
    /// Interaction logic for Lab7_second.xaml
    /// </summary>
    public partial class Lab7_second : Window
    {
        public Lab7_second()
        {
            InitializeComponent();
        }

        private void Loading_Text_Button_Click(object sender, RoutedEventArgs e)
        {
            Loading_TextBlock.Text = FileHelper.ReadFile(FileHelper.DirectoryPath);
        }

        private void Render_Button_Click(object sender, RoutedEventArgs e)
        {
            switch (Config.Variant)
            {
                case 18:
                    Render_TextBlock.Text = TextRender.ChangeVowelCase(Loading_TextBlock.Text);
                    break;
            }
        }

        private void SaveTextInFile_Button_Click(object sender, RoutedEventArgs e)
        {
            FileHelper.CreateOrUpdateFile(Render_TextBlock.Text, FileHelper.DirectoryPath);
        }
    }
}
