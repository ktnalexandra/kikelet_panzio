using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kikelet_panzio
{
    internal class Adat
    {
        public List<Szoba>szobak = new List<Szoba>();
        public List<Ugyfel>ugyfelek = new List<Ugyfel>();
        public List<Foglalas>foglalasok = new List<Foglalas>();

        private void SzobaAdatok()
        {
            szobak.Add(new Szoba() { SzobaSzam = 1, FeroHelyekSzama = 2, ArPerFo = 8000 });
            szobak.Add(new Szoba() { SzobaSzam = 2, FeroHelyekSzama = 3, ArPerFo = 7000 });
            szobak.Add(new Szoba() { SzobaSzam = 3, FeroHelyekSzama = 4, ArPerFo = 6000 });
            szobak.Add(new Szoba() { SzobaSzam = 4, FeroHelyekSzama = 2, ArPerFo = 10000});
            szobak.Add(new Szoba() { SzobaSzam = 5, FeroHelyekSzama = 3, ArPerFo = 9000 });
            szobak.Add(new Szoba() { SzobaSzam = 6, FeroHelyekSzama = 4, ArPerFo = 12000});
        }

        public void UjUgyfel(string nev, DateTime szulDatum, string email, bool vip)
        {
            var ugyfelAz = $"{nev}_{DateTime.Now:yyyyMMdd}";
            ugyfelek.Add(new Ugyfel
            {
                UgyfelAz = ugyfelAz,
                Nev = nev,
                SzulDatum = szulDatum,
                Email = email,
                VIP = vip
            });
        }

        public void UjFoglalas(Szoba panzio, Ugyfel vendeg, DateTime erkezes, DateTime tavozas, int letszam)
        {
            var osszesAr = (tavozas - erkezes).Days * panzio.ArPerFo * letszam;
            if (vendeg.VIP)
            {
                //osszesAr * 0.97 %;
            }

            foglalasok.Add(new Foglalas
            {
                Panzio = panzio,
                Vendeg = vendeg,
                ErkezesDatuma = erkezes,
                TavozasDatuma = tavozas,
                Letszam = letszam,
                OsszAr = osszesAr,
                Allapot = "Előjegyzett"
            });
        }

        public double OsszBevetel()
        {
            return foglalasok.Sum(r => r.OsszAr);
        }

        public Szoba LegtobbetKivettSzoba()
        {
            return foglalasok
                .GroupBy(r => r.Panzio)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
        }

        public List<Ugyfel> VisszajaroUgyfelek()
        {
            var visszajaroUgyfelek = foglalasok
                .GroupBy(r => r.Vendeg)
                .Where(g => g.Count() > 1)
                .Select(g => new { Ugyfel = g.Key, OsszesKoltseg = g.Sum(r => r.OsszAr) })
                .OrderByDescending(c => c.OsszesKoltseg)
                .Select(c => c.Ugyfel)
                .ToList();

            return visszajaroUgyfelek;
        }


    }
}
