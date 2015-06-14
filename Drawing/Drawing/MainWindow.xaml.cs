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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool flagLine = false;
        bool typeLine;
        public double xPos, yPos;
        int numbFigure = 0;
        List<CLine> LLine = new List<CLine>();
        List<CFigure> LFigure = new List<CFigure>();

        //Рисовашки
        private void DrawFigureLine(object sender, MouseButtonEventArgs e)
        {
            CFigure tempFigure = new CFigure();
            tempFigure.newCanvas = Canvas;
            Canvas.Children.Add(tempFigure.newRectangle);
            numbFigure = numbFigure + 1;
            LFigure.Add(tempFigure);
        }

        //Рисовашки
        private void DrawFigureDotted(object sender, MouseButtonEventArgs e)
        {
            CFigureDotted tempFigureDotted = new CFigureDotted();
            tempFigureDotted.newCanvas = Canvas;
            Canvas.Children.Add(tempFigureDotted.newRectangle);
            numbFigure = numbFigure + 1;
            LFigure.Add(tempFigureDotted);
        }

        //Выбор типа линии
        private void ClickLine(object sender, RoutedEventArgs e)
        {
            typeLine = true;
            flagLine = true;
            CFigure.flagFigure = false;
        }

        //Выбор типа линии
        private void ClickLineDotted(object sender, RoutedEventArgs e)
        {
            typeLine = false;
            flagLine = true;
            CFigure.flagFigure = false;
        }

        //Рисовашки линии
        private void DrawingLine(object sender, MouseButtonEventArgs e)
        {
            TextBox1.Clear();
            CLine tempLine;
            if (flagLine)
            {
                if (typeLine) { tempLine = new CLine();}
                else { tempLine = new CLineDotted();}

                //индекс фигуры от которой цепляем
                tempLine.newCanvas = Canvas;
                tempLine.lineMouseDown(sender, e);
                tempLine.figure1 = IntersectionFigureAndLine(e.GetPosition(Canvas).X, e.GetPosition(Canvas).Y);
                Canvas.MouseMove += tempLine.lineMouseMove;
                if (IntersectionFigureAndLine(e.GetPosition(Canvas).X, e.GetPosition(Canvas).Y) != null)
                {
                    Canvas.MouseMove += tempLine.lineConnectFigureOne;
                }
                LLine.Add(tempLine);
                Canvas.Children.Add(tempLine.newLine);
            }
        }

        //Пересечение линии и фигуры
        public Rectangle IntersectionFigureAndLine(double x, double y)
        {
            bool flagFigure = false;
            Rectangle index = new Rectangle();
            for (int i = 0; i < numbFigure; i++)
            {
                xPos = Canvas.GetLeft((Rectangle)Canvas.Children[i]);
                yPos = Canvas.GetTop((Rectangle)Canvas.Children[i]);

                if (x >= xPos && x <= xPos + 70 && y >= yPos && y <= yPos + 70)
                {
                    index = (Rectangle)Canvas.Children[i];
                    flagFigure = true;
                }
            }
            if (flagFigure) { return index;}
            else { return null;}
        }

        private void MotionObj(object sender, MouseButtonEventArgs e)
        {
            TextBox2.Clear();
            TextBox3.Clear();
            CFigure.flagFigure = true;
        }

        private void GetValCoord(object sender, RoutedEventArgs e)
        {
            //Координаты линии
            TextBox1.Text = string.Format("{0} {1} {2} {3}", CLine.x1, CLine.y1, CLine.x2, CLine.y2);

            //Координаты квадрата
            TextBox2.Text = string.Format("{0} {1} {2} {3}", CFigure.x1, CFigure.y1, CFigure.x2, CFigure.y2);

            //Координаты пунктирного квадрата
            TextBox3.Text = string.Format("{0} {1} {2} {3}", CFigureDotted.x1, CFigureDotted.y1, CFigureDotted.x2, CFigureDotted.y2);
        }


        private void DrawingUp(object sender, MouseButtonEventArgs e)
        {
            if (LLine.Count > 0)
            {
                //индекс фигуры к которой цепляем
                LLine[LLine.Count - 1].figure2 = IntersectionFigureAndLine(e.GetPosition(Canvas).X, e.GetPosition(Canvas).Y);
                if (IntersectionFigureAndLine(e.GetPosition(Canvas).X, e.GetPosition(Canvas).Y) != null)
                {
                    Canvas.MouseMove += LLine[LLine.Count - 1].lineConnectFigureTwo;
                }
                LLine[LLine.Count - 1].mouseClik = false;
            }
            flagLine = false;
            Line.IsChecked = false;
            LineDotted.IsChecked = false;
        }
    }
}
