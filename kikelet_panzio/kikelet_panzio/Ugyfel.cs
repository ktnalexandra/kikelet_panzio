using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kikelet_panzio
{
    internal class Ugyfel
    {
        string ugyfelAz;
        string nev;
        DateTime szulDatum;
        string email;
        bool vip;

        public Ugyfel(string ugyfelAz, string nev, DateTime szulDatum, string email, bool vip)
        {
            this.ugyfelAz = ugyfelAz;
            this.nev = nev;
            this.szulDatum = szulDatum;
            this.email = email;
            this.vip = vip;
        }

        public Ugyfel() { }

        public string UgyfelAz { get => ugyfelAz; set => ugyfelAz = value; }
        public string Nev { get => nev; set => nev = value; }
        public DateTime SzulDatum { get => szulDatum; set => szulDatum = value; }
        public string Email { get => email; set => email = value; }
        public bool VIP { get => vip; set => vip = value; }
    }
}
