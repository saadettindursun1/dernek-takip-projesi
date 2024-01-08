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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace DernekUyelik
{
    public partial class aidat : Form
    {
        public aidat()
        {
            InitializeComponent();
        }


        //aidat listeleme methodu
        private void aidatListele(List<EntaidatAylar> aidatlar)
        {

            foreach (EntaidatAylar entAylar in aidatlar) // aidat listesi döngüye sokuluyor
            {
                //hangi ayda ne kadar ücret olduğu bilgisi textboxlara yazdırılıyor
                ocak.Value = entAylar.ocak;
                subat.Value = entAylar.subat;
                mart.Value = entAylar.mart;
                nisan.Value = entAylar.nisan;
                mayis.Value = entAylar.mayis;
                haziran.Value = entAylar.haziran;
                temmuz.Value = entAylar.temmuz;
                agustos.Value = entAylar.agustos;
                eylul.Value = entAylar.eylul;
                ekim.Value = entAylar.ekim;
                kasim.Value = entAylar.kasim;
                aralik.Value = entAylar.aralik;
            }


        }


        //aidat güncelleme ekranı
        private void button1_Click(object sender, EventArgs e)
        {

            //güncelleme için gerekli olan veriler textboxlardan alınıp EntaidatAylar öğesine işleniyor
            EntaidatAylar entaidatAylar = new EntaidatAylar();
            entaidatAylar.ocak = Convert.ToInt16(ocak.Value);
            entaidatAylar.subat = Convert.ToInt16(subat.Value);
            entaidatAylar.mart = Convert.ToInt16(mart.Value);
            entaidatAylar.nisan = Convert.ToInt16(nisan.Value);
            entaidatAylar.mayis = Convert.ToInt16(mayis.Value);
            entaidatAylar.haziran = Convert.ToInt16(haziran.Value);
            entaidatAylar.temmuz = Convert.ToInt16(temmuz.Value);
            entaidatAylar.agustos = Convert.ToInt16(agustos.Value);
            entaidatAylar.eylul = Convert.ToInt16(eylul.Value);
            entaidatAylar.ekim = Convert.ToInt16(ekim.Value);
            entaidatAylar.kasim = Convert.ToInt16(kasim.Value);
            entaidatAylar.aralik = Convert.ToInt16(aralik.Value);

            BLaidatAylar.aidatGuncelle(entaidatAylar); // hazırlanmış öğe ile beraber aidat güncelleme methoduna başvuruyoruz
            MessageBox.Show("Güncelleme Başarılı");
        }





        //üye aidatlarını listeleme

        private void aidatlariGetir(List<Entaidat> aidatListele)
        {
            listView1.Items.Clear(); // listeleme başlamadan önce listview öğesinin önceki verilerini temizliyoruz


            foreach (Entaidat x in aidatListele) // gelen listeyi döngüye sokuyoruz
            {

                //döngüde satır satır aldığımız verileri listview öğesine ekliyoruz
                ListViewItem item = new ListViewItem(x.aidatId.ToString());
                item.SubItems.Add(x.tcNo.ToString());
                item.SubItems.Add(x.UyeAdSoyad.ToString());
                item.SubItems.Add(x.uyeMail.ToString());
                item.SubItems.Add(x.aidatUcret.ToString());
                item.SubItems.Add(x.aidatTarih.ToString());



                if (x.aidatDurum == false) // eğer ödenme durumu false ise arkaplan kırmızı oluyor ve yazı olarak ödenmedi yazıyor
                {
                    item.BackColor = Color.LightCoral;
                    item.SubItems.Add("Ödenmedi");

                }
                else // eğer ödenme durumu true ise arkaplan yeşil oluyor ve yazı olarak ödendi yazıyor
                {
                    item.BackColor = Color.PaleGreen;
                    item.SubItems.Add("Ödendi");

                }
                listView1.Items.Add(item); // listviewe öğe eklemesi

            }
        }


        //form yüklenirken yapılacaklar
        private void aidat_Load(object sender, EventArgs e)
        {
            aidatListele(BLaidatAylar.aidatListe()); // textboxlara aylık aidat ücretlerini listeleme
            aidatlariGetir(BLaidat.aidatListesi(bilgiText.Text)); // üye aidat bilgilerini listeleme
         // (bilgiText textbox öğesi başlangıçta boş olduğu için veritabanından tüm öğeler gelecektir)

        }
        
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           

        }


        //arama butonuna basıldığında
        private void button2_Click_2(object sender, EventArgs e)
        {
            aidatlariGetir(BLaidat.aidatListesi(bilgiText.Text)); // textboxa yazılan değer ile birlikte
                                                                  // ilgili listeleme methoduna başvuruluyor

        }


        //aidat ödendi olarak işaretleme butonu
        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(listView1.SelectedItems[0].SubItems[0].Text); // güncellenecek aidatın id bilgisi alınıyor
            bool durum = true; 

            BLaidat.aidatGuncelleme(durum,id); // id ile birlikte güncelleme methoduna başvuruluyor
            aidatlariGetir(BLaidat.aidatListesi(bilgiText.Text)); // güncellemeden sonra tekrar listeleme yapılıyor

        }


        //aidat kaydı silme butonuna basıldığında
        private void button4_Click(object sender, EventArgs e)
        {
            //ilk olarak kullanıcıya emin misiniz diye soruluyor
            DialogResult result = MessageBox.Show("Seçili kaydı silmek istediğinizden emin misiniz?",
                "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kullanıcı evet derse
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt16(listView1.SelectedItems[0].SubItems[0].Text); // seçilen satırın idsini alıyoruz

                BLaidat.aidatSilme(id); // aldığımız id ile birlikte aidat silme methoduna başvuruyoruz
                aidatlariGetir(BLaidat.aidatListesi(bilgiText.Text));


            }
        }


        //iki tarih arasında ödenmiş veya ödenmemiş aidatları listeleme
        private void button5_Click(object sender, EventArgs e)
        {
            DateTime t1 = tarih1.Value; //ilk tarih seçimi
            DateTime t2 = tarih2.Value; // ikinci tarih seçimi
            string secim = comboBox1.Text; // aidat ödenme durumu seçimi
            bool secimDurum = true ; // varsayılan olarak true değeri veriyoruz eğer ödenmemiş seçildiyse false yapıyoruz

           
            if(secim=="Ödenmemiş Aidatlar") { secimDurum = false; }
            aidatlariGetir( BLaidat.aidatListeTarihveDurum(t1, t2, secimDurum)); // elimizdeki veriler ile birlikte ilgili
                                                                                 // listeleme methoduna başvuruyoruz
        }


        //ödenmemiş aidatları getir butonuna basıldığında
        private void button6_Click(object sender, EventArgs e)
        {
            aidatlariGetir(BLaidat.aidatListeDurum());// günü geçmiş ve ödenmemiş aidatları listeleyen methoda başvuruyoruz
        }


        //pdf olarak kaydemne butonuna basıldığında
        private void button7_Click(object sender, EventArgs e)
        {

            // Kullanıcının istediği yere PDF'yi kaydetmesini sağlayan SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Dosyaları|*.pdf";
            saveFileDialog.Title = "PDF Kaydet";
            saveFileDialog.FileName = "UyeListesi.pdf"; // Varsayılan dosya adı

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputPath = saveFileDialog.FileName; // dosya yolunu seçilen dosya yolu olarak atıyor
                List<string[]> dataList = new List<string[]>(); 

                foreach (ListViewItem item in listView1.Items) // listview'de bulunan öğeler döngüye giriyor
                {
                    //pdf için data bilgisi dolduruluyor
                    string[] data =
                  {
                      item.SubItems[1].Text,
                      item.SubItems[2].Text,
                      item.SubItems[3].Text,
                      item.SubItems[4].Text,
                      item.SubItems[5].Text,
                  };
                    dataList.Add(data); // datalist listesine data öğesi ekleniyor
                }

                // PDF oluştur
                CreatePDF(dataList, outputPath); // elimizdeki veriler ve dosya yolu ile pdf oluşturma methoduna başvuruluyor

                MessageBox.Show("PDF dosyası oluşturuldu.");
            }


            
        }


        //PDF oluşturma methodu
        private void CreatePDF(List<string[]> data, string outputPath)
        {
            using (PdfWriter writer = new PdfWriter(outputPath))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);
                    Paragraph title = new Paragraph("SAHAFLAR DERNEGI UYE LISTESI")
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetFontSize(18);
                    document.Add(title);

                    // Belge genişliğini al
                    float documentWidth = pdf.GetDefaultPageSize().GetWidth();

                    Table table = new Table(4);
                    table.SetWidth(documentWidth-50); // Tabloyu belge genişliğine ayarla


                    //tablo başlıkları ekleniyor
                    table.AddCell("T.C.No");
                    table.AddCell("Ad Soyad");
                    table.AddCell("E Mail");
                    table.AddCell("Aidat Ücret");
                    table.AddCell("Aidat Tarihi");

                    foreach (string[] item in data) // tablo içeriğini doldurmak için döngü başlıyor
                    {
                        //tablo içeriği dolduruluyor
                        table.AddCell(item[0]);
                        table.AddCell(item[1]);
                        table.AddCell(item[2]);
                        table.AddCell(item[3]);
                        table.AddCell(item[4]);
                    }

                    document.Add(table);
                }
            }
        }



        //üyelere mail gönder butonuna basıldığında
        private void button8_Click(object sender, EventArgs e)
        {
            // gönderilen mailleri saklayan bir hashset
            HashSet<string> gonderilenMailler = new HashSet<string>();


            mailGonder m = new mailGonder(); // mail gönderme form ekranı hazırlanıyor
            m.mailListeView.Items.Clear(); // mail gönderme form ekranındaki listview'in eski verileri temizleniyor
            List<ListViewItem> data = listView1.Items.Cast<ListViewItem>().ToList();

            foreach (ListViewItem item in data) // bizim formumuzda bulunan listview öğeleri döngüye giriyor
            {
                

                if (!gonderilenMailler.Contains(item.SubItems[3].Text)) { // eğer daha önce listeye eklendiyse bir daha eklememesi için
               
                  
                //mail gönderme formundaki listview dolduruluyor    
                ListViewItem newItem = new ListViewItem(item.SubItems[1].Text);
                newItem.SubItems.Add(item.SubItems[2].Text);
                newItem.SubItems.Add(item.SubItems[3].Text);
                m.mailListeView.Items.Add(newItem);
                    gonderilenMailler.Add(item.SubItems[3].Text);
                }

            }
            m.Show(); // mail gönderme form ekranı açılıyor

        }
        



        }
}
