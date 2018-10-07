using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

/**
 * 陈加海
 * 2014-05-04
 * 类似于QQ屏幕截图效果
 * ***/

namespace HttSoft.UCFab
{
    public partial class UCScreenBody : Form
    {
        public UCScreenBody()
        {
            InitializeComponent();
        }

        private Graphics MainPainter;  //主画笔
        private Pen pen;               //就是笔咯
        private bool isDowned;         //判断鼠标是否按下
        private bool RectReady;         //矩形是否绘制完成
        private Image baseImage;       //基本图形(原来的画面)
        private Rectangle Rect;        //就是要保存的矩形
        private Point downPoint;        //鼠标按下的点
        int tmpx;
        int tmpy;

        public Image JQImage;

        /// <summary>
        /// 异常执行操作
        /// </summary>
        void ExceptionAct()
        {
            this.Close();
            
        }

         /// <summary>
        /// 鼠标双击保存截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenBody_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (((MouseEventArgs)e).Button == MouseButtons.Left && Rect.Contains(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y))
                {
                    Image memory = new Bitmap(Rect.Width, Rect.Height);
                    Graphics g = Graphics.FromImage(memory);
                    g.CopyFromScreen(Rect.X + 1, Rect.Y + 1, 0, 0, Rect.Size);
                    JQImage = memory;
                    this.Close();
                    /*保存代码备份
                    SaveFileDialog savafil = new SaveFileDialog();
                    savafil.FileName = DateTime.Now.ToString("yyyyMMddhhmmss");//用时间创建图片名称
                    savafil.Filter = "Image Files(*.JPG;*.GIF)|*.JPG;*.GIF|All files(*.*)|*.*";
                    if (savafil.ShowDialog() == DialogResult.OK)
                    {
                        Image memory = new Bitmap(Rect.Width, Rect.Height);
                        Graphics g = Graphics.FromImage(memory);
                        g.CopyFromScreen(Rect.X + 1, Rect.Y + 1, 0, 0, Rect.Size);
                        Clipboard.SetImage(memory);
                        memory.Save(savafil.FileName);
                        this.Close();
                  }
                     */
                }
            }
            catch
            {
                ExceptionAct();
            }
        }
        /// <summary>
        /// 按下鼠标产生的特效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenBody_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDowned = true;

                    if (RectReady == false)
                    {
                        Rect.X = e.X;
                        Rect.Y = e.Y;
                        downPoint = new Point(e.X, e.Y);
                    }
                    if (RectReady == true)
                    {
                        tmpx = e.X;
                        tmpy = e.Y;
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if (RectReady != true)
                    {
                        this.Close();
                        return;
                    }
                    MainPainter.DrawImage(baseImage, 0, 0);
                    RectReady = false;
                }
            }
            catch
            {
                ExceptionAct();
            }

        }
        /// <summary>
        /// 当鼠标松开后！
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenBody_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDowned = false;
                    RectReady = true;
                }
            }
            catch
            {
                ExceptionAct();
            }

        }
        /// <summary>
        /// 当鼠标移动时候，记录坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenBody_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {

                if (RectReady == false)
                {
                    if (isDowned == true)
                    {
                        Image New = DrawScreen((Image)baseImage.Clone(), e.X, e.Y);
                        MainPainter.DrawImage(New, 0, 0);
                        New.Dispose();
                    }
                }
                if (RectReady == true)
                {
                    if (Rect.Contains(e.X, e.Y))
                    {
                        //this.Cursor = Cursors.Hand;
                        if (isDowned == true)
                        {
                            //和上一次的位置比较获取偏移量
                            Rect.X = Rect.X + e.X - tmpx;
                            Rect.Y = Rect.Y + e.Y - tmpy;
                            //记录现在的位置
                            tmpx = e.X;
                            tmpy = e.Y;
                            MoveRect((Image)baseImage.Clone(), Rect);
                        }
                    }
                }
            }
            catch
            {
                ExceptionAct();
            }
        }
        /// <summary>
        /// 当页面加载时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenBody_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                MainPainter = this.CreateGraphics();
                pen = new Pen(Brushes.Blue);
                isDowned = false;
                baseImage = this.BackgroundImage;
                Rect = new Rectangle();
                RectReady = false;
            }
            catch
            {
                ExceptionAct();
            }

        }
        /// <summary>
        /// 根据坐标来记录截屏
        /// </summary>
        /// <param name="Painter"></param>
        /// <param name="Mouse_x"></param>
        /// <param name="Mouse_y"></param>
        private void DrawRect(Graphics Painter, int Mouse_x, int Mouse_y)
        {
            int width = 0;
            int heigth = 0;
            if (Mouse_y < Rect.Y)
            {
                Rect.Y = Mouse_y;
                heigth = downPoint.Y - Mouse_y;
            }
            else
            {
                heigth = Mouse_y - downPoint.Y;
            }
            if (Mouse_x < Rect.X)
            {
                Rect.X = Mouse_x;
                width = downPoint.X - Mouse_x;
            }
            else
            {
                width = Mouse_x - downPoint.X;
            }
            Rect.Size = new Size(width, heigth);
            Painter.DrawRectangle(pen, Rect);
        }

        private Image DrawScreen(Image back, int Mouse_x, int Mouse_y)
        {
            Graphics Painter = Graphics.FromImage(back);
            DrawRect(Painter, Mouse_x, Mouse_y);
            return back;
        }
        private void MoveRect(Image image, Rectangle Rect)
        {
            Graphics Painter = Graphics.FromImage(image);
            Painter.DrawRectangle(pen, Rect.X, Rect.Y, Rect.Width, Rect.Height);

            //DrawRects(Painter);

            MainPainter.DrawImage(image, 0, 0);
            image.Dispose();
        }

        private void ScreenBody_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch
            {
                ExceptionAct();
            }
 
        }

        private void ScreenBody_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Image memory = new Bitmap(Rect.Width, Rect.Height);
                Graphics g = Graphics.FromImage(memory);
                g.CopyFromScreen(Rect.X + 1, Rect.Y + 1, 0, 0, Rect.Size);
                JQImage = memory;
                this.Close();
            }
            catch
            {
                ExceptionAct();
            }
        }
   
    }
}