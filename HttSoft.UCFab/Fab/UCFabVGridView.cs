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
    /// ���ܣ��鿴�뵥GridViewģʽ
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-31
    /// </summary>
    public partial class UCFabVGridView : UCFabBaseViewCtl
    {
        public UCFabVGridView()
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
            if (UCQtyConvertMode)
            {
                gridView1.Columns["InputQty"].Visible = true;
                gridView1.Columns["InputQty"].Caption = "ת������("+UCQtyConvertModeInputUnit+")";
                //gridView1.Columns["InputQty"].VisibleIndex = 3;
            }
            else
            {
                //gridView1.Columns["InputQty"].VisibleIndex = -1;
                gridView1.Columns["InputQty"].Visible = false;
            }

            if (UCColumnISNHide)//�������������
            {
                gridView1.Columns["BoxNo"].Visible = false;
            }
            BindGrid();
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
                //gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
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


        #endregion
    }
}
