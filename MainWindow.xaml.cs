using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavigationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<Page> SeitenListe { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string pPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pPropertyName));
        }

        private byte _aktuelleSeite;
        public byte AktuelleSeite
        {
            get { return _aktuelleSeite; }
            set
            {
                _aktuelleSeite = value;
                if (_aktuelleSeite == 0)
                {
                    btnZurueck.IsEnabled = false;
                }
                else
                {
                    btnZurueck.IsEnabled = true;
                }

                if (_aktuelleSeite == SeitenListe.Count -1)
                {
                    btnVor.IsEnabled = false;
                }
                else
                {
                    btnVor.IsEnabled = true;
                }
                OnPropertyChanged("AktuelleSeite");

                frmContent.NavigationService.Navigate(SeitenListe[_aktuelleSeite]);
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SeitenListe = new List<Page>();
            SeitenListe.Add(new X()); // nummer 0
            SeitenListe.Add(new Y()); // nummer 1
            SeitenListe.Add(new Z()); // nummer 2
            SeitenListe.Add(new Z()); // nummer 2
            SeitenListe.Add(new Z()); // nummer 2
            SeitenListe.Add(new Z()); // nummer 2
            SeitenListe.Add(new Z()); // nummer 2
            SeitenListe.Add(new Z()); // nummer 2
            SeitenListe.Add(new Z()); // nummer 2
            SeitenListe.Add(new Z()); // nummer 2
            SeitenListe.Add(new Z()); // nummer 2
            lbNavigation.ItemsSource = SeitenListe;
            cbNavigation.ItemsSource = SeitenListe;
            sldNavigation.Maximum = SeitenListe.Count - 1;
            AktuelleSeite = 0;
        }

        private void btnVorClick(object sender, RoutedEventArgs e)
        {
            AktuelleSeite++;
        }

        private void btnZurueckClick(object sender, RoutedEventArgs e)
        {
            AktuelleSeite--;
        }
    }
}
