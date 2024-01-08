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
    public class DALadmin
    {

        //admin bilgilerini güncelleme methodu
        public static int adminGuncelle(Entadmin p) // güncellencek olan admin bilgisi için Entadmin türünden bir nesne alıyoruz 
        {
            OleDbCommand cmd4 = new OleDbCommand("Update admin set kullaniciAdi=@p2,Parola=@p3,smtpSunucu=@p4,smtpPort=@p5" +
                ",smtpKullaniciAdi=@p6,smtpParola=@p7,gondericiEposta=@p8 where adminId=1", baglanti.conn);
            if (cmd4.Connection.State != ConnectionState.Open)


            {
                cmd4.Connection.Open();
            }

            // aldığımız nesne bilgilerini veritabanına gönderilecek veriler ile eşitliyoruz.
            cmd4.Parameters.AddWithValue("@p2", p.kullaniciAdi);
            cmd4.Parameters.AddWithValue("@p3", p.parola);
            cmd4.Parameters.AddWithValue("@p4", p.smtpSunucu);
            cmd4.Parameters.AddWithValue("@p5", p.smtpPort);
            cmd4.Parameters.AddWithValue("@p6", p.smtpKullaniciAdi);
            cmd4.Parameters.AddWithValue("@p7", p.smtpParola);
            cmd4.Parameters.AddWithValue("@p8", p.gondericiEposta);
            return cmd4.ExecuteNonQuery();

        }



        //admin bilgilerini listeleme methodu
        public static List<Entadmin> adminListesi() //admin listeleme methodu
        {
            List<Entadmin> admin = new List<Entadmin>();  // dönecek değeri karşılamak için Entadmin türünde bir liste oluşturuyoruz
            OleDbCommand cmd2 = new OleDbCommand("Select * from admin", baglanti.conn);
            if (cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
            OleDbDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {

                Entadmin ent = new Entadmin(); //veritabanından gelen bilgileri karşılamak için Entadmin türünde liste oluşturduk
                ent.kullaniciAdi = dr[1].ToString();
                ent.parola = dr[2].ToString();
                ent.smtpSunucu = dr[3].ToString();
                ent.smtpPort = Convert.ToInt16(dr[4].ToString());
                ent.smtpKullaniciAdi = dr[5].ToString();
                ent.smtpParola = dr[6].ToString();
                ent.gondericiEposta = dr[7].ToString();

                admin.Add(ent); // oluşturduğumuz nesneyi methodun başında olşturduğumuz listeye ekliyoruz
            }
            dr.Close();
            return admin; // method dönüş değeri olarak doldurduğumuz listeyi gönderiyoruz
        }


        //admin giriş kontrol methodu
        public static int adminGiris(string kullaniciAdi,string parola) // methodun çalışabilmesi için kullanıcı adı
                                                                        // ve parola adında iki parametre bekliyoruz
        {
            int satirSay = 0; //veritabanından dönecek olan sayısal değeri karşılamak için oluşturduk

            try
            {
                OleDbCommand cmd = new OleDbCommand("SELECT COUNT(*) FROM admin WHERE kullaniciAdi = @p1 and parola=@p2", baglanti.conn);
                // method çağırıldığında gönderilen parametreleri veritabanı sorgusunda ilgili yerlere koyuyoruz
                cmd.Parameters.AddWithValue("@p1", kullaniciAdi);
                cmd.Parameters.AddWithValue("@p2", parola);

                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }

                satirSay = Convert.ToInt32(cmd.ExecuteScalar()); // gönderdiğimiz parametreler sonucunda dönen satır sayısı
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                Console.WriteLine(ex.Message);
            }

            return satirSay;  // satır sayısını dönüş değeri olarak gönderiyoruz

        }

    }
}
