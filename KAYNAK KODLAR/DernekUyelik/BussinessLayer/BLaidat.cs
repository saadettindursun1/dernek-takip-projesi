using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace BussinessLayer
{
    public class BLaidat
    {


        //aidat listeleme methodu
        public static List<Entaidat> aidatListesi(string veri)
        {
            return DALaidat.aidatListele(veri);
        }


        //aidat guncelleme methodu
        public static int aidatGuncelleme(bool durum, int id)
        {
            return DALaidat.aidatGuncelle(durum,id);
        }


        //aidat silme methodu
        public static int aidatSilme(int id)
        {
            return DALaidat.aidatSil(id);
        }


        //tarihe ve duruma göre aidat listeleme methodu
        public static List<Entaidat> aidatListeTarihveDurum(DateTime t1, DateTime t2, bool durum)
        {
            return DALaidat.aidatListeleTarihveDurum(t1,t2,durum);
        }


        //duruma göre aidat listeleme methodu
        public static List<Entaidat> aidatListeDurum()
        {
            return DALaidat.aidatListeleDurum();
        }

        //ay bazında aidat listeleme methodu
        public static int ayBazindaGelir(int gelenAy)
        {
            DateTime baslangic = new DateTime(DateTime.Now.Year, gelenAy, 1);  //  gelen ayın ilk günü
            DateTime bitis = baslangic.AddMonths(1).AddDays(-1);  // gelen ayın son günü


            return DALaidat.ayBazindaGelirAnalizi(baslangic,bitis);
        }


        //yıl bazında aidat listeleme methodu
        public static int[] yilBazindaGelir(DateTime x, DateTime y)
        {

            int donguSayi = y.Year - x.Year; // başlangıç ve bitiş yılları arasında kaç yıl olduğunu alıyoruz
            int[] sonuclar = new int[donguSayi+1]; // gelecek sonuçları tutacak bir dizi oluşturuyoruz

            int say = 0;
            for (int i = x.Year; i<=y.Year; i++) // aradaki yıl sayısa kadar döngüye sokuyoruz
            {                  
                sonuclar[say] = DALaidat.yilBazindaGelirAnalizi(i); // aradaki yıllara ait aidat gelirlerini alıyoruz
                say++;
                
            }

            return sonuclar;

        }

    }
}
