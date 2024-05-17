using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kikelet_panzio
{
    internal class Szoba
    {
        public int szobaSzam;
        public int feroHelyekSzama;
        public int arPerFo;

        public Szoba(int szobaSzam, int feroHelyekSzama, int arPerFo)
        {
            this.szobaSzam = szobaSzam;
            this.feroHelyekSzama = feroHelyekSzama;
            this.arPerFo = arPerFo;
        }

        public Szoba() { }

        public int SzobaSzam { get => szobaSzam; set => szobaSzam = value; }
        public int FeroHelyekSzama { get => feroHelyekSzama; set => feroHelyekSzama = value; }
        public int ArPerFo { get => arPerFo; set => arPerFo = value; }
    }
}
