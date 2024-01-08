using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Entadmin
    {
        public string kullaniciAdi { get; set; }

        public string parola { get; set; }
        public string smtpSunucu { get; set; }

        public string smtpKullaniciAdi { get; set; }
        public int smtpPort { get; set; }
        public string smtpParola { get; set; }
        public string gondericiEposta { get; set; }
    }
}
