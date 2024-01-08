using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class BLaidatAylar
    {


        //aidat listeleme
        public static List<EntaidatAylar> aidatListe()
        {
            return DALaidatBilgi.aidatListesi();
        }

        //aidat günceleme
        public static int aidatGuncelle(EntaidatAylar p)
        {
            return DALaidatBilgi.aidatGuncelle(p);
        }
        

    }   
}
