using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WindowsFormsApp1
{
    public partial class RetouchForm : Form
        //Класс формы подготовки изображения
    {


        public RetouchForm()
        {
            InitializeComponent();           
        }

        private void LoadImg_btn_Click(object sender, EventArgs e)
            //Загружаем с диска изображение в бокс.
        {
            Bitmap image;
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.png; *.jpeg; *.bmp)|*.png; *.jpeg; *.bmp|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            image = new Bitmap(openFileDialog1.FileName);
//                            pictureBox3.Width = image.Width;
//                            pictureBox3.Height = image.Height;
                            LoadImg_box.Image = image;
                            LoadImg_box.Invalidate();   // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }


        private void BlackWhite_btn_Click(object sender, EventArgs e)
            //Вызов класса обработки Ч\Б
        {
            try
            {
                PhotoRetouch.BlackWhite(this);
            }

            catch (NullReferenceException)
            {
                MessageBox.Show("Load and process the image by filter.");
            }

        }

        private void CannyMethod_btn_Click(object sender, EventArgs e)
            //Вызов класса обработки методом Канни
        {
            try
            {
                PhotoRetouch.Canny(this);
            }

            catch (NullReferenceException)
            {
                MessageBox.Show("Load and process the image by filter.");
            }

        }

        private void SobelMethod_btn_Click(object sender, EventArgs e)
            //Вызов класса обработки Собеля
        {
            try
            {
                PhotoRetouch.Sobel(this);
            }

            catch (NullReferenceException)
            {
                MessageBox.Show("Load and process the image by filter.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int width = Convert.ToInt16(textBox2.Text);
            int height = Convert.ToInt16(textBox3.Text);

            //Смещение системы координат в точку клика курсором
 //           var g = pictureBox2.CreateGraphics();
 //           g.TranslateTransform(width, height);

            int pY, pX, group = 0;
            Color clr;

            ConvertImg_box.Refresh();
            Bitmap nImg = new Bitmap(LoadImg_box.Image.Width, LoadImg_box.Image.Height);

            //Считываем и записываем координаты в список
            for (pY=0; pY < LoadImg_box.Image.Height; pY++)
            {
                for (pX=0; pX < LoadImg_box.Image.Width; pX++)
                {
                    LoadImg_box.Refresh();
                    clr = (LoadImg_box.Image as Bitmap).GetPixel(pX, pY);
                    if ((clr.R.Equals(0)) && (clr.G.Equals(0)) && (clr.B.Equals(0)))
                    {
                        group = group + 1;
                        List<List<int>> list = new List<List<int>>();
                        List<int> array = new List<int>();
                        array.Add(group);
                        array.Add(pX);
                        array.Add(pY);
                        list.Add(array);
                    }

                    if (pixel_value(pX, pY) == 1)
                    {
                        nImg.SetPixel(pX, pY, Color.Black);
                    }
                    else
                    {
                        nImg.SetPixel(pX, pY, Color.White);
                    }
                    ConvertImg_box.Image = nImg;
                }


            }

        }

        private void ConvertImg_box_MouseClick(object sender, MouseEventArgs e)
        {
            // Система Координат
            
          if (ConvertImg_box.Image == null)
            {
                MessageBox.Show("Load and process the image by filter.");
               return;
            }
                int hY, wX;
                wX = ConvertImg_box.Image.Width;
                hY = ConvertImg_box.Image.Height;
                textBox2.Text = Convert.ToString(e.X);
                textBox3.Text = Convert.ToString(e.Y);
                Bitmap flag = new Bitmap(ConvertImg_box.Image);
                Graphics flagGraphics = Graphics.FromImage(flag);
                Pen myPen;
                myPen = new Pen(Color.Red);
                flagGraphics.DrawLine(myPen, 0, e.Y, wX, e.Y);
                flagGraphics.DrawLine(myPen, e.X, 0, e.X, hY);
                ConvertImg_box.Image = flag;
        }


        public int pixel_value(int X, int Y)
        {
            Color clr; byte val;
            clr = (LoadImg_box.Image as Bitmap).GetPixel(X, Y);
            if ((clr.R.Equals(0)) && (clr.G.Equals(0)) && (clr.B.Equals(0))) val = 1;
            else val = 0;
            return val;
        }

        private void ClearLoadBox_btn_Click(object sender, EventArgs e)
        {
            LoadImg_box.Image = null;
        }

        private void ClearConvBox_btn_Click(object sender, EventArgs e)
        {
            ConvertImg_box.Image = null;
        }


    }
}
