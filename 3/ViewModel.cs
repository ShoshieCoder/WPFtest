using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WPFtest._3
{
    public class ViewModel:INotifyPropertyChanged
    {
        public string MyLink { get; set; }
        private string _linkSize;
        public string LinkSize { get { return this._linkSize; } set { this._linkSize = value; OnPropertyChanged("LinkSize"); } }
        public DelegateCommand StartCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            LinkSize = "Please Wait...";
            StartCommand = new DelegateCommand(() =>
            {
                //START();
                STARTdispatch();
            }, () => { return true; });
        }

        public async void START()
        {
            WebRequest webRequest = WebRequest.Create(MyLink);
            WebResponse response = await webRequest.GetResponseAsync();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string text = await reader.ReadToEndAsync();
                // text.Length == is the length of the result
                LinkSize = text.Length.ToString();
            }

        }

        public void STARTdispatch()
        {
            Task.Run(() =>
            {
                WebRequest webRequest = WebRequest.Create(MyLink);
                WebResponse response = webRequest.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string text = reader.ReadToEnd();
                    // text.Length == is the length of the result
                    Dispatcher.CurrentDispatcher.Invoke(() =>
                    {
                        LinkSize = text.Length.ToString();

                    }, DispatcherPriority.Normal);
                }
            });
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
