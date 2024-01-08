using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Entaidat
    {

        public int aidatId;
        public string tcNo { get; set; }

        public string UyeAdSoyad { get; set; }
        public string uyeMail { get; set; }

        public int aidatUcret { get; set; }
        public DateTime aidatTarih { get; set; }
        public bool aidatDurum { get; set; }

    }
}
