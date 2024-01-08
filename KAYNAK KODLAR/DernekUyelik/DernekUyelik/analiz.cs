using BussinessLayer;
using DataAccessLayer;
using EntityLayer;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace DernekUyelik
{
    public partial class analiz : Form
    {
        public analiz()
        {
            InitializeComponent();
        }


     


        //şehirlere göre üye dağılımı analizi methodu
        private void CreateGraph()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

            //analiz öğesinin özellikleri belirtiliyor
            myPane.Title.Text = "Üye Dağılımı";
            myPane.XAxis.Title.Text = "Şehirler";
            myPane.YAxis.Title.Text = "Üye Sayısı";
            string[] cityLabels = new string[81];
            int donguSayi = 0;
            PointPairList dataPoints = new PointPairList();

            List<Entsehirler> sehirler = BLsehirler.sehirListe(); // veritabanından şehir listesi alınıyor
            foreach (Entsehirler x in sehirler) // sehirler döngüye sokuluyor
            {
                cityLabels[donguSayi] = x.sehirAdi;
                donguSayi++;
                int uyeSayi = BLuyeler.UyeListeSehir(x.sehirAdi); // şehir adından üye sayısını veren methoda başvuruluyor

                dataPoints.Add(donguSayi, uyeSayi); // analiz nesnesine gerekli değerler ekleniyor


            }




            

            // Eksenleri kategorik yapın
            myPane.XAxis.Type = AxisType.Text;

            // Eksen etiketlerini ayarlayın
            myPane.XAxis.Scale.TextLabels = cityLabels;
            myPane.XAxis.Scale.Max = cityLabels.Length;

            // Çizgi grafiği ekle
            LineItem myCurve = myPane.AddCurve("Üye Dağılımı", dataPoints, Color.Blue, SymbolType.Circle);

            // Eksenleri güncelle
            zedGraphControl1.AxisChange();

            // Grafik üzerine yazı ekleyebilirsiniz
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            // Grafik görünümünü güncelle
            zedGraphControl1.Invalidate();
        }

        //form yüklenirken yapılacaklar
        private void analiz_Load(object sender, EventArgs e)
        {
            CreateGraph(); // şehirlere göre üye dağılımı analizini getir
            CreateGraphAylar(); // aylara göre gelir analizini getir

            dateTimePicker1.CustomFormat = "yyyy"; // tarih seçim kutusunun sadece yıl bazlı göstermesi için ayarlama
            dateTimePicker2.CustomFormat = "yyyy";// tarih seçim kutusunun sadece yıl bazlı göstermesi için ayarlama

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            
        }


        
        //aylara göre gelir analizi
        private void CreateGraphAylar()
        {
            GraphPane myPane = zedGraphControl2.GraphPane;
            myPane.Title.Text = "Aylara Göre Gelir Dağılımı";
            myPane.XAxis.Title.Text = "Aylar";
            myPane.YAxis.Title.Text = "Gelirler";


            string[] aylar = { "OCAK", "ŞUBAT", "MART", "NİSAN", "MAYIS", "HAZİRAN",
                "TEMMUZ", "AĞUSTOS", "EYLÜL", "EKİM", "KASIM", "ARALIK" };

            PointPairList dataPoints = new PointPairList();

            for (int i = 1; i < 13; i++) // 12 ay için döngü başlatılıyor
            {
               int gelir= BLaidat.ayBazindaGelir(i); // her ay için aidat geliri sorgulanıyor
                dataPoints.Add(i, gelir); // gelen değer analiz nesnesine işleniyor

            }

            // Eksenleri kategorik yapın
            myPane.XAxis.Type = AxisType.Text;

            // Eksen etiketlerini ayarlayın
            myPane.XAxis.Scale.TextLabels = aylar;
            myPane.XAxis.Scale.Max = aylar.Length;

            // Çizgi grafiği ekle
            LineItem myCurve = myPane.AddCurve("Gelir Dağılımı", dataPoints, Color.Blue, SymbolType.Circle);

            // Eksenleri güncelle
            zedGraphControl2.AxisChange();

            // Grafik üzerine yazı ekleyebilirsiniz
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            // Grafik görünümünü güncelle
            zedGraphControl2.Invalidate();
        }


        //seçilen yıllara göre gelir analizi
        private void button2_Click(object sender, EventArgs e)
        {

            GraphPane myPane = zedGraphControl3.GraphPane;
            myPane.Title.Text = "Yıllara Göre Gelir Dağılımı";
            myPane.XAxis.Title.Text = "Yıllar";
            myPane.YAxis.Title.Text = "Gelirler";


            PointPairList dataPoints = new PointPairList();

            DateTime ilkTarih = dateTimePicker1.Value;
            DateTime sonTarih = dateTimePicker2.Value;
            int[] gelenSonuclar = BLaidat.yilBazindaGelir(ilkTarih,sonTarih); // seçilen iki yıl arasında bulunan
                                                           // tüm yılların aidat gelirlerini listeleyen methoda başvuruluyor

            int donguSay = 0;
            int diziSayi = sonTarih.Year - ilkTarih.Year; // iki tarih arasında kaç yıl olduğu bulunuyor
            string [] yillar = new string[diziSayi+1]; // yılların bulunacağı dizinin uzunluğu belirtiliyor
            for (int i = ilkTarih.Year; i <= sonTarih.Year; i++) // iki yıl arasındaki fark kadar döngü başlıyor
            {
                dataPoints.Add(i, gelenSonuclar[donguSay]); // döngüde bulunan yılın değeri sorgulanıyor ve ekleniyor
                yillar[donguSay] = i.ToString(); // yıl değeri ekleniyor
                donguSay++;
            }

            // Eksenleri kategorik yapın
            myPane.XAxis.Type = AxisType.Text;

            // Eksen etiketlerini ayarlayın
            myPane.XAxis.Scale.TextLabels = yillar;
            myPane.XAxis.Scale.Max = yillar.Length;

            // Çizgi grafiği ekle
            LineItem myCurve = myPane.AddCurve("Gelir Dağılımı", dataPoints, Color.Blue, SymbolType.Circle);

            // Eksenleri güncelle
            zedGraphControl3.AxisChange();

            // Grafik üzerine yazı ekleyebilirsiniz
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            // Grafik görünümünü güncelle
            zedGraphControl3.Invalidate();

        }

        private void button3_Click(object sender, EventArgs e)
        {
           

        }
    }
}
