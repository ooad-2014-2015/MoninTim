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
        private string file;

        private XpsDocument xps;


        public HelpViewModel(Object view, string path)
        {
            xps = new XpsDocument(path, FileAccess.Read);
            (view as View.HelpUser).doc.Document = xps.GetFixedDocumentSequence();            
       
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
