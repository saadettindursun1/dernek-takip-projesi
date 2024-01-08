using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class BLadmin
    {

        //admin güncelleme methodu
        public static int adminGuncelleme(Entadmin p)
        {
            return DALadmin.adminGuncelle(p);
        }


        //admin giriş methodu
        public static int adminGirisi(string kullaniciAdi,string parola)
        {
            return DALadmin.adminGiris(kullaniciAdi,parola);
        }


        //admin bilgilerini listeleme methodu
        public static List<Entadmin> adminListe()
        {
            return DALadmin.adminListesi();
        }


    }
}
