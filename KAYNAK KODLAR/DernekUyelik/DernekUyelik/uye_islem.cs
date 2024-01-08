using BussinessLayer;
using DataAccessLayer;
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
    public partial class uye_islem : Form
    {
        public uye_islem()
        {
            InitializeComponent();
        }



        //üye listeleme methodu
       private void uyeGetir(List<Entuyeler> uyelistele)
        {

            listView1.Items.Clear(); // method başlangıcında listview nesnesinin eski verileri temizleniyor

            foreach (Entuyeler entuyeler in uyelistele) // üye listesi döngüye giriyor  
            {
                // listview nesnesine veriler ekleniyor
                ListViewItem item = new ListViewItem(entuyeler.TcNo.ToString());
                item.SubItems.Add(entuyeler.UyeAdSoyad);
                item.SubItems.Add(entuyeler.UyeSehir);
                item.SubItems.Add(entuyeler.UyeDogumtarihi);
                item.SubItems.Add(entuyeler.UyeKanGrubu);
                item.SubItems.Add(entuyeler.UyeEposta);
                item.SubItems.Add(entuyeler.UyelikBaslamaTarihi);
                item.SubItems.Add(entuyeler.UyelikBitisTarihi);
                item.SubItems.Add(entuyeler.UyelikDurumu);
                listView1.Items.Add(item);

            }


        }

        //form yüklendiğinde yapılacak işlemler
        private void uye_islem_Load(object sender, EventArgs e)
        {
            uyeGetir(BLuyeler.UyeListesiBL()); // üye getir methoduna veritabanından gelen veriler ile başvuruluyor
            List<Entsehirler> sehirler = sehirGetir(); // veritabanından şehirler listesi getiriliyor
            foreach (var x in sehirler) // getirilen liste döngüye sokuluyor
            {
               sehirGuncelle.Items.Add(x.sehirAdi); // güncelleme ekranındaki şehir seçim nesnesine veritabanından gelen şehirler ekleniyor
               sehirText.Items.Add(x.sehirAdi); // üye ekleme ekranındaki şehir seçim nesnesine veritabanından gelen şehirler ekleniyor
            }
        }


        //üye kaydetme butonuna basıldığında
        private void kaydet_Click(object sender, EventArgs e)
        {

            //üye ekleme methoduna gönderilmek üzere veriler hazırlanıyor
            Entuyeler uyelistele = new Entuyeler(); 
            uyelistele.TcNo = tcNoText.Text;
            uyelistele.UyeAdSoyad = adsoyadText.Text;
            uyelistele.UyeSehir = sehirText.Text;
            uyelistele.UyeKanGrubu = kangrupText.Text;
            uyelistele.UyeEposta = postaText.Text;
            uyelistele.UyeDogumtarihi = dogumText.Text;
            uyelistele.UyelikDurumu = "Aktif";
            uyelistele.UyelikBaslamaTarihi = DateTime.Now.ToString();
            uyelistele.UyelikBitisTarihi = "01.01.3000";

            string sonuc = BLuyeler.BLuyeekle(uyelistele); // üye ekleme methoduna yeni üyenin verileri ile başvuruluyor

           
            MessageBox.Show(sonuc);

            uyeGetir(BLuyeler.UyeListesiBL()); // üye eklendikten sonra tekrardan üye listelemesi yapılıyor
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }


        //üye silme butonuna tıklandığında
        private void button3_Click(object sender, EventArgs e)
        {
            string silinecek = listView1.SelectedItems[0].SubItems[0].Text; // listview'de seçilen satırın ilk değeri yani
                                                                            // tcNo değeri silinecek adlı değişkene atanıyor
            string sonuc = BLuyeler.UyeSilBL(silinecek); // silinecek tcNo değeriyle birlikte üyesil methoduna başvuruluyor
            MessageBox.Show(sonuc);
            uyeGetir(BLuyeler.UyeListesiBL()); // üye silindikten sonra tekrardan üye listelemesi yapılıyor

        }


        //seçili üyeyi güncelleme ekranında gösterme butonu
        private void button4_Click(object sender, EventArgs e)
        {

            //güncelleme ekranındaki textbox nesneleri seçili satırdaki değerler ile dolduruluyor
            tcGuncelle.Text = listView1.SelectedItems[0].SubItems[0].Text;
            adsoyadGuncelle.Text = listView1.SelectedItems[0].SubItems[1].Text;
            sehirGuncelle.Text = listView1.SelectedItems[0].SubItems[2].Text;
            kangrupGuncelle.Text = listView1.SelectedItems[0].SubItems[4].Text;
            postaGuncelle.Text = listView1.SelectedItems[0].SubItems[5].Text;
            dogumGuncelle.Text = listView1.SelectedItems[0].SubItems[3].Text;
            durumGuncelle.Text = listView1.SelectedItems[0].SubItems[8].Text;
            tabControl2.SelectedTab = tabPage6; // listeleme ekranından güncelleme ekranına geçiliyor
            groupBox1.Visible = true; // güncelleme ekranındaki nesnelerin içinde bulunduğu groupbox
                                      // nesnesinin görünürlüğü açık hale getiriliyor
        }


        //güncelle butonuna basıldığında
        private void button2_Click(object sender, EventArgs e)
        {
            //güncellenecek olan kullanıcının yeni verileri hazırlanıyor
            Entuyeler uyeGuncelle = new Entuyeler();
            uyeGuncelle.TcNo = tcGuncelle.Text;
            uyeGuncelle.UyeAdSoyad = adsoyadGuncelle.Text;
            uyeGuncelle.UyeSehir = sehirGuncelle.Text;
            uyeGuncelle.UyeKanGrubu = kangrupGuncelle.Text;
            uyeGuncelle.UyeEposta = postaGuncelle.Text;
            uyeGuncelle.UyeDogumtarihi = dogumGuncelle.Text;
            uyeGuncelle.UyelikDurumu = durumGuncelle.Text;

            int sonuc = BLuyeler.UyeGnclleBL(uyeGuncelle); // hazırlanan verilerle birlikte üye güncelle methoduna başvuruluyor
            if(sonuc == 1) { 
            MessageBox.Show("Güncelleme Başarılı..");
            }
            uyeGetir(BLuyeler.UyeListesiBL()); // güncellemeden sonra üyeler yeniden listeleniyor
        }


        //listele butonuna basıldığında
        private void button5_Click(object sender, EventArgs e)
        {
            string turSecim = comboBox1.Text;
            string turIcerik = comboBox2.Text;

            uyeGetir( BLuyeler.UyeListesiFiltreBL(turSecim,turIcerik)); // seçim ve içerik değerleri ile birlikte ilgili
                                                                        // listeleme methoduna başvuruluyor ve dönen değer
                                                                        // ile birlikte listeleme işlemi yapılıyor

        }


        //şehir listeleme
        private  List<Entsehirler> sehirGetir()
        {
           List<Entsehirler> sehirler = BLsehirler.sehirListe(); // veritabanında bulunan şehirler listeleniyor
            return sehirler;
        }


        //filtre türü seçildiğinde
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear(); // seçilen filtre ile ilgili içeriklerin bulunduğu seçim öğesi temizleniyor
            comboBox2.Text = "Seçim Yapınız";
            string turSecim = comboBox1.Text;


            //if blokları sayesinde seçilen filtreye göre filtre içerik öğesi dolduruluyor
            if(turSecim == "Kan Grubuna Göre") {
                comboBox2.Items.Add("A Rh(+)");
                comboBox2.Items.Add("A Rh(-)");
                comboBox2.Items.Add("B Rh(+)");
                comboBox2.Items.Add("B Rh(-)");
                comboBox2.Items.Add("AB Rh(+)");
                comboBox2.Items.Add("AB Rh(-)");
                comboBox2.Items.Add("0 Rh(+)");
                comboBox2.Items.Add("0 Rh(-)");

            }
            if(turSecim == "Şehire Göre") {

                List<Entsehirler> sehirler = sehirGetir(); 
                foreach(var x in sehirler)
                {
                    comboBox2.Items.Add(x.sehirAdi);
                }
            
            }
            if(turSecim == "Üye Durumuna Göre") {
                comboBox2.Items.Add("Aktif");
                comboBox2.Items.Add("Pasif");
            }

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }
    }
}
