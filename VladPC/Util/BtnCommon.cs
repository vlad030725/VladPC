using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VladPC.Util
{
    public class BtnCommon : Button
    {
        static BtnCommon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BtnCommon), new FrameworkPropertyMetadata(typeof(BtnCommon)));
        }
    }
}
