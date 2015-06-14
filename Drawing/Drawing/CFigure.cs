using System.Windows.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Drawing
{
    class CFigure
    {
        //Для определения можно ли рисвоать фигуру
        public static bool flagFigure;
        public Rectangle newRectangle;
        public Canvas newCanvas;
        double coordX1, coordY1, coordX2, coordY2;
        public static double x1, y1, x2, y2;
        bool mouseClik = false;

        public CFigure()
        {
            newRectangle = new Rectangle();
            newRectangle.Height = 70;
            newRectangle.Width = 70;
            newRectangle.StrokeThickness = 3;
            newRectangle.Fill = System.Windows.Media.Brushes.Cornsilk;
            newRectangle.Stroke = Brushes.DarkBlue;
            Canvas.SetLeft(newRectangle, 100);
            Canvas.SetTop(newRectangle, 100);
            newRectangle.MouseDown += RectMouseDown;
            newRectangle.MouseMove += RectMouseMove;
            newRectangle.MouseUp += RectMouseUp;
            x1 = Canvas.GetLeft(newRectangle);
            y1 = Canvas.GetTop(newRectangle);
            x2 = x1 + 70;
            y2 = Canvas.GetTop(newRectangle) + 70;
        }

        private void RectMouseDown(Object sender, MouseButtonEventArgs e)
        {
            if (flagFigure) //можно двигать
            {
                Rectangle tempFigure = sender as Rectangle;
                coordX1 = e.GetPosition(newCanvas).X;
                coordY1 = e.GetPosition(newCanvas).Y;
                mouseClik = true;
                tempFigure.CaptureMouse();
            }
        }

        private void RectMouseMove(Object sender, MouseEventArgs e)
        {
            if (mouseClik) //нажата клавиша мыши
            {
                Rectangle tempFigure = sender as Rectangle;
                coordX2 = e.GetPosition(newCanvas).X;
                coordY2 = e.GetPosition(newCanvas).Y;
                tempFigure.SetValue(Canvas.LeftProperty, coordX2);
                tempFigure.SetValue(Canvas.TopProperty, coordY2);
            }
        }
        private void RectMouseUp(Object sender, MouseButtonEventArgs e)
        {
            coordY1 = coordY2;
            coordX1 = coordX2;
            Rectangle tempFigure = sender as Rectangle;
            mouseClik = false; //сбрасываем
            tempFigure.ReleaseMouseCapture();
            x1 = Canvas.GetLeft(tempFigure);
            y1 = Canvas.GetTop(tempFigure);
            x2 = x1 + 70;
            y2 = Canvas.GetTop(tempFigure) + 70;
        } 
    }
}
