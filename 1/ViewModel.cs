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
        
        public Double Width { get; set; }
        public Double Height { get; set; }
        public string BtnText { get; set; }
        public DelegateCommand MyCommand { get; set; }

        public ViewModel()
        {
            MyCommand = new DelegateCommand(()=> {
                ButtonValuesWindow Win = new ButtonValuesWindow(Width, Height, BtnText);
                Win.Show();
            }, ()=>{ return true; });
        }
    }
}
