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
    /// ���ܣ����������뵥GridViewģʽ
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-28
    /// </summary>
    public partial class UCFabLGridView : UCFabBaseLoadCtl
    {
        public UCFabLGridView()
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

        #region ����
      



        /// <summary>
        /// ��ȡѡ�������Դ
        /// </summary>
        public DataTable UCSelectDataSource
        {
            get
            {
                DataTable outdt = UCDataSource.Clone();

                DataRow[] drA = UCDataSource.Select("SelectFlag=1");//Ѱ��ѡ��Ĵ���
                for (int i = 0; i < drA.Length; i++)
                {
                    DataRow outdr = outdt.NewRow();
                    for (int j = 0; j < outdt.Columns.Count; j++)//ѭ������
                    {
                        outdr[j] = drA[i][j];
                    }
                }
                return outdt;
            }
        }
        #endregion

        #region �ⲿ���÷���


        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public override void UCAct()
        {
            BindGrid();
            if (UCAllowKPFlag)
            {
                this.gridView1.GridControl.ContextMenuStrip = cMenuLoadFab;
            }
        }

        /// <summary>
        /// ȫѡ
        /// </summary>
        public override void UCSelectAll()
        {
            foreach (DataRow dr in UCDataSource.Rows)
            {
                dr["SelectFlag"] = 1;
            }
            
        }

        /// <summary>
        /// ��ѡ
        /// </summary>
        public override void UCSelectFan()
        {
            foreach (DataRow dr in UCDataSource.Rows)
            {
                if (SysConvert.ToInt32(dr["SelectFlag"]) == 1)
                {
                    dr["SelectFlag"] = 0;
                }
                else
                {
                    dr["SelectFlag"] = 1;
                }
            }
        }


        /// <summary>
        /// ȡ��һ��ѡ��ⲿ����
        /// </summary>
        /// <param name="p_ISN"></param>
        public override void UCCancelOne(string p_ISN)
        {
            DataRow[] drA = UCDataSource.Select("BoxNo="+SysString.ToDBString(p_ISN));
            if (drA.Length == 1)
            {
                drA[0]["SelectFlag"] = 0;
            }
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
        private void UCFabLGridView_Load(object sender, EventArgs e)
        {
            try
            {
                gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;

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
                int selectFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "SelectFlag"));
                if (selectFlag == 1)//ѡ��
                {
                    e.Appearance.BackColor = UCSelectColor;
                }
                else//δѡ
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

                if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)//��ס��Shift����
                {
                    if (UCCurrnetFocusIndex != -1)//ǰһ�۽��к��Ѵ���
                    {
                        for (int i = UCCurrnetFocusIndex + 1; i < gridView1.FocusedRowHandle; i++)//��ֹ��ѭ������
                        {
                            UCDataSource.Rows[i]["SelectFlag"] = UCDataSource.Rows[gridView1.FocusedRowHandle]["SelectFlag"];
                        }
                    }
                }

                UCCurrnetFocusIndex = gridView1.FocusedRowHandle;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region ��ƥ����
        /// <summary>
        /// ��ƥ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmiLoadFabKP_Click(object sender, EventArgs e)
        {
            try
            {
                UCKP(SysConvert.ToString(cmiLoadFabKP.Tag));
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// �Ҽ��˵���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMenuLoadFab_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                string ucisn = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "BoxNo"));
                if (ucisn != string.Empty)
                {
                    cmiLoadFabKP.Tag = ucisn;
                }
                //Control ctl = (sender as ContextMenuStrip).SourceControl;
                //if (ctl is UCFabLTileSimple)
                //{
                //    cmiLoadFabKP.Tag = ((UCFabLTileSimple)ctl).UCISN;
                //}
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void gridControlDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
