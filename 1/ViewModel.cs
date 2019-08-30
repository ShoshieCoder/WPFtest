using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFtest._1
{
    public class ViewModel
    {
        public DelegateCommand MyDelegate { get; set; }

        public Double Width { get; set; }
        public Double Height { get; set; }
        public string BtnText { get; set; }

        public ViewModel()
        {
            MyDelegate = new DelegateCommand(()=> {
                ButtonValuesWindow BtnValsWin = new ButtonValuesWindow(Width, Height, BtnText);
                BtnValsWin.Show();
            }, ()=>{ return true; });
        }
    }
}
