using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class BLsehirler
    {
        //şehir listeleme 
        public static List<Entsehirler> sehirListe()
        {
            return DALsehirler.sehirListesi();
        }
    }
}
