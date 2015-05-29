using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Xps;
using System.IO;
using System.Windows.Media;
using System.Windows.Documents;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Printing;

using System.Drawing;



namespace FanShop.ViewModel
{
    class PlaćanjeViewModel
    {
        private WFanShopViewModel katalogViewModel;
        private Plaćanje view;
        private bool karticaCb;
        private string racunTekst;
        private Transakcija transakcija;
        private Kartica kartica;
        private bool naruceno = false;

        public PlaćanjeViewModel(WFanShopViewModel vm, Plaćanje view) 
        {
            katalogViewModel = vm;
            this.view = view;
            kartica = new Kartica();

            SetujTransakciju();
            RacunTekst = Transakcija.DajRacun();

            Naruci = new RelayCommand(naruci);
            Print = new RelayCommand(print);
           
        }

        public bool KarticaCb
        {
            get { return karticaCb; }
            set { karticaCb = value; }
        }

        public string RacunTekst
        {
            get { return racunTekst; }
            set { racunTekst = value; }
        }

        public Transakcija Transakcija
        {
            get { return transakcija; }
            set { transakcija = value; }
        }

        public Kartica Kartica
        {
            get { return kartica; }
            set { kartica = value; OnPropertyChanged("Kartica");  }
        }

        public ICommand Naruci { get; set; }
        public ICommand Print { get; set; }

        private void naruci(object parametar)
        {
            if (naruceno) 
            {
                System.Windows.Forms.MessageBox.Show("Već ste jednom kupili ove proizvode. Ako želite još jednom da ponovite transakciju, pritisnite opet \"Naruči\"", "Upozorenje!");
                naruceno = false;
                return;
            }

            if (KarticaCb == true && this.Kartica.IsValid == false)
            {
                System.Windows.Forms.MessageBox.Show("Podaci o kartici koje ste unijeli nisu uredu! Provjerite ih opet.", "Greška!");
                return;
            }

            Baza.BazaPodataka bp = new Baza.BazaPodataka();

            foreach (Stavka s in Transakcija.Korpa.Stavke)
            {
                bp.UnesiUArhivu(s.Proizvod.Id.ToString(), s.Kolicina.ToString(), "DATE(CURDATE())");
            }

            System.Windows.Forms.MessageBox.Show("Uspješno kupljeno! Zahvaljujemo se!", "Čestitamo");
            naruceno = true;
        }



      PrintDocument pdoc = null;
       
     private void print (object parametar)
     {
         PrintDialog pd = new PrintDialog();
         pdoc = new PrintDocument();
         PrinterSettings ps = new PrinterSettings();
         Font font = new Font("Courier New", 15);


         PaperSize psize = new PaperSize("Custom", 100, 200);
    
         pd.Document= pdoc;
         pd.Document.DefaultPageSettings.PaperSize = psize;
         pdoc.DefaultPageSettings.PaperSize.Height = 820;

         pdoc.DefaultPageSettings.PaperSize.Width = 520;

         pdoc.PrintPage += new PrintPageEventHandler(Stranica);

         DialogResult result = pd.ShowDialog();
         if (result == DialogResult.OK)
         {
             PrintPreviewDialog pp = new PrintPreviewDialog();
             pp.Document = pdoc;
             result = pp.ShowDialog();
             if (result == DialogResult.OK)
             {
                 pdoc.Print();
             }
         }
    }

        void Stranica(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int X = 50;
            int Y = 55;
            int Offset = 40;
              
            graphics.DrawString(RacunTekst, new Font("Courier New", 10), 
                     new SolidBrush(System.Drawing.Color.Black), X, Y + Offset);
 
                Offset = Offset + 20;
          
       }
    
   

        private void SetujTransakciju()
        {
            transakcija = new Transakcija();
            transakcija.Korpa = katalogViewModel.Korpa;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
