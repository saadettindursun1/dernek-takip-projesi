using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using BussinessLayer;
using System.Reflection;

namespace DernekUyelik
{
    public partial class uyegirisi : Form
    {
        public uyegirisi()
        {
            InitializeComponent();
        }

        private void uyegirisi_Load(object sender, EventArgs e)
        {
       
        }

  

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        //giriş yapma
        private void button2_Click(object sender, EventArgs e)
        {

            int sonuc = BLadmin.adminGirisi(textBox1.Text, textBox2.Text); // giriş methoduna kullanıcıdan alınan veriler ile
                                                                           // gidiliyor ve sonuc yazdırılıyor

            if (sonuc==0)// sonuç 0 ise böyle bir kullanıcı yok
            {
                MessageBox.Show("HATALI KULLANICI ADI VEYA ŞİFRE");
               
            }
            else  // diğer durumda ise kullanıcı var demektir
            {
                MessageBox.Show("Giriş Başarılı Yönlendiriyorsun.");
                ana_ekran form = new ana_ekran(); 
                form.Show(); // ana ekranın bulunduğu forma yönlendiriyor
                this.Hide(); // bu formu gizliyor
            }
        }

    
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
