using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALsehirler
    {


        //şehir listeleme methodu
        public static List<Entsehirler> sehirListesi()
        {
            List<Entsehirler> sehirler = new List<Entsehirler>();
            OleDbCommand cmd2 = new OleDbCommand("Select * from sehirler", baglanti.conn);
            if (cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
            OleDbDataReader dr = cmd2.ExecuteReader();// verileri okuyoruz
            while (dr.Read())
            {

                //okunan satırları liste türünde olan değişkenimize aktarıyoruz

                Entsehirler ent = new Entsehirler();
                ent.plaka = dr[0].ToString();
                ent.sehirAdi = dr[1].ToString();
           

                sehirler.Add(ent);
            }
            dr.Close();
            return sehirler;// şehirler değişkenini geri döndürüyoruz
        }
    }
}
