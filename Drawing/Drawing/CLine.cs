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
    /// <summary>
    /// Класс для рисования и рабты с линиями
    /// </summary>
    class CLine
    {
        public Line newLine;
        public bool mouseClik = false;

        //для получения координат
        Point coord;
        public Canvas newCanvas;


        public Rectangle figure1, figure2;

        public static double x1, x2, y1, y2;
         
        public CLine()
        {
            newLine = new Line();
            newLine.StrokeThickness = 3;
            newLine.Stroke = Brushes.DarkSlateBlue;
            newLine.StrokeLineJoin = PenLineJoin.Miter;
        }

        public void lineMouseDown(Object sender, MouseButtonEventArgs e)
        {
            coord = e.GetPosition(newCanvas);
            newLine.X1 = newLine.X2 = coord.X;
            newLine.Y1 = newLine.Y2 = coord.Y;
            x1 = newLine.X1;
            y1 = newLine.Y1;
            mouseClik = true; //получили координаты начала
        }

        public void lineMouseMove(Object sender, MouseEventArgs e)
        {
            if (mouseClik) //ведем по конвасу
            {
                Point pointEnd = e.GetPosition(newCanvas);
                newLine.X2 = pointEnd.X;
                newLine.Y2 = pointEnd.Y;
                x2 = newLine.X2;
                y2 = newLine.Y2;
            }
        }

        //Прицепление линии к фигурам
        public void lineConnectFigureOne(Object sender, MouseEventArgs e)
        {
            newLine.X1 = Canvas.GetLeft(figure1);
            newLine.Y1 = Canvas.GetTop(figure1);
        }

        public void lineConnectFigureTwo(Object sender, MouseEventArgs e)
        {
            newLine.X2 = Canvas.GetLeft(figure2);
            newLine.Y2 = Canvas.GetTop(figure2);
        }
    }
}
