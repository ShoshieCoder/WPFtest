using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFtest._1
{
    /// <summary>
    /// Interaction logic for ButtonValuesWindow.xaml
    /// </summary>
    public partial class ButtonValuesWindow : Window
    {
        public ButtonValuesWindow(Double Width, Double Height, string BtnTxt)
        {
            InitializeComponent();
            width.Text = Width.ToString();
            height.Text = Height.ToString();
            text.Text = BtnTxt;
        }
    }
}
