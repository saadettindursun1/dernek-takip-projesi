using BussinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DernekUyelik
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }


        //admin bilgilerini listeleme
        private void adminListele(List<Entadmin> admin)
        {


            foreach (Entadmin x in admin) //veritabanından gelen admin bilgileri dönüye sokuluyor

            {
                //gelen bilgiler ilgili textBox nesnelerine yerleştirliyor
                kullaniciAdi.Text = x.kullaniciAdi;
                parola.Text = x.parola;
                smtpSunucu.Text = x.smtpSunucu;
                smtpPort.Text = x.smtpPort.ToString();
                smtpKullaniciAdi.Text = x.smtpKullaniciAdi;
                smtpParola.Text = x.smtpParola;
                gondericiPosta.Text = x.gondericiEposta;
            }


        }


        //form yüklendiğinde yapılacaklar
        private void admin_Load(object sender, EventArgs e)
        {
            adminListele(BLadmin.adminListe());
        }


        //güncelle butonuna basıldığında yapılacaklar
        private void button1_Click(object sender, EventArgs e)
        {

            //güncelleme için gerekli bilgiler Entadmin öğesine işleniyor
            Entadmin admin = new Entadmin();
            admin.kullaniciAdi = kullaniciAdi.Text;
            admin.parola = parola.Text;
            admin.smtpSunucu = smtpSunucu.Text;
            admin.smtpPort =Convert.ToInt16(smtpPort.Text);
            admin.smtpParola = smtpParola.Text;
            admin.smtpKullaniciAdi = smtpKullaniciAdi.Text;
            admin.gondericiEposta = gondericiPosta.Text;

            BLadmin.adminGuncelleme(admin); // Entadmin öğesiyle birlikte güncelleme methoduna başvuruluyor

            MessageBox.Show("Güncelleme Başarılı");
           
        }
    }
}
