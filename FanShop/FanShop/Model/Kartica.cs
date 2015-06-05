using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using FanShop.Helper;

namespace FanShop
{
    public class Kartica: INotifyPropertyChanged, IDataErrorInfo
    {
        private string brojKreditneKartice;

        public string BrojKreditneKartice
        {
            get { return brojKreditneKartice; }
            set { brojKreditneKartice = value; OnPropertyChanged("BrojKreditneKartice"); }
        }
        private DateTime datumIsteka;

        public DateTime DatumIsteka
        {
            get { return datumIsteka; }
            set { datumIsteka = value; OnPropertyChanged("DatumIsteka"); }
        }
        private string ccv;

        public string  Ccv
        {
            get { return ccv; }
            set { ccv = value; OnPropertyChanged("Ccv"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public bool IsValid
        {
            get
            {
                foreach (string property in validateProperties)
                {
                    if (getValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        static readonly string[] validateProperties =
        {
            "BrojKreditneKartice","DatumIsteka","Ccv"
        };
        string IDataErrorInfo.Error
        {
            get { return null; }
        }
        string IDataErrorInfo.this[string propertyName]
        {
            get { return getValidationError(propertyName); }
        }
        string getValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "BrojKreditneKartice":
                    error = validirajBroj();
                    break;
                case "DatumIsteka":
                    error = validirajDatum();
                    break;
                case "Ccv":
                    error = validirajCcv();
                    break;
            }
            return error;
        }

        private string validirajBroj()
        {
            if (String.IsNullOrWhiteSpace(BrojKreditneKartice))
            {
                return "Broj kreditne kartice mora biti unesen!";
            }
            if (!BrojKreditneKartice.LuhnCheck() || BrojKreditneKartice.Length > 19 || BrojKreditneKartice.Length < 11)
            {
                return "Broj kreditne kartice ne postoji!";
            }
            return null;
        }
        private string validirajCcv()
        {
            int p = 0;
            if (Int32.TryParse(ccv, out p) == false)
                return "Ccv mora biti broj";
           if (int.Parse(ccv) < 1000 || int.Parse( ccv )> 9999) return "CCV mora biti cetverocifren broj!";
            return null;
        }

        private string validirajDatum()
        {
            if (datumIsteka <= DateTime.Now)
            {
                return "Unesite datum u buducnosti!";
            }
            return null;
        }

    }
}
