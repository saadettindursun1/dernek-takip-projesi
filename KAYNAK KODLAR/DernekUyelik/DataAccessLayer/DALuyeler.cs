using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccessLayer
{
    public class DALuyeler
    {
        //üye ekleme methodu
        public static int UyeEkle(Entuyeler p) //eklenecek olan üye bilgisi için Entuyeler türünden bir nesne alıyoruz
        {  
            OleDbCommand cmd = new OleDbCommand("insert into uyeler (TcNo,UyeAdSoyad,UyeSehir,UyeDogumtarihi,UyeKanGrubu,UyelikDurumu," +
                "UyeEposta,UyelikBaslamaTarihi,UyelikBitisTarihi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", baglanti.conn);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }

            // aldığımız nesne bilgilerini veritabanına gönderilecek veriler ile eşitliyoruz.
            cmd.Parameters.AddWithValue("@p1", p.TcNo);
            cmd.Parameters.AddWithValue("@p2", p.UyeAdSoyad);
            cmd.Parameters.AddWithValue("@p3", p.UyeSehir);
            cmd.Parameters.AddWithValue("@p4", p.UyeDogumtarihi);
            cmd.Parameters.AddWithValue("@p5", p.UyeKanGrubu);
            cmd.Parameters.AddWithValue("@p6", p.UyelikDurumu);
            cmd.Parameters.AddWithValue("@p7", p.UyeEposta);
            cmd.Parameters.AddWithValue("@p8", p.UyelikBaslamaTarihi);
            cmd.Parameters.AddWithValue("@p9", p.UyelikBitisTarihi);
            try { 
            return cmd.ExecuteNonQuery();  // sorguyu çalıştırıyoruz
            }
            catch
            {
                return 0;
            }

        }



        //üye listeleme methodu

        public static List<Entuyeler> UyeListesi()
        {
            List<Entuyeler> uyeler = new List<Entuyeler>();
            OleDbCommand cmd2 = new OleDbCommand("Select * from uyeler", baglanti.conn); // veritabanı sorgusu yapıyoruz
            if(cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
            OleDbDataReader dr=cmd2.ExecuteReader();
            while (dr.Read())
            {
                //okunan satırları liste türünde olan değişkenimize aktarıyoruz

                Entuyeler ent =new Entuyeler();
                ent.TcNo = dr[0].ToString();
                ent.UyeAdSoyad = dr[1].ToString();
                ent.UyeSehir = dr[2].ToString();
                ent.UyeDogumtarihi = dr[3].ToString();
                ent.UyeKanGrubu = dr[4].ToString();
                ent.UyelikDurumu = dr[5].ToString();
                ent.UyeEposta = dr[6].ToString();
                ent.UyelikBaslamaTarihi = dr[7].ToString();
                ent.UyelikBitisTarihi = dr[8].ToString();
                uyeler.Add(ent); 
            }
            dr.Close();
            return uyeler; // oluşan listeyi geri döndürüyoruz
        }


        // üye arama methodu.
        public static List<Entuyeler> UyeListesiFiltreli(string filtre,string filtreIcerik) // filtre türü ve içeriğini alıyoruz
        {
            List<Entuyeler> uyeler = new List<Entuyeler>();
            try
            {

                OleDbCommand cmd2 = new OleDbCommand("Select * from uyeler where "+filtre+" =@p1", baglanti.conn);

                //aldığımız filtre içerik bilgisini veritabanına gönderiyoruz
            cmd2.Parameters.AddWithValue("@p1", filtreIcerik);
            if (cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
     
            OleDbDataReader dr = cmd2.ExecuteReader();
           
            while (dr.Read())
            {
                //okunan satırları liste türünde olan değişkenimize aktarıyoruz
                Entuyeler ent = new Entuyeler();
                ent.TcNo = dr[0].ToString();
                ent.UyeAdSoyad = dr[1].ToString();
                ent.UyeSehir = dr[2].ToString();
                ent.UyeDogumtarihi = dr[3].ToString();
                ent.UyeKanGrubu = dr[4].ToString();
                ent.UyelikDurumu = dr[5].ToString();
                ent.UyeEposta = dr[6].ToString();
                ent.UyelikBaslamaTarihi = dr[7].ToString();
                ent.UyelikBitisTarihi = dr[8].ToString();
                uyeler.Add(ent);
            }
            dr.Close();
            }
            catch { }
            return uyeler; // oluşan üye listesini geri döndürüyoruz

        }


        // gelen şehir bilgisine ait kaç üye olduğunu listeleyen method
        public static int UyeListesiSehir(string sehir)
        {
            int uyeSayisi = 0;

            try
            {
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM uyeler WHERE UyeSehir = @p1", baglanti.conn);

                //aldığımız şehir bilgisini veritabanına gönderiyoruz
                cmd.Parameters.AddWithValue("@p1", sehir);

                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }

                uyeSayisi = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                Console.WriteLine(ex.Message);
            }

            return uyeSayisi; // kaç üye olduğunu geri döndürüyoruz

        }



        // üye silme methodu
        public static string UyeSil (string p) // silinecek üyenin tcNo değerini alıyoruz
        {
            OleDbCommand cmd3 = new OleDbCommand("Delete From uyeler where TcNo=@p1", baglanti.conn);
            if(cmd3.Connection.State != ConnectionState.Open)
            {
                cmd3.Connection.Open();
            }


            //aldığımız tcNo bilgisini veritabanına gönderiyoruz
            cmd3.Parameters.AddWithValue("@p1", p);
             cmd3.ExecuteNonQuery(); //sorguyu çalıştırıyoruz
            return "Silme İşlemi Başarılı"; 
        }



        //üye bilgileri güncelleme methodu
        public static int UyeGnclle(Entuyeler p)   //güncellenecek olan üyebilgisi Entuyeler türünde değişkeni alıyoruz
        {
            OleDbCommand cmd4 = new OleDbCommand("Update uyeler set UyeAdSoyad=@p2,UyeSehir=@p3,UyeDogumtarihi=@p4,UyeKanGrubu=@p5" +
                ",UyelikDurumu=@p6,UyeEposta=@p7 where TcNo=@tc", baglanti.conn);
            if (cmd4.Connection.State != ConnectionState.Open)
            {
                cmd4.Connection.Open();
            }

            //aldığımız değişkenin bilgilerini eşleştirip veritabanına gönderiyoruz
            cmd4.Parameters.AddWithValue("@p2", p.UyeAdSoyad);
            cmd4.Parameters.AddWithValue("@p3", p.UyeSehir);
            cmd4.Parameters.AddWithValue("@p4", p.UyeDogumtarihi);
            cmd4.Parameters.AddWithValue("@p5", p.UyeKanGrubu);
            cmd4.Parameters.AddWithValue("@p6", p.UyelikDurumu);
            cmd4.Parameters.AddWithValue("@p7", p.UyeEposta);
            cmd4.Parameters.AddWithValue("@tc", p.TcNo);
            return cmd4.ExecuteNonQuery();

        }
    }
}
