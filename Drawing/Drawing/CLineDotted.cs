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
    class CLineDotted : CLine
    {
        public CLineDotted() : base()
        {
            newLine.StrokeDashArray = new DoubleCollection { 3 };
        }
    }
}
