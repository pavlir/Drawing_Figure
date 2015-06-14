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
    /// Кдлас для рисования и работы с фигурой (пунктир)
    /// </summary>
    class CFigureDotted : CFigure
    {
        public CFigureDotted() : base()
        {
            newRectangle.StrokeDashArray = new DoubleCollection { 3 };
        }

    }
}
