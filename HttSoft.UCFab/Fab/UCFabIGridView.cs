using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HttSoft.UCFab
{
    /// <summary>
    /// ���ܣ�¼���뵥 �б�ģʽ
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-29
    /// </summary>
    public partial class UCFabIGridView : UCFabBaseInputCtl
    {
        public UCFabIGridView()
        {
            InitializeComponent();
        }

        #region ��ʱ��̬�����������ƶ���ȫ�ֱ��������������ݿ���
        static Color UCBackColor = Color.FromArgb(255, 255, 255);//Ĭ��ɫϵ 255, 255, 192
        static Color UCBackColor2 = Color.FromArgb(255, 255, 255);//Ĭ��ɫϵ 255, 255, 128
        static Color UCBorderColor = Color.FromArgb(192, 255, 255);//Ĭ��ɫϵ

        static Color UCBackColorS = Color.FromArgb(255, 255, 192);//ż����ɫϵ 192, 255, 192
        static Color UCBackColorS2 = Color.AliceBlue;//ż����ɫϵ 128, 255, 128

        static Color UCSelectColor = Color.FromArgb(255, 192, 255);//ѡ��ɫϵ
        #endregion

        #region �ⲿ���÷���


        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public override void UCAct()
        {
            BindGrid();
        }

        /// <summary>
        /// ִ�����¸�ֵ����������¼��ʱ
        /// </summary>
        public override void UCBind()
        {
            BindGrid();
        }

        /// <summary>
        /// ���õ�ǰ�۽��к�
        /// </summary>
        public override void UCSetCurrectIndex()
        {
            UCCurrnetFocusIndex = gridView1.FocusedRowHandle;
        }
        #endregion

        #region �ڲ�����
        /// <summary>
        /// ��Grid
        /// </summary>
        void BindGrid()
        {
            UCFabCommon.AddDtRow(UCDataSource, UCInputCount);
            gridView1.GridControl.DataSource = UCDataSource;
            gridView1.GridControl.Show();
        }
        #endregion

        #region �ؼ������¼�
        /// <summary>
        /// �ؼ������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCFabIGridView_Load(object sender, EventArgs e)
        {
            try
            {
                UCFabCommon.GridViewRowIndexBind(gridView1);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �����¼�
        /// <summary>
        /// �б���ɫ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {

                if (e.RowHandle % 2 == 1)
                {
                    e.Appearance.BackColor = UCBackColorS2;
                }
                else
                {
                    e.Appearance.BackColor = UCBackColor2;
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
        #endregion

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //this.BaseFocusLabel.Focus();
                    
                    SendKeys.Send("{DOWN}");
                    SendKeys.Send("{Enter}");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtSubSeq_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //this.BaseFocusLabel.Focus();

                    SendKeys.Send("{DOWN}");
                    SendKeys.Send("{Enter}");
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       
    }
}
