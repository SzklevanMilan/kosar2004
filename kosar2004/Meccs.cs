using System.Collections.Generic;

namespace kosar2004
{
    internal class Meccs
    {
        public string Hazai { get; private set; }
        public string Idegen { get; private set; }
        public int HPont { get; private set; }
        public int IPont { get; private set; }
        public string Hely { get; private set; }
        public string Ido { get; private set; }
        public Meccs(/*string hazai,string idegen,int hpont,int ipont,string hely,string ido*/string sor)
        {
            string[] adat = sor.Split(';');
            Hazai = adat[0];
            Idegen = adat[1];
            HPont = int.Parse(adat[2]);
            IPont = int.Parse(adat[3]);
            Hely = adat[4];
            Ido = adat[5];
            //this.Hazai = hazai;
            //this.Idegen = idegen;
            //this.HPont = hpont;
            //this.IPont = ipont;
            //this.Hely = hely;
            //this.Ido = ido;

        }
    }
}