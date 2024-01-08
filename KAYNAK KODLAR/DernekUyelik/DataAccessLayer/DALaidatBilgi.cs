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
    public class DALaidatBilgi
    {



        //aidat güncelleme methodu
        public static int aidatGuncelle(EntaidatAylar p)  //güncellenecek olan üyebilgisi EntaidatAylar türünde değişkeni alıyoruz
        {
            OleDbCommand cmd = new OleDbCommand("UPDATE aidatlar SET ocak=@p1,subat=@p2,mart=@p3, nisan=@p4, mayis=@p5, haziran=@p6," +
                " temmuz=@p7, agustos=@p8, eylul=@p9, ekim=@p10, kasim=@p11, aralik=@p12 WHERE dernekAdi='dernek'", baglanti.conn);

            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            //aldığımız değişkenin bilgilerini eşleştirip veritabanına gönderiyoruz

            cmd.Parameters.AddWithValue("@p1", p.ocak);
            cmd.Parameters.AddWithValue("@p2", p.subat);
            cmd.Parameters.AddWithValue("@p3", p.mart);
            cmd.Parameters.AddWithValue("@p4", p.nisan);
            cmd.Parameters.AddWithValue("@p5", p.mayis);
            cmd.Parameters.AddWithValue("@p6", p.haziran);
            cmd.Parameters.AddWithValue("@p7", p.temmuz);
            cmd.Parameters.AddWithValue("@p8", p.agustos);
            cmd.Parameters.AddWithValue("@p9", p.eylul);
            cmd.Parameters.AddWithValue("@p10", p.ekim);
            cmd.Parameters.AddWithValue("@p11", p.kasim);
            cmd.Parameters.AddWithValue("@p12", p.aralik);

            return cmd.ExecuteNonQuery(); // sorguyu çalıştırıyoruz
        }



        //aidat listeleme methodu
        public static List<EntaidatAylar> aidatListesi()
        {
            List<EntaidatAylar> aylar = new List<EntaidatAylar>();
            OleDbCommand cmd2 = new OleDbCommand("Select * from aidatlar", baglanti.conn); // veritabanı sorgusu yapıyoruz
            if (cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
            OleDbDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                //okunan satırları liste türünde olan değişkenimize aktarıyoruz

                EntaidatAylar ent = new EntaidatAylar();
                ent.ocak = Convert.ToInt16(dr[1].ToString());
                ent.subat = Convert.ToInt16(dr[2].ToString());
                ent.mart = Convert.ToInt16(dr[3].ToString());
                ent.nisan = Convert.ToInt16(dr[4].ToString());
                ent.mayis = Convert.ToInt16(dr[5].ToString());
                ent.haziran = Convert.ToInt16(dr[6].ToString());
                ent.temmuz = Convert.ToInt16(dr[7].ToString());
                ent.agustos = Convert.ToInt16(dr[8].ToString());
                ent.eylul = Convert.ToInt16(dr[9].ToString()); ;
                ent.ekim = Convert.ToInt16(dr[10].ToString());
                ent.kasim = Convert.ToInt16(dr[11].ToString());
                ent.aralik = Convert.ToInt16(dr[12].ToString());

                aylar.Add(ent);
            }
            dr.Close();
            return aylar; // oluşan listeyi geri döndürüyoruz
        }



    }
}
