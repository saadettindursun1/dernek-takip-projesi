using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;


namespace DataAccessLayer
{
    public class DALaidat
    {


        //aidat ekleme methodu
        public static int AidatGirisi(Entaidat p) //eklenecek olan aidat bilgisi için Entaidat türünden bir nesne alıyoruz
        {
            OleDbCommand cmd = new OleDbCommand("insert into aidatUye(tcNo,UyeAdSoyad,uyeMail,aidatUcret,aidatTarih,aidatDurum)" +
                " values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti.conn);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            // aldığımız nesne bilgilerini veritabanına gönderilecek veriler ile eşitliyoruz.
            cmd.Parameters.AddWithValue("@p1", p.tcNo);
            cmd.Parameters.AddWithValue("@p2", p.UyeAdSoyad);
            cmd.Parameters.AddWithValue("@p3", p.uyeMail);
            cmd.Parameters.AddWithValue("@p4", p.aidatUcret);
            cmd.Parameters.AddWithValue("@p5", p.aidatTarih);
            cmd.Parameters.AddWithValue("@p6", p.aidatDurum);
            return cmd.ExecuteNonQuery(); // sorguyu çalıştırıyoruz

        }
       

        


        //aidat güncelleme methodu
    public static int aidatGuncelle(bool durum, int id) //guncellenecek olan aidat bilgisi için id ve durum değişkenlerini alıyoruz
        {
        OleDbCommand cmd = new OleDbCommand("update aidatUye set aidatDurum=@p1 where aidatId=@p2", baglanti.conn);
        if (cmd.Connection.State != ConnectionState.Open)
        {
            cmd.Connection.Open();
        }

            // aldığımız  bilgileri veritabanına gönderilecek veriler ile eşitliyoruz.
            cmd.Parameters.AddWithValue("@p1", durum);
        cmd.Parameters.AddWithValue("@p2", id);
     
        return cmd.ExecuteNonQuery();  // sorguyu çalıştırıyoruz
        }



        //aidat silme methodu
     public static int aidatSil(int id) // silinecek olan aidat bilgisi için id alıyoruz
     {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM aidatUye WHERE aidatId=@p1 ", baglanti.conn);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            // aldığımız  id'yi veritabanına gönderilecek id ile eşitliyoruz.
            cmd.Parameters.AddWithValue("@p1", id); 

            return cmd.ExecuteNonQuery();  // sorguyu çalıştırıyoruz
        }


        //gelen veriye göre aidat listeleme methodu
        public static List<Entaidat> aidatListele(string gelenVeri) // listelenirken filtrelenmesini istenen bilgiyi alıyoruz
        {
            List<Entaidat> aidatListesi = new List<Entaidat>();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM aidatUye WHERE  tcNo LIKE @bilgi OR UyeAdSoyad LIKE @bilgi  ", baglanti.conn);



            // LIKE ifadesi için % işareti, parametre değeri içinde eklenmeli
            // aldığımız bilgiyi veritabanına gönderilecek bilgi ile eşitliyoruz.

            cmd.Parameters.AddWithValue("@bilgi", "%" + gelenVeri + "%");

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            OleDbDataReader dr = cmd.ExecuteReader();

            
            while (dr.Read()) // sorgudan gelen satırları okuyoruz
            {
                //okunan satırları liste türünde olan değişkenimize aktarıyoruz
                Entaidat aidat = new Entaidat();
                aidat.aidatId =int.Parse(dr["aidatId"].ToString());
                aidat.tcNo = dr["tcNo"].ToString();
                aidat.UyeAdSoyad = dr["UyeAdSoyad"].ToString();
                aidat.uyeMail = dr["uyeMail"].ToString();
                aidat.aidatTarih = Convert.ToDateTime(dr["aidatTarih"]);
                aidat.aidatUcret = Convert.ToInt16(dr["aidatUcret"]);
                aidat.aidatDurum = Convert.ToBoolean(dr["aidatDurum"]);
                aidatListesi.Add(aidat);
            }

            dr.Close();
            return aidatListesi; // oluşan listeyi geri döndürüyoruz
        }




        //ödenme durumuna göre aidat listeleme methodu
        public static List<Entaidat> aidatListeleDurum(bool durum)
        {
            List<Entaidat> aidatListesi = new List<Entaidat>();

            OleDbCommand cmd = new OleDbCommand("SELECT * FROM aidatUye WHERE aitdatDurum=@p1", baglanti.conn);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            // aldığımız durum bilgisini veritabanına gönderilecek bilgi ile eşitliyoruz.

            cmd.Parameters.AddWithValue("@p1", durum);


            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //okunan satırları liste türünde olan değişkenimize aktarıyoruz

                Entaidat aidat = new Entaidat();
                aidat.tcNo = dr["tcNo"].ToString();
                aidat.UyeAdSoyad = dr["UyeAdSoyad"].ToString();
                aidat.uyeMail = dr["uyeMail"].ToString();
                aidat.aidatTarih = Convert.ToDateTime(dr["aidatTarih"]);
                aidat.aidatUcret = Convert.ToInt16(dr["aidatUcret"]);

                aidatListesi.Add(aidat);
            }

            dr.Close();
            return aidatListesi; // oluşan listeyi geri döndürüyoruz
        }



        //iki tarih arasında ödenmiş veya ödenmemiş aidatları gösterme methodu
        public static List<Entaidat> aidatListeleTarihveDurum(DateTime baslangicTarih, DateTime bitisTarih, bool durum)
        {
            List<Entaidat> aidatListesi = new List<Entaidat>();

            OleDbCommand cmd = new OleDbCommand("SELECT * FROM aidatUye WHERE aidatDurum=@aidatDurum and (aidatTarih BETWEEN @tarih1 AND @tarih2)", baglanti.conn);

            // aldığımız bilgileri veritabanına gönderilecek bilgiler ile eşitliyoruz.

            cmd.Parameters.AddWithValue("@aidatDurum", durum);
            cmd.Parameters.AddWithValue("@tarih1", baslangicTarih.ToString("dd.MM.yyyy"));
            cmd.Parameters.AddWithValue("@tarih2", bitisTarih.ToString("dd.MM.yyyy"));

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
      
            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //okunan satırları liste türünde olan değişkenimize aktarıyoruz

                Entaidat aidat = new Entaidat();
                aidat.aidatId = int.Parse(dr["aidatId"].ToString());
                aidat.tcNo = dr["tcNo"].ToString();
                aidat.UyeAdSoyad = dr["UyeAdSoyad"].ToString();
                aidat.uyeMail = dr["uyeMail"].ToString();
                aidat.aidatTarih = Convert.ToDateTime(dr["aidatTarih"]);
                aidat.aidatUcret = Convert.ToInt16(dr["aidatUcret"]);
                aidat.aidatDurum = Convert.ToBoolean(dr["aidatDurum"]);

                aidatListesi.Add(aidat);
            }

            dr.Close();
            return aidatListesi; // oluşan listeyi geri döndürüyoruz
        } 


        //bugüne kadar borcunu ödemeyenleri gösteren method
        public static List<Entaidat> aidatListeleDurum()
        {
            List<Entaidat> aidatListesi = new List<Entaidat>();

            OleDbCommand cmd = new OleDbCommand("SELECT * FROM aidatUye WHERE (aidatDurum=@aidatDurum) AND (aidatTarih <= @bugun)", baglanti.conn);

            cmd.Parameters.AddWithValue("@aidatDurum", false); // false göndererek ödemeyenleri işaretlemiş oluypruz
            cmd.Parameters.AddWithValue("@bugun", DateTime.Now.Date.ToString("dd/MM/yyyy"));




            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }



            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //okunan satırları liste türünde olan değişkenimize aktarıyoruz

                Entaidat aidat = new Entaidat();
                aidat.aidatId = int.Parse(dr["aidatId"].ToString());
                aidat.tcNo = dr["tcNo"].ToString();
                aidat.UyeAdSoyad = dr["UyeAdSoyad"].ToString();
                aidat.uyeMail = dr["uyeMail"].ToString();
                aidat.aidatTarih = Convert.ToDateTime(dr["aidatTarih"]);
                aidat.aidatUcret = Convert.ToInt16(dr["aidatUcret"]);
                aidat.aidatDurum = Convert.ToBoolean(dr["aidatDurum"]);

                aidatListesi.Add(aidat);
            }

            dr.Close();
            return aidatListesi;
        }



        // ay bazında gelir analizi için veri döndüren method
        public static int ayBazindaGelirAnalizi(DateTime baslangicTarih, DateTime bitisTarih) // veritabanında sormak için başlangıç ve bitiş tarihi alıyoruz
        {
            int toplamAidat = 0; //method başlangıcında toplam değişkeni oluşturuyoruz

            using (OleDbCommand cmd = new OleDbCommand("SELECT SUM(aidatUcret) AS aidatUye FROM aidatUye WHERE aidatDurum = @aidatDurum AND" +
                " (aidatTarih BETWEEN @tarih1 AND @tarih2)", baglanti.conn))
            {
                //  bilgileri veritabanına gönderilecek bilgiler ile eşitliyoruz.

                cmd.Parameters.AddWithValue("@aidatDurum", true);
                cmd.Parameters.AddWithValue("@tarih1", baslangicTarih.ToString("dd.MM.yyyy"));
                cmd.Parameters.AddWithValue("@tarih2", bitisTarih.ToString("dd.MM.yyyy"));

                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }

                // Eğer sadece tek bir değeri döndürecekse ExecuteScalar kullanılabilir
                object result = cmd.ExecuteScalar();

                // Eğer result null değilse ve bir değer varsa, int'e çevir
                if (result != null && result != DBNull.Value)
                {
                    toplamAidat = Convert.ToInt32(result.ToString());
                }

            }

            return toplamAidat;
        }



        // yıl bazında gelir analizi için veri döndüren method
        public static int yilBazindaGelirAnalizi(int gelen) // veritabanına sorulacak yıl bilgisini alyıoruz örn:2020
        {
            DateTime baslangic = new DateTime(gelen, 1, 1); // başlangıç değeri olarak gelen yıl bilgisini de kullanarak yılın ilk gününü seçiyoruz.
                                                            // 1,1 ifadesi ocak 1 anlamına geliyor

            DateTime bitis = new DateTime(gelen, 12, 30);  // bitiş değeri olarak gelen yıl bilgisini de kullanarak yılın son gününü seçiyoruz.
                                                           // 12,30 ifadesi aralık 301 anlamına geliyor

            int toplamAidat = 0;

            using (OleDbCommand cmd = new OleDbCommand("SELECT SUM(aidatUcret) AS aidatUye FROM aidatUye WHERE aidatDurum = @aidatDurum AND " +
                "(aidatTarih BETWEEN @tarih1 AND @tarih2)", baglanti.conn))
            {

                //  bilgileri veritabanına gönderilecek bilgiler ile eşitliyoruz.

                cmd.Parameters.AddWithValue("@aidatDurum", true);
                cmd.Parameters.AddWithValue("@tarih1", baslangic.ToString("dd.MM.yyyy"));
                cmd.Parameters.AddWithValue("@tarih2", bitis.ToString("dd.MM.yyyy"));

                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }

                // Eğer sadece tek bir değeri döndürecekse ExecuteScalar kullanılabilir
                object result = cmd.ExecuteScalar();

                // Eğer result null değilse ve bir değer varsa, int'e çevir
                if (result != null && result != DBNull.Value)
                {
                    toplamAidat = Convert.ToInt32(result.ToString());
                }

            }

            return toplamAidat; // toplanan değeri döndürüyoruz
        }




    }



}