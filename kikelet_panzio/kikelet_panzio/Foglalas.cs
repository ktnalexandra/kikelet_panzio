using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kikelet_panzio
{
    internal class Foglalas
    {
        Szoba panzio;
        Ugyfel vendeg;
        DateTime erkezesDatuma;
        DateTime tavozasDatuma;
        int letszam;
        double osszAr;
        string allapot;

        public Foglalas(Szoba panzio, Ugyfel vendeg, DateTime erkezesDatuma, DateTime tavozasDatuma, int letszam, double osszAr, string allapot)
        {
            this.panzio = panzio;
            this.vendeg = vendeg;
            this.erkezesDatuma = erkezesDatuma;
            this.tavozasDatuma = tavozasDatuma;
            this.letszam = letszam;
            this.osszAr = osszAr;
            this.allapot = allapot;
        }

        public Foglalas() { }

        public DateTime ErkezesDatuma { get => erkezesDatuma; set => erkezesDatuma = value; }
        public DateTime TavozasDatuma { get => tavozasDatuma; set => tavozasDatuma = value; }
        public int Letszam { get => letszam; set => letszam = value; }
        public double OsszAr { get => osszAr; set => osszAr = value; }
        public string Allapot { get => allapot; set => allapot = value; }
        internal Szoba Panzio { get => panzio; set => panzio = value; }
        internal Ugyfel Vendeg { get => vendeg; set => vendeg = value; }
    }
}
