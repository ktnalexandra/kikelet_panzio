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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kikelet_panzio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Adat adat;
        public MainWindow()
        {
            InitializeComponent();
            adat = new Adat();
            FrissitSzobak();
            FrissitUgyfelek();
            FrissitFoglalasok();
            FrissitStatisztikak();
        }

        private void FrissitSzobak()
        {
            lbx_Szobak.Items.Clear();
            foreach (var szoba in adat.szobak)
            {
                lbx_Szobak.Items.Add($"Szoba: {szoba.SzobaSzam}, Ferőhelyek: {szoba.FeroHelyekSzama}, Ár/fő: {szoba.ArPerFo} Ft");
            }
        }

        private void FrissitUgyfelek()
        {
            lbx_Ugyfelek.Items.Clear();
            foreach (var ugyfel in adat.ugyfelek)
            {
                lbx_Ugyfelek.Items.Add($"Ügyfél neve: {ugyfel.Nev}, Email: {ugyfel.Email}, VIP: {ugyfel.VIP}");
            }
        }

        private void FrissitFoglalasok()
        {
            lbx_Foglalasok.Items.Clear();
            foreach (var foglalas in adat.foglalasok)
            {
                lbx_Foglalasok.Items.Add($"{foglalas.Vendeg.Nev}, Szoba: {foglalas.Panzio.SzobaSzam}, Érkezés: {foglalas.ErkezesDatuma}, Távozás: {foglalas.TavozasDatuma}, Létszám: {foglalas.Letszam}, Állapot:{foglalas.Allapot}, Összes ár: {foglalas.OsszAr} Ft");
            }
        }

        private void FrissitStatisztikak()
        {
            txb_OsszBevetel.Text = adat.OsszBevetel().ToString() + "Ft";
            var LegtobbetKivettSzoba = adat.LegtobbetKivettSzoba();
            txb_LegtobbetKivett.Text = LegtobbetKivettSzoba != null ? LegtobbetKivettSzoba.SzobaSzam.ToString() : "Nincs adat";

            lbx_Ugyfelek.Items.Clear();
            foreach (var ugyfel in adat.VisszajaroUgyfelek())
            {
                lbx_Ugyfelek.Items.Add($"Ügyfél neve: {ugyfel.Nev}, Email: {ugyfel.Email}");
            }
        }

        private void btn_UgyfelFelvetele_Click(object sender, RoutedEventArgs e)
        {
            //párbeszéd ablak, az adatok felvételének
            adat.UjUgyfel("Minta ügyfél", new DateTime(1990, 1, 1), "minta@gmail.com", true);
            FrissitUgyfelek();
        }

        private void btn_FoglalasFelvete_Click(object sender, RoutedEventArgs e)
        {
            //párbeszéd ablak, a foglalás felvételének
            if (adat.szobak.Any() && adat.ugyfelek.Any())
            {
                var szoba = adat.szobak.First();
                var ugyfel = adat.ugyfelek.First();
                adat.UjFoglalas(szoba, ugyfel, DateTime.Now, DateTime.Now.AddDays(3), 2);
                FrissitFoglalasok();
            }
        }
    }
}
