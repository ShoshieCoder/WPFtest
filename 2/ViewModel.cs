using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFtest._2
{
    public class ViewModel:INotifyPropertyChanged
    {
        private string txt;
        public string lbltxt { get { return this.txt; } set { this.txt = value; OnPropertyChanged("lbltxt"); } }

        private bool click = false;

        //public enum GridState { Valid, Invalid }

        //private GridState _gridBackground;
        //public GridState GridBackround { get { return this._gridBackground; } set { this._gridBackground = value; OnPropertyChanged("GridBackround"); } }

        private string _gridBackground;
        public string GridBackround { get { return this._gridBackground; } set { this._gridBackground = value; OnPropertyChanged("GridBackround"); } }

        public DelegateCommand RightCommand { get; set; }
        public DelegateCommand WrongCommand { get; set; }
       
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            Count();
            RightCommand = new DelegateCommand(() => { GridBackround = "green"; click = true; RightCommand.RaiseCanExecuteChanged();
                WrongCommand.RaiseCanExecuteChanged();
            }, () => { return !click; });
            WrongCommand = new DelegateCommand(() => { GridBackround = ""; click = true; WrongCommand.RaiseCanExecuteChanged();
                RightCommand.RaiseCanExecuteChanged();
            }, () => { return !click; });
        }

        public async void Count()
        {
            for (long i = 5; i > 0; i--)
            {
                lbltxt = i.ToString();
                if (click == true)
                    break;
                if(i == 1)
                    GridBackround = "";
                await Task.Run(() => { Thread.Sleep(1000); });
            }
            click = true;
            RightCommand.RaiseCanExecuteChanged();
            WrongCommand.RaiseCanExecuteChanged();
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
