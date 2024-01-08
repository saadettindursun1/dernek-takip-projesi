using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
using System.Data;

namespace BussinessLayer
{
    public class BLuyeler
    {

        //üye ekleme methodu
        public static string BLuyeekle(Entuyeler p) //eklenecek olan üye bilgisi için Entuyeler türünden bir nesne alıyoruz
        {


            //başlangıçta hata ve mesaj değişkenleri oluşturuyoruz. Bu değişkenler işlemin sonuçlarına göre güncellenecek.
            int hata = 0; // her hata durumunda bir sayı arttırıyoruz
            string mesaj = "";

            if (p.TcNo.Length != 11) // eğer tc 11 haneli değise
            {
                hata++;
                mesaj += "T.C. No en az 11 haneli olmalıdır! \n";
            }

            if(p.UyeAdSoyad=="" || p.UyeSehir == "" || p.UyeKanGrubu == "0" || p.UyeEposta == "") // adsoyad,şehir,kan grubu
                                                                                                  // veya e posta boş ise
            {
                hata++;
                mesaj += "Boş Alan Bıraktınız !! \n";
            }
            if(hata == 0) // eğer sıfırsa yani hiç hata yoksa
            {
               int sonuc =  DALuyeler.UyeEkle(p); // üye ekleme methodu çağırılıyor ve methoddan dönen
                                                  // değer sonuç değişkenine aktarılıyor eğer ekleme başarılı olursa sonuç 1 dönüyor
                                                                                                  

               
              

                if (sonuc != 1) // eğer sonuç bir değilse ekleme başarısız olmuştur
                {
                    mesaj = "Bu T.C. No ile kayıt yapılmış..";
                }
                else
                {
                    mesaj = "Kayıt Başarılı";

                    int bulundugumuzAy = DateTime.Now.Month; // bulunduğumuz ayın sayısal değerini alıyoruz
                    int eklenecekAy = 12 - bulundugumuzAy;  // bulunduğumuz aydan yıl sonuna kaç yıl var ise buluyoruz

                    int[] aylikAidat = new int[12]; // aylara denk gelen ilgili aidat ücreti oluşturduğumuz bu diziye aktarılacak
                    List<EntaidatAylar> aidatAylarListesi = DALaidatBilgi.aidatListesi(); // veritabanından aidat listesi alınıyor
                    foreach (EntaidatAylar item in aidatAylarListesi) // alınan liste işlenmek üzere döngüye giriyor
                    {
                        //oluşturduğumuz diziye veritabandan gelend değerler aktarılıyor 
                        // bu değerler üyeye aidat eklerken kullanılacak
                        aylikAidat[0] = item.ocak;
                        aylikAidat[1] = item.subat;
                        aylikAidat[2] = item.mart;
                        aylikAidat[3] = item.nisan;
                        aylikAidat[4] = item.mayis;
                        aylikAidat[5] = item.haziran;
                        aylikAidat[6] = item.temmuz;
                        aylikAidat[7] = item.agustos;
                        aylikAidat[8] = item.eylul;
                        aylikAidat[9] = item.ekim;
                        aylikAidat[10] = item.kasim;
                        aylikAidat[11] = item.aralik;

                    }


                    for (int i = 1; i <= eklenecekAy; i++) // yıl sonuna kaç ay varsa o kadar çalışacak döngü organize ediyoruz
                    {
                        DateTime yeniKayitTarihi = new DateTime(DateTime.Now.Year, (bulundugumuzAy + i), 15); // aidat ödenecek ay                                                                                                              

                        Entaidat x = new Entaidat();
                        x.aidatTarih = yeniKayitTarihi;
                        x.uyeMail = p.UyeEposta;
                        x.aidatDurum = false;
                        x.tcNo = p.TcNo;
                        x.UyeAdSoyad = p.UyeAdSoyad;
                        x.aidatUcret = aylikAidat[i - 1]; // eksi bir dememizin sebebi i değişkeninin başlangıç değerinin 1 olmasıdır
                                                          // i değerindeki aya karşılık gelen aidat ücretlerinin bulunduğu
                                                          // dizi indexi 0 dan başlıyor
                        DALaidat.AidatGirisi(x); // aidat ekleniyor
                    }
                }
            }

            return mesaj;
         
        }

        //üye listeleme methodu
        public static List<Entuyeler> UyeListesiBL()
        {
            return DALuyeler.UyeListesi();
        }


        //şehire göre üye listeleme methodu
        public static int UyeListeSehir(string sehir)
        {
            return DALuyeler.UyeListesiSehir(sehir);
        }

        //üye silme methodu
        public static string UyeSilBL (string p)
        {
            return DALuyeler.UyeSil(p);
        }

        //üye güncelleme methodu
        public static int UyeGnclleBL (Entuyeler p)
        {
            return DALuyeler.UyeGnclle(p);
        }

        //filtrelemeye göre üye listeleme methodu
        public static List<Entuyeler> UyeListesiFiltreBL(string filtre,string filtreIcerik)
        {
            string convertFiltre = ""; // gelen filtre türü veritabanında hali dönüştürelerek bu değişkene atanacak

            if(filtre=="Kan Grubuna Göre")
            {
                convertFiltre = "UyeKanGrubu";
            }
            if (filtre == "Şehire Göre")
            {
                convertFiltre = "UyeSehir";
            }
            if (filtre == "Üye Durumuna Göre")

            {
                convertFiltre = "UyelikDurumu";
            }
            if(filtre == "Tüm Üyeler")
            {
                return DALuyeler.UyeListesi();

            }

            //sorgulamaya hazır olan filtre türü ve içeriği gerekli methoda gönderiliyor
            return DALuyeler.UyeListesiFiltreli(convertFiltre,filtreIcerik);
        }


    }
}
