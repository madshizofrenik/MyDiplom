using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


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
            //Вызов класса обработки митодом Собеля
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

        private void ClearLoadBox_btn_Click(object sender, EventArgs e)
            //Очистка окна загрузки изображения
        {
            LoadImg_box.Image = null;
        }

        private void ClearConvBox_btn_Click(object sender, EventArgs e)
            //Очистка окна обработки изображения
        {
            ConvertImg_box.Image = null;
        }


    }
}
