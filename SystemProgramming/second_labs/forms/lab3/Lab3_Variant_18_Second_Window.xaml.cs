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

namespace SystemProgramming.second_labs.forms.lab3
{
    /// <summary>
    /// Interaction logic for Lab3_Variant_18_Second_Window.xaml
    /// </summary>
    public partial class Lab3_Variant_18_Second_Window : Window
    {
        public Lab3_Variant_18_Second_Window()
        {
            InitializeComponent();
        }

        private void Handler_Change_HorizontalAligment_Center(object sender, RoutedEventArgs e)
        {
            SetHorizontalContent("center");
        }

        private void Handler_Change_HorizontalAligment_Right(object sender, RoutedEventArgs e)
        {
            SetHorizontalContent("right");
        }

        private void Handler_Change_HorizontalAligment_Left(object sender, RoutedEventArgs e)
        {
            SetHorizontalContent("left");
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Slider.Value < 1.5) SetHorizontalContent("left");
            if (Slider.Value > 1.5 && Slider.Value < 2.5) SetHorizontalContent("center");
            if (Slider.Value > 2.5) SetHorizontalContent("right");
        }

        private void SetHorizontalContent(string value)
        {
            switch (value)
            {
                case "center":
                    labelGroup.HorizontalContentAlignment = HorizontalAlignment.Center;
                    break;
                case "right":
                    labelGroup.HorizontalContentAlignment = HorizontalAlignment.Right;
                    break;
                case "left":
                    labelGroup.HorizontalContentAlignment = HorizontalAlignment.Left;

                    break;
            }

            TextBox.Text = value;
        }
    }
}
