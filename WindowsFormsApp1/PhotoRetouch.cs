﻿using System;
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
    class PhotoRetouch
        //Класс обработки изображений 
    {
        public static void BlackWhite(RetouchForm form)
        //Перевод в серые тона
        {
            Bitmap grayImg = new Bitmap(form.LoadImg_box.Image);
            Graphics g = Graphics.FromImage(grayImg);
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
            {
                new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                new float[] {     0,      0,      0, 1, 0},
                new float[] {     0,      0,      0, 0, 0}

            });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(form.LoadImg_box.Image,
                new Rectangle(0, 0, form.LoadImg_box.Image.Width, form.LoadImg_box.Image.Height), 0, 0,
                form.LoadImg_box.Image.Width, form.LoadImg_box.Image.Height,
                GraphicsUnit.Pixel, attributes);
            g.Dispose();
            form.ConvertImg_box.Image = grayImg;
        }

        public static void Canny(RetouchForm form)
        //Обработка изображения методом Канни
        {
            Bitmap b = new Bitmap(form.LoadImg_box.Image);
            int width = b.Width;
            int height = b.Height;

            Bitmap n = new Bitmap(width, height);

            int[,] allPixR = new int[width, height];
            int[,] allPixG = new int[width, height];
            int[,] allPixB = new int[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allPixR[i, j] = b.GetPixel(i, j).R;
                    allPixG[i, j] = b.GetPixel(i, j).G;
                    allPixB[i, j] = b.GetPixel(i, j).B;
                }
            }
            for (int i = 2; i < b.Width - 2; i++)
            {
                for (int j = 2; j < b.Height - 2; j++)
                {
                    int red = (
                              ((allPixR[i - 2, j - 2]) * 1 + (allPixR[i - 1, j - 2]) * 4 + (allPixR[i, j - 2]) * 7 + (allPixR[i + 1, j - 2]) * 4 + (allPixR[i + 2, j - 2])
                              + (allPixR[i - 2, j - 1]) * 4 + (allPixR[i - 1, j - 1]) * 16 + (allPixR[i, j - 1]) * 26 + (allPixR[i + 1, j - 1]) * 16 + (allPixR[i + 2, j - 1]) * 4
                              + (allPixR[i - 2, j]) * 7 + (allPixR[i - 1, j]) * 26 + (allPixR[i, j]) * 41 + (allPixR[i + 1, j]) * 26 + (allPixR[i + 2, j]) * 7
                              + (allPixR[i - 2, j + 1]) * 4 + (allPixR[i - 1, j + 1]) * 16 + (allPixR[i, j + 1]) * 26 + (allPixR[i + 1, j + 1]) * 16 + (allPixR[i + 2, j + 1]) * 4
                              + (allPixR[i - 2, j + 2]) * 1 + (allPixR[i - 1, j + 2]) * 4 + (allPixR[i, j + 2]) * 7 + (allPixR[i + 1, j + 2]) * 4 + (allPixR[i + 2, j + 2]) * 1) / 273
                              );

                    int green = (
                              ((allPixG[i - 2, j - 2]) * 1 + (allPixG[i - 1, j - 2]) * 4 + (allPixG[i, j - 2]) * 7 + (allPixG[i + 1, j - 2]) * 4 + (allPixG[i + 2, j - 2])
                              + (allPixG[i - 2, j - 1]) * 4 + (allPixG[i - 1, j - 1]) * 16 + (allPixG[i, j - 1]) * 26 + (allPixG[i + 1, j - 1]) * 16 + (allPixG[i + 2, j - 1]) * 4
                              + (allPixG[i - 2, j]) * 7 + (allPixG[i - 1, j]) * 26 + (allPixG[i, j]) * 41 + (allPixG[i + 1, j]) * 26 + (allPixG[i + 2, j]) * 7
                              + (allPixG[i - 2, j + 1]) * 4 + (allPixG[i - 1, j + 1]) * 16 + (allPixG[i, j + 1]) * 26 + (allPixG[i + 1, j + 1]) * 16 + (allPixG[i + 2, j + 1]) * 4
                              + (allPixG[i - 2, j + 2]) * 1 + (allPixG[i - 1, j + 2]) * 4 + (allPixG[i, j + 2]) * 7 + (allPixG[i + 1, j + 2]) * 4 + (allPixG[i + 2, j + 2]) * 1) / 273
                              );

                    int blue = (
                              ((allPixB[i - 2, j - 2]) * 1 + (allPixB[i - 1, j - 2]) * 4 + (allPixB[i, j - 2]) * 7 + (allPixB[i + 1, j - 2]) * 4 + (allPixB[i + 2, j - 2])
                              + (allPixB[i - 2, j - 1]) * 4 + (allPixB[i - 1, j - 1]) * 16 + (allPixB[i, j - 1]) * 26 + (allPixB[i + 1, j - 1]) * 16 + (allPixB[i + 2, j - 1]) * 4
                              + (allPixB[i - 2, j]) * 7 + (allPixB[i - 1, j]) * 26 + (allPixB[i, j]) * 41 + (allPixB[i + 1, j]) * 26 + (allPixB[i + 2, j]) * 7
                              + (allPixB[i - 2, j + 1]) * 4 + (allPixB[i - 1, j + 1]) * 16 + (allPixB[i, j + 1]) * 26 + (allPixB[i + 1, j + 1]) * 16 + (allPixB[i + 2, j + 1]) * 4
                              + (allPixB[i - 2, j + 2]) * 1 + (allPixB[i - 1, j + 2]) * 4 + (allPixB[i, j + 2]) * 7 + (allPixB[i + 1, j + 2]) * 4 + (allPixB[i + 2, j + 2]) * 1) / 273
                              );
                    n.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }
            //pictureBox2.Image = n;//////////////////////////////////////////////////////here onward use n///////////////////////////////////////////////
            int[,] allPixRn = new int[width, height];
            int[,] allPixGn = new int[width, height];
            int[,] allPixBn = new int[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allPixRn[i, j] = n.GetPixel(i, j).R;
                    allPixGn[i, j] = n.GetPixel(i, j).G;
                    allPixBn[i, j] = n.GetPixel(i, j).B;
                }
            }


            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
            int new_rx = 0, new_ry = 0;
            int new_gx = 0, new_gy = 0;
            int new_bx = 0, new_by = 0;
            int rc, gc, bc;
            int gradR, gradG, gradB;

            int[,] graidientR = new int[width, height];
            int[,] graidientG = new int[width, height];
            int[,] graidientB = new int[width, height];

            int atanR, atanG, atanB;

            int[,] tanR = new int[width, height];
            int[,] tanG = new int[width, height];
            int[,] tanB = new int[width, height];

            //int limit = 128 * 128;
            //Bitmap bb = new Bitmap (pictureBox1.Image);

            for (int i = 1; i < b.Width - 1; i++)
            {
                for (int j = 1; j < b.Height - 1; j++)
                {

                    new_rx = 0;
                    new_ry = 0;
                    new_gx = 0;
                    new_gy = 0;
                    new_bx = 0;
                    new_by = 0;
                    rc = 0;
                    gc = 0;
                    bc = 0;

                    for (int wi = -1; wi < 2; wi++)
                    {
                        for (int hw = -1; hw < 2; hw++)
                        {
                            rc = allPixRn[i + hw, j + wi];
                            new_rx += gx[wi + 1, hw + 1] * rc;
                            new_ry += gy[wi + 1, hw + 1] * rc;

                            gc = allPixGn[i + hw, j + wi];
                            new_gx += gx[wi + 1, hw + 1] * gc;
                            new_gy += gy[wi + 1, hw + 1] * gc;

                            bc = allPixBn[i + hw, j + wi];
                            new_bx += gx[wi + 1, hw + 1] * bc;
                            new_by += gy[wi + 1, hw + 1] * bc;
                        }
                    }

                    //find gradieant
                    gradR = (int)Math.Sqrt((new_rx * new_rx) + (new_ry * new_ry));
                    graidientR[i, j] = gradR;

                    gradG = (int)Math.Sqrt((new_gx * new_gx) + (new_gy * new_gy));
                    graidientG[i, j] = gradG;

                    gradB = (int)Math.Sqrt((new_bx * new_gx) + (new_by * new_by));
                    graidientB[i, j] = gradB;
                    //
                    //find tans
                    ////////////////tan red//////////////////////////////////
                    atanR = (int)((Math.Atan((double)new_ry / new_rx)) * (180 / Math.PI));
                    if ((atanR > 0 && atanR < 22.5) || (atanR > 157.5 && atanR < 180))
                    {
                        atanR = 0;
                    }
                    else if (atanR > 22.5 && atanR < 67.5)
                    {
                        atanR = 45;
                    }
                    else if (atanR > 67.5 && atanR < 112.5)
                    {
                        atanR = 90;
                    }
                    else if (atanR > 112.5 && atanR < 157.5)
                    {
                        atanR = 135;
                    }

                    if (atanR == 0)
                    {
                        tanR[i, j] = 0;
                    }
                    else if (atanR == 45)
                    {
                        tanR[i, j] = 1;
                    }
                    else if (atanR == 90)
                    {
                        tanR[i, j] = 2;
                    }
                    else if (atanR == 135)
                    {
                        tanR[i, j] = 3;
                    }
                    ////////////////tan red end//////////////////////////////////

                    ////////////////tan green//////////////////////////////////
                    atanG = (int)((Math.Atan((double)new_gy / new_gx)) * (180 / Math.PI));
                    if ((atanG > 0 && atanG < 22.5) || (atanG > 157.5 && atanG < 180))
                    {
                        atanG = 0;
                    }
                    else if (atanG > 22.5 && atanG < 67.5)
                    {
                        atanG = 45;
                    }
                    else if (atanG > 67.5 && atanG < 112.5)
                    {
                        atanG = 90;
                    }
                    else if (atanG > 112.5 && atanG < 157.5)
                    {
                        atanG = 135;
                    }


                    if (atanG == 0)
                    {
                        tanG[i, j] = 0;
                    }
                    else if (atanG == 45)
                    {
                        tanG[i, j] = 1;
                    }
                    else if (atanG == 90)
                    {
                        tanG[i, j] = 2;
                    }
                    else if (atanG == 135)
                    {
                        tanG[i, j] = 3;
                    }
                    ////////////////tan green end//////////////////////////////////


                    ////////////////tan blue//////////////////////////////////
                    atanB = (int)((Math.Atan((double)new_by / new_bx)) * (180 / Math.PI));
                    if ((atanB > 0 && atanB < 22.5) || (atanB > 157.5 && atanB < 180))
                    {
                        atanB = 0;
                    }
                    else if (atanB > 22.5 && atanB < 67.5)
                    {
                        atanB = 45;
                    }
                    else if (atanB > 67.5 && atanB < 112.5)
                    {
                        atanB = 90;
                    }
                    else if (atanB > 112.5 && atanB < 157.5)
                    {
                        atanB = 135;
                    }

                    if (atanB == 0)
                    {
                        tanB[i, j] = 0;
                    }
                    else if (atanB == 45)
                    {
                        tanB[i, j] = 1;
                    }
                    else if (atanB == 90)
                    {
                        tanB[i, j] = 2;
                    }
                    else if (atanB == 135)
                    {
                        tanB[i, j] = 3;
                    }
                    ////////////////tan blue end//////////////////////////////////
                }
            }

            int[,] allPixRs = new int[width, height];
            int[,] allPixGs = new int[width, height];
            int[,] allPixBs = new int[width, height];

            for (int i = 2; i < width - 2; i++)
            {
                for (int j = 2; j < height - 2; j++)
                {

                    ////red
                    if (tanR[i, j] == 0)
                    {
                        if (graidientR[i - 1, j] < graidientR[i, j] && graidientR[i + 1, j] < graidientR[i, j])
                        {
                            allPixRs[i, j] = graidientR[i, j];
                        }
                        else
                        {
                            allPixRs[i, j] = 0;
                        }
                    }
                    if (tanR[i, j] == 1)
                    {
                        if (graidientR[i - 1, j + 1] < graidientR[i, j] && graidientR[i + 1, j - 1] < graidientR[i, j])
                        {
                            allPixRs[i, j] = graidientR[i, j];
                        }
                        else
                        {
                            allPixRs[i, j] = 0;
                        }
                    }
                    if (tanR[i, j] == 2)
                    {
                        if (graidientR[i, j - 1] < graidientR[i, j] && graidientR[i, j + 1] < graidientR[i, j])
                        {
                            allPixRs[i, j] = graidientR[i, j];
                        }
                        else
                        {
                            allPixRs[i, j] = 0;
                        }
                    }
                    if (tanR[i, j] == 3)
                    {
                        if (graidientR[i - 1, j - 1] < graidientR[i, j] && graidientR[i + 1, j + 1] < graidientR[i, j])
                        {
                            allPixRs[i, j] = graidientR[i, j];
                        }
                        else
                        {
                            allPixRs[i, j] = 0;
                        }
                    }

                    //green
                    if (tanG[i, j] == 0)
                    {
                        if (graidientG[i - 1, j] < graidientG[i, j] && graidientG[i + 1, j] < graidientG[i, j])
                        {
                            allPixGs[i, j] = graidientG[i, j];
                        }
                        else
                        {
                            allPixGs[i, j] = 0;
                        }
                    }
                    if (tanG[i, j] == 1)
                    {
                        if (graidientG[i - 1, j + 1] < graidientG[i, j] && graidientG[i + 1, j - 1] < graidientG[i, j])
                        {
                            allPixGs[i, j] = graidientG[i, j];
                        }
                        else
                        {
                            allPixGs[i, j] = 0;
                        }
                    }
                    if (tanG[i, j] == 2)
                    {
                        if (graidientG[i, j - 1] < graidientG[i, j] && graidientG[i, j + 1] < graidientG[i, j])
                        {
                            allPixGs[i, j] = graidientG[i, j];
                        }
                        else
                        {
                            allPixGs[i, j] = 0;
                        }
                    }
                    if (tanG[i, j] == 3)
                    {
                        if (graidientG[i - 1, j - 1] < graidientG[i, j] && graidientG[i + 1, j + 1] < graidientG[i, j])
                        {
                            allPixGs[i, j] = graidientG[i, j];
                        }
                        else
                        {
                            allPixGs[i, j] = 0;
                        }
                    }

                    //blue
                    if (tanB[i, j] == 0)
                    {
                        if (graidientB[i - 1, j] < graidientB[i, j] && graidientB[i + 1, j] < graidientB[i, j])
                        {
                            allPixBs[i, j] = graidientB[i, j];
                        }
                        else
                        {
                            allPixBs[i, j] = 0;
                        }
                    }
                    if (tanB[i, j] == 1)
                    {
                        if (graidientB[i - 1, j + 1] < graidientB[i, j] && graidientB[i + 1, j - 1] < graidientB[i, j])
                        {
                            allPixBs[i, j] = graidientB[i, j];
                        }
                        else
                        {
                            allPixBs[i, j] = 0;
                        }
                    }
                    if (tanB[i, j] == 2)
                    {
                        if (graidientB[i, j - 1] < graidientB[i, j] && graidientB[i, j + 1] < graidientB[i, j])
                        {
                            allPixBs[i, j] = graidientB[i, j];
                        }
                        else
                        {
                            allPixBs[i, j] = 0;
                        }
                    }
                    if (tanB[i, j] == 3)
                    {
                        if (graidientB[i - 1, j - 1] < graidientB[i, j] && graidientB[i + 1, j + 1] < graidientB[i, j])
                        {
                            allPixBs[i, j] = graidientB[i, j];
                        }
                        else
                        {
                            allPixBs[i, j] = 0;
                        }
                    }
                }
            }

            int threshold = Convert.ToInt16(form.textBox1.Text);
            int[,] allPixRf = new int[width, height];
            int[,] allPixGf = new int[width, height];
            int[,] allPixBf = new int[width, height];

            // Bitmap bb = new Bitmap (pictureBox1.Image);
            Bitmap bb = new Bitmap(width, height);

            for (int i = 2; i < width - 2; i++)
            {
                for (int j = 2; j < height - 2; j++)
                {
                    if (allPixRs[i, j] > threshold)
                    {
                        allPixRf[i, j] = 1;
                    }
                    else
                    {
                        allPixRf[i, j] = 0;
                    }

                    if (allPixGs[i, j] > threshold)
                    {
                        allPixGf[i, j] = 1;
                    }
                    else
                    {
                        allPixGf[i, j] = 0;
                    }

                    if (allPixBs[i, j] > threshold)
                    {
                        allPixBf[i, j] = 1;
                    }
                    else
                    {
                        allPixBf[i, j] = 0;
                    }



                    if (allPixRf[i, j] == 1 || allPixGf[i, j] == 1 || allPixBf[i, j] == 1)
                    {
                        bb.SetPixel(i, j, Color.Black);
                    }
                    else
                        bb.SetPixel(i, j, Color.White);
                }
            }
            form.ConvertImg_box.Image = bb;



        }

        public static void Sobel(RetouchForm form)
        //Обработка изображения методом Собеля
        {
            Bitmap b = new Bitmap(form.LoadImg_box.Image);
            Bitmap bb = new Bitmap(form.LoadImg_box.Image);
            int width = b.Width;
            int height = b.Height;
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            int[,] allPixR = new int[width, height];
            int[,] allPixG = new int[width, height];
            int[,] allPixB = new int[width, height];

            int limit = 128 * 128;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    allPixR[i, j] = b.GetPixel(i, j).R;
                    allPixG[i, j] = b.GetPixel(i, j).G;
                    allPixB[i, j] = b.GetPixel(i, j).B;
                }
            }

            int new_rx = 0, new_ry = 0;
            int new_gx = 0, new_gy = 0;
            int new_bx = 0, new_by = 0;
            int rc, gc, bc;
            for (int i = 1; i < b.Width - 1; i++)
            {
                for (int j = 1; j < b.Height - 1; j++)
                {

                    new_rx = 0;
                    new_ry = 0;
                    new_gx = 0;
                    new_gy = 0;
                    new_bx = 0;
                    new_by = 0;
                    rc = 0;
                    gc = 0;
                    bc = 0;

                    for (int wi = -1; wi < 2; wi++)
                    {
                        for (int hw = -1; hw < 2; hw++)
                        {
                            rc = allPixR[i + hw, j + wi];
                            new_rx += gx[wi + 1, hw + 1] * rc;
                            new_ry += gy[wi + 1, hw + 1] * rc;

                            gc = allPixG[i + hw, j + wi];
                            new_gx += gx[wi + 1, hw + 1] * gc;
                            new_gy += gy[wi + 1, hw + 1] * gc;

                            bc = allPixB[i + hw, j + wi];
                            new_bx += gx[wi + 1, hw + 1] * bc;
                            new_by += gy[wi + 1, hw + 1] * bc;
                        }
                    }
                    if (new_rx * new_rx + new_ry * new_ry > limit || new_gx * new_gx + new_gy * new_gy > limit || new_bx * new_bx + new_by * new_by > limit)
                        bb.SetPixel(i, j, Color.Black);
                    //bb.SetPixel (i, j, Color.FromArgb(allPixR[i,j],allPixG[i,j],allPixB[i,j]));
                    else
                        bb.SetPixel(i, j, Color.White);
                }
            }
            form.ConvertImg_box.Image = bb;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
