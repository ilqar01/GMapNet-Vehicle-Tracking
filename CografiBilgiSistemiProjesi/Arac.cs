using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CografiBilgiSistemiProjesi
{
     internal class Arac
      {
        private string plaka { get; set; }
        private string tipi { get; set; }
        private string from { get; set; }
        private string to { get; set; }
        private PointLatLng konum { get; set; }



        public Arac(string plaka , string tipi , string from , string to , PointLatLng konum)
        {
            this.plaka = plaka;
            this.tipi = tipi;
            this.from = from;
            this.to = to;
            this.konum = konum;
        }
        public string Plaka
        {
            get
            {
                return plaka;
            }
            set
            {
                plaka = value;
            }
        }
        public string Tipi
        {
            get
            {
                return tipi;
            }
            set
            {
                tipi = value;
            }
        }

        public string From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }

        public string To
        {
            get
            {
                return to;
            }
            set
            {
                to= value;
            }
        }
        public PointLatLng Konum
        {
            get
            {
                return konum;
            }
            set
            {
                konum = value;
            }
        }



        public override string ToString()
        {
            string str = "\n" + plaka + "\n" + tipi + "\n" + from + "\n" + to;
            return str;
        }
    }
}
