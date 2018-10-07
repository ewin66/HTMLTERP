using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;

namespace HttSoft.UCFab
{
    /// <summary>
    /// ���ܣ�ѡ���뵥GridViewģʽ
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-29
    /// </summary>
    public partial class UCFabSGridView : UCFabBaseSelectCtl
    {
        public UCFabSGridView()
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
        /// ȡ��һ��
        /// </summary>
        public override void UCCancelOne(string p_ISN)
        {
            base.UCCancelOne(p_ISN);
        }
        #endregion


        #region �ڲ�����
        void BindGrid()
        {
            gridView1.GridControl.DataSource = UCDataSource;
            gridView1.GridControl.Show();
        }
        #endregion


        #region �����¼�
        private void UCFabSGridView_Load(object sender, EventArgs e)
        {
            try
            {
                gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
                //UCFabCommon.GridViewRowIndexBind(gridView1);
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

        /// <summary>
        /// ����ֵ�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "SelectFlag")
                {
                    UCCancelOne(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "BoxNo")));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ֵ�ı�۽�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkGridSelectFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblFocus.Focus();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion


       

       
    }
}
