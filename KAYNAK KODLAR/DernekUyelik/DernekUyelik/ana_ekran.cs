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
    public partial class ana_ekran : Form
    {
        public ana_ekran()
        {
            InitializeComponent();
        }


        //form yüklendiğinde yapılacak işlemler..
        private void ana_ekran_Load(object sender, EventArgs e)
        {
            analiz a = new analiz(); // form ilk yüklendiğinde varsayılan olarak analiz ekranını gösteriyoruz
            a.TopLevel = false;
            panel1.Controls.Add(a); // analiz formunu anekranda bulunan panelin içerisinde gösteriyoruz
            a.Show();
            a.Dock = DockStyle.Fill;
            a.BringToFront();
        }


        //aidat işlemleri butonuna basıldığında
        private void button5_Click(object sender, EventArgs e)
        {
            aidat a = new aidat();
            a.TopLevel = false;
            panel1.Controls.Add(a); //aidat formunu anekranda bulunan panelin içerisinde gösteriyoruz
            a.Show();
            a.Dock = DockStyle.Fill;
            a.BringToFront();
        }

        //üye işlemleri butonuna basıldığında
        private void button1_Click(object sender, EventArgs e)
        {
            uye_islem a = new uye_islem();
            a.TopLevel = false;
            panel1.Controls.Add(a);  //üye işlem formunu anekranda bulunan panelin içerisinde gösteriyoruz
            a.Show();
            a.Dock = DockStyle.Fill;
            a.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        //kapat butonuna basıldığında
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //admin işlemleri butonuna basıldığında
        private void button6_Click(object sender, EventArgs e)
        {

            admin a = new admin();
            a.TopLevel = false;
            panel1.Controls.Add(a);  //admin formunu anekranda bulunan panelin içerisinde gösteriyoruz
            a.Show();
            a.Dock = DockStyle.Fill;
            a.BringToFront();
        }

        //analiz işlemleri butonuna basıldığında
        private void button3_Click(object sender, EventArgs e)
        {
            analiz a = new analiz();
            a.TopLevel = false;
            panel1.Controls.Add(a);  //analiz anekranda bulunan panelin içerisinde gösteriyoruz
            a.Show();
            a.Dock = DockStyle.Fill; 
            a.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
