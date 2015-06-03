using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Xps.Packaging;
using System.ComponentModel;
using System.Windows.Input;
using System.IO;


namespace FanShop.ViewModel 
{
    class HelpViewModel : INotifyPropertyChanged
    {
       
        private XpsDocument xps;
        private string s;


        public HelpViewModel(Object view, string path)
        {
            xps = new XpsDocument(path, FileAccess.Read);
            (view as View.HelpUser).doc.Document = xps.GetFixedDocumentSequence();
            help = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\help.png";
       
        }
        public XpsDocument XPS
        {
            get { return xps; }
            set
            {
                xps = value;
                OnPropertyChanged("XPS");
            }
        }

        public string help
        {
            get { return AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\help.png"; }
            set
            {
                s = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\help.png";
                OnPropertyChanged("ImageUrl");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public Action CloseAction { get; set; }

    }
}
