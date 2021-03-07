using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman09
{
    public partial class Form1 : Form
    {       
        int yemsayisi = 0;
        int MouseX;// bu satır mouse'un X değerini global değişken olarak tutar
        int MouseY;// bu satır mouse'un Y değerini global değişken olarak tutar
        int zaman = 80;//Pacmanin hedefe varması için kaç milisaniye gerektiği
        bool kazandimi=false;//oyunun kazanılıp kazanılmadığını tutan değişken
        float derece = 0;//Pacmanin mousa kaç derecelik açıyla bakmasını tutan global değişken

        public async void Pacmanfonksiyonu()//pacmanın ana fonksiyonu, tanımlanış şekliyle programın işleyişini engellemeden çalışıyor
        {          
            while (!kazandimi)// Oyun kazanılana dek çalışacak olan döngü
            {
              
               if(MouseX!=pictureBoxPacman.Location.X || MouseY != pictureBoxPacman.Location.Y)// Pacmanin mause ile aynı konumda olup olmadığını kontrol eder
                {                   
                    await Task.Delay(10); //hareketi 10 milisaniye bekletir
                    
                    // mousenin ve pacmanin arasındaki mesafeyi verir
                    int deltax = (MouseX - pictureBoxPacman.Location.X);
                    int deltay = (MouseY - pictureBoxPacman.Location.Y);
                    pictureBoxPacman.Location = new Point(pictureBoxPacman.Location.X + (deltax /zaman),pictureBoxPacman.Location.Y + (deltay / zaman));// pacmanin yeni koordinasyon bilgisini, birim zamanda gitmesi gereken yol ile eski koordinasyon bilgisine ekleyerek bulur.

                    Image pacman = Image.FromFile("acik.png");//Pacmanin ağzının açık olduğu resmi alır
                    
                    pictureBoxPacman.Image = RotateImage(pacman, derece * 40);// yukarıda aldığı resmi döndürerek pictureboxa koyar                                                            
                }

                if (pictureBoxPacman.Bounds.IntersectsWith(PBYem.Bounds))// yem ve pacmanin pictureboxlarının kesişip kesişmediklerini denetler
                {
                    yemsayisi++;// pacmanın yediği yem sayısını arttırır
                    Random rastgele = new Random();
                    int xrastgele = rastgele.Next(0, panel1.Width-10);  // panelin genişliğine göre rastgele bir x değeri üretir
                    int yrastgele = rastgele.Next(0, panel1.Height-10); // panelin genişliğine göre rastgele bir y değeri üretir
                    PBYem.Location = new Point(xrastgele, yrastgele);   // yemin yeni konumunu oluşturur
                }
                labelYem.Text = "PUAN: "+yemsayisi.ToString();// pacmanin yediği yem sayısını label üzerinde gösterir
                if (yemsayisi == 15)//Oyuncunun oyunun amacına ulaşıp ulaşmadığını kontrol eder
                {

                   
                    DialogResult yeniden = MessageBox.Show("Yeniden Oynamak İster Misiniz?", "Tebrikler!! Kazandınız.", MessageBoxButtons.YesNo);//oyun kazanıldıysa ,oyunun kazanıldığını belirten messageboxu oluştutur ve yeniden oynamk istermisiniz diye sorar
                    if (yeniden == DialogResult.Yes)//cevap evet ise yenilen yem sayısını sıfırlar ve yeniden başlatır
                    {
                        yemsayisi = 0;
                        kazandimi = false;
                    }
                    else if (yeniden == DialogResult.No)
                    {
                        kazandimi = true;// oyunun kazanıldığını tutar        
                        this.Close();//formu kapatır
                    }
                               
                }                            
            };  
           
        }
        public Form1()
        {
            InitializeComponent();
            Pacmanfonksiyonu();// oyunun ana döngüsü olan fonksiyonu başlatır  
        }

        public static Image RotateImage(Image img, float rotationAngle)//Verilen derece değerine göre resmi döndürür kaynak: https://stackoverflow.com/questions/2163829/how-do-i-rotate-a-picture-in-winforms
        {           
            Bitmap bmp = new Bitmap(img.Width, img.Height);//Boş bir bitmap resmi oluşturur
          
            Graphics gfx = Graphics.FromImage(bmp);//Bitmap resmini Graphics objesine dönüştürür
           
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);//Döndürme noktasını resmin merkezi olarak ayarlar
           
            //resmi döndürür
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic; //görüntü kalitesini bozmamak için InterpolationMode u HighQualityBicubic e seçer                     

            gfx.DrawImage(img, new Point(0, 0)); //Yeni resmi grafik objesine çizer

            gfx.Dispose(); //Boşu boşuna ram harcamamak için grafik objesini kapatır

            return bmp;//resmi verir
        }
        
        private void Form1_MouseMove(object sender, MouseEventArgs e) // mouse un formdaki hareketini algılar
        {           
            derece = Convert.ToSingle(Math.Atan2(e.Y - pictureBoxPacman.Location.Y, e.X - pictureBoxPacman.Location.X));//dereceyi hesaplayıp float türüne çevirir
            Image pacman = Image.FromFile("Kapali.png");//pacmanin ağzını kapatır
            pictureBoxPacman.Image = RotateImage(pacman, derece * 40);//pacmani döndürür                                                                                 
        }
      
        private void panel1_MouseMove(object sender, MouseEventArgs e)// mouse un paneldeki hareketini algılar
        {

            MouseX = e.X;// mouse konumunu, pacmanin hareket etmesi için global değişkenlere girer
            MouseY = e.Y;
            derece = Convert.ToSingle(Math.Atan2(MouseY - pictureBoxPacman.Location.Y, MouseX - pictureBoxPacman.Location.X));//dereceyi hesaplayıp float türüne çevirir
            Image pacman = Image.FromFile("Kapali.png");//pacmanin ağzını kapatır
            pictureBoxPacman.Image = RotateImage(pacman, derece * 40);//pacmani döndürür
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)//mouse tuşuna basılı tutulduğunda pacmanin hızını arttırır
        {           
                zaman = 10;                             
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)//mouse tuşunun bırakılmasıyla pacmanin hızı eski haline döner 
        {           
                zaman = 80;                   
        }

        private void button1_Click(object sender, EventArgs e)//oyun ile ilgili bir ipucu verir
        { 
            MessageBox.Show("Pacman köşelere yaklaştığında Mouse tuşlarına basınız.");
        }
    }
}
      