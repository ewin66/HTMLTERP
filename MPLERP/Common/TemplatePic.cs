using System;
using System.Collections.Generic;
using System.Text;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using System.Drawing;
using System.Windows.Forms;

namespace MLTERP
{
    class TemplatePic
    {

        private static string TemplateFileRoute = Application.StartupPath + @"\Templete\";//ģ���ļ�·��
        private static string TempFileRoute = Application.StartupPath + @"\Temp\";//������ʱ�ļ�·��

        #region �����ļ�����

        /// <summary>
        /// ��õ����ļ�����
        /// </summary>
        /// <param name="p_FilePre">�ļ�ǰ׺</param>
        /// <returns>�ļ�����(��·��)</returns>
        public static string GetTempFileName(string p_FilePre, string p_Exe)
        {
            string outstr = string.Empty;
            const int sindex = 10, eindex = 30, mindex = 21;//sindex=10,eindex=15,mindex=12;
            SysFile.CreateDDirectory(TempFileRoute);//û���ҵ��򴴽���ʱ�ļ���·��
            string FileName = string.Empty, DleteFileName = string.Empty;
            int i = 0;
            for (i = sindex; i < eindex; i++)
            {
                FileName = TempFileRoute + p_FilePre + i.ToString() + "." + p_Exe;
                if (!SysFile.CheckFileExit(FileName))//�ҵ�������
                {
                    break;
                }
            }
            if (i == mindex)//��������м��ߣ�ɾ���м��ߺ�����ļ�
            {
                for (int j = mindex + 1; j < eindex; j++)
                {
                    DleteFileName = TempFileRoute + p_FilePre + j.ToString() + "." + p_Exe;
                    SysFile.DeleteFile(DleteFileName);
                }
            }
            if (i == eindex)//�������ĩβ��ɾ���м���ǰ����ļ�
            {
                for (int j = sindex; j <= mindex; j++)
                {
                    DleteFileName = TempFileRoute + p_FilePre + j.ToString() + "." + p_Exe;
                    SysFile.DeleteFile(DleteFileName);
                }
            }
            outstr = FileName;
            return outstr;

        }

        #endregion

        #region �����ļ�
        public static string SaveImage(byte[] p_ImgData, string p_Exe)
        {
            string outstr = string.Empty;

            string filename = GetTempFileName("pic", p_Exe);//��ʱ�ļ�
            if (filename == "")
            {
                SysFile.WriteFrameworkLog("������ʱͼƬ����ʧ�ܣ������µ���");
                return outstr;
            }
            try
            {
                if (p_ImgData.Length != 0)//��ͼƬ����
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(p_ImgData);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    image.Save(filename);
                }
            }
            catch
            {
                return outstr;
            }
            return filename;
        }
        #endregion

        #region ѹ��ͼƬ
        /// <summary>
        /// ѹ��ͼƬ
        /// </summary>
        public static Image ZipImage(Image p_Img)
        {
            Image img = p_Img;
            Bitmap bmp = new Bitmap(p_Img);
            string fn = TemplatePic.GetTempFileName("SP", "1");
            bmp.Save(fn, System.Drawing.Imaging.ImageFormat.Jpeg);
            Image tempimg = Image.FromFile(fn);
            if (((byte[])ImageToByte(p_Img)).Length >= ((byte[])ImageToByte(tempimg)).Length)//ȷ����С�˲��滻
            {
                img = tempimg;
            }
            return img;
        }

        /// <summary>
        /// ͼƬ����
        /// </summary>
        /// <param name="p_Img"></param>
        /// <param name="p_Bigger"></param>
        /// <returns></returns>
        public static Image ZoomImage(Image p_Img, decimal bl)
        {
            Image img = ZoomPic(new Bitmap(p_Img), bl);
            return img;
        }

        /// <summary>  
        /// ����ͼƬ  
        /// </summary>  
        public static Bitmap ZoomPic(Bitmap objPic, decimal bl)
        {

            System.Drawing.Bitmap objNewPic;
            try
            {
                int wi = Convert.ToInt32(Decimal.Round(objPic.Width * bl, 0));
                int he = Convert.ToInt32(Decimal.Round(objPic.Height * bl, 0));
                objNewPic = new System.Drawing.Bitmap(objPic, wi, he);

            }
            catch (Exception exp) { throw exp; }
            finally
            {
                objPic = null;
            }
            return objNewPic;
        }
        #endregion

        #region ͼƬ�ֽ��໥ת��
        public static byte[] ImageToByte(Image img)
        {
            byte[] byt = null;
            ImageConverter imgCvt = new ImageConverter();
            object obj = imgCvt.ConvertTo(img, typeof(byte[]));
            byt = (byte[])obj;
            return byt;
        }

        //ByteToImage(byte[] byt),����DataReader�ڔ��������xȡbyte[]
        public static Image ByteToImage(byte[] bytImage)
        {
            Image img = null;
            if (bytImage.Length < 100)
            {
                return img;
            }
            else
            {
                ImageConverter imgCvt = new ImageConverter();

                object obj = imgCvt.ConvertFrom(bytImage);
                img = (Image)obj;
                return img;
            }
        }
        #endregion

        #region �µķ���

        /// <summary>
        /// ͼƬ����
        /// </summary>
        /// <param name="p_Img"></param>
        /// <param name="p_Bigger"></param>
        /// <returns></returns>
        public static Image ZoomImage2(Image p_Img, decimal bl)
        {
            Image img = ZoomPic2(new Bitmap(p_Img), bl);
            return img;
        }


        /// <summary>  
        /// ����ͼƬ  
        /// </summary>  
        public static Bitmap ZoomPic2(Bitmap objPic, decimal bl)
        {

            System.Drawing.Bitmap objNewPic;
            try
            {
                int wi = Convert.ToInt32(Decimal.Round(bl * objPic.Width / objPic.Height, 0));

                int he = Convert.ToInt32(Decimal.Round(bl, 0)); //Convert.ToInt32(Decimal.Round(bl * objPic.Height / objPic.Width * bl, 0));
                objNewPic = new System.Drawing.Bitmap(objPic, wi, he);

            }
            catch (Exception exp) { throw exp; }
            finally
            {
                objPic = null;
            }
            return objNewPic;
        }
        #endregion
    }
}
