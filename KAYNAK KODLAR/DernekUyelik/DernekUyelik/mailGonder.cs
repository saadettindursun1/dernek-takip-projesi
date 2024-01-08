using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using EntityLayer;
using BussinessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DernekUyelik
{
    public partial class mailGonder : Form
    {
        public mailGonder()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        

        //mail gönder butonuna basıldığında 
        private void kaydet_Click(object sender, EventArgs e)
        {
            Gonder(baslik.Text, icerik.Text); // textBox'lardan alınan mail başlığı ve içeriği
                                              // ile birlikte mail gönderme methoduna başvuruluyor
            
        }

        List<Entadmin> admin;



        //mail gönderme methodu
        public bool Gonder(string konu, string icerik)
        {

            MailMessage ePosta = new MailMessage(); // mail göndermi işlemi başlatılıyor
            ePosta.From = new MailAddress(admin[0].gondericiEposta); // mail gönderici e postası belirleniyor
            //

            List<ListViewItem> postalar = mailListeView.Items.Cast<ListViewItem>().ToList();

            foreach(ListViewItem l in postalar) // mail gönderilecek olan üyelerin e-posta bilgileri
                                                // listview öğesinden alınarak döngüye sokuluyor
            {
                ePosta.To.Add(l.SubItems[2].Text); // her kullanıcının e-posta bilgisi mail gönderilecekler listesine ekleniyor
            }

            
          
            ePosta.Subject = konu; // mail başlığı
           
            ePosta.Body = icerik; // mail içeriği
            


            // smtp bilgileri giriliyor (buradaki smtp bilgileri veritabanındaki admin tablosundan geliyor)
            SmtpClient smtp = new SmtpClient();
            //
            smtp.Credentials = new System.Net.NetworkCredential(admin[0].smtpKullaniciAdi, admin[0].smtpParola);
            smtp.Port = 587;
            smtp.Host = admin[0].smtpSunucu;
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta); // mail gönderiliyor
                MessageBox.Show("Üyelere Mail Gönderildi");
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
            return kontrol;
        }

    

        //form yüklendiğinde yapılacaklar
        private void mailGonder_Load(object sender, EventArgs e)
        {
           admin = BLadmin.adminListe(); // form açıldığında admin bilgileri veritabanından çekiliyor
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
