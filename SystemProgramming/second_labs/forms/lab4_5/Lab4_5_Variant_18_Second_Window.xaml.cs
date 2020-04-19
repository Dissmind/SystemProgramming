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

namespace SystemProgramming.second_labs.forms.lab4_5
{
    /// <summary>
    /// Interaction logic for Lab4_Variant_18_Second_Window.xaml
    /// </summary>
    public partial class Lab4_5_Variant_18_Second_Window : Window
    {
        public Lab4_5_Variant_18_Second_Window()
        {
            InitializeComponent();

            //MainGrid.Children.Add(PaintingChestBoard());

            MainCanvas.Children.Add(PaintingChestBoard());

            Ellipse el = new Ellipse();
            el.Fill = Brushes.Blue;
            el.Width = 30;
            el.Height = 30;

            MainCanvas.Children.Add(el);

            Canvas.SetLeft(el, 10);
            Canvas.SetTop(el, 10);
        }

        private static Canvas PaintingChestBoard()
        {
            Canvas canvasArea = new Canvas();

            canvasArea.Width = 450;
            canvasArea.Height = 450;
            canvasArea.Background = Brushes.Blue; 

            int[] cordPoints = { 0, 0, 50, 0, 50, 50, 0, 50 };

            for (int i = 1; i < 9 * 9 + 1; i++)
            {
                Polygon pl = new Polygon();

                pl.Points = new PointCollection();

                pl.Points.Add(new Point(cordPoints[0], cordPoints[1]));
                pl.Points.Add(new Point(cordPoints[2], cordPoints[3]));
                pl.Points.Add(new Point(cordPoints[4], cordPoints[5]));
                pl.Points.Add(new Point(cordPoints[6], cordPoints[7]));

                if (i % 2 == 0) pl.Fill = Brushes.Black;
                else pl.Fill = Brushes.White;

                pl.Stroke = Brushes.Black;
                //pl.Fill = Brushes.Black;

                canvasArea.Children.Add(pl);

                // Переход на следующую строчку
                if (i % 9 == 0)
                {
                    for (int j = 0; j < cordPoints.Length; j++)
                    {
                        if (j % 2 != 0) cordPoints[j] += 50;
                    }

                    cordPoints[0] = 0;
                    cordPoints[2] = 50;
                    cordPoints[4] = 50;
                    cordPoints[6] = 0;
                }
                // Переход на следующий элемент 
                else for (int j = 0; j < cordPoints.Length; j++) if (j % 2 == 0) cordPoints[j] += 50;


                //TODO: for animation - for (int j = 0; j < cordPoints.Length; j++) cordPoints[j] += 50;
            }

            return canvasArea;
        }
    }
}
