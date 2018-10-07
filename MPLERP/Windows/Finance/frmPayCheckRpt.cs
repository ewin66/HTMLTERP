using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;

using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ��������/δ���˹���
    /// 
    /// </summary>
    public partial class frmPayCheckRpt : frmAPBaseUIRpt
    {
        public frmPayCheckRpt()
        {
            InitializeComponent();
        }

       

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
           
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }

            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtQFormDateS.DateTime) + " AND " + SysString.ToDBString(txtQFormDateE.DateTime);
            }

            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// �Ѷ���
        /// </summary>
        public override  void BindGrid()
        {
            string sql = "select * from UV1_WH_IOFormDts where 1=1";
            sql += " AND ISNULL(SubmitFlag,0)=1";
            sql += " AND DZFlag=1";
            sql += " AND FormDZFlag<>0";//������������
            sql += " AND FormDZType in(1,2)";// �ӹ����ɹ�����
            sql += HTDataConditionStr;
            DataTable dt = SysUtils.Fill(sql);


            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();


            BindGrid1();
        }

        /// <summary>
        /// δ����
        /// </summary>
        private void BindGrid1()
        {
            string sql = "select * from UV1_WH_IOFormDts where 1=1";
            sql += " AND ISNULL(SubmitFlag,0)=1";
            sql += " AND DZFlag=0";
            sql += " AND FormDZFlag<>0";//������������
            sql += " AND FormDZType in(1,2)";// �ӹ����ɹ�����
            sql += HTDataConditionStr;
            DataTable dt = SysUtils.Fill(sql);


            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }
        
         /// <summary>
        /// ���ö�λ���ݼ�״̬
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOFormDts";
            this.HTDataList = gridView1;//�б��ʽ����
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[1] { gridView2 };//�б��ʽ����
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.���� }, true);
            new VendorProc(drpVendorID);
            txtQFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQFormDateE.DateTime = DateTime.Now.Date;
            btnQuery_Click(null, null);
            
        }
        #endregion


        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

        

        #region ������ط���

        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���ٲ�ѯ(ֵ�ı伴����)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //GetCondtion();
                //BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// ���ٲ�ѯ(�س�������)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GetCondtion();
                    BindGrid();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

//�����б�����д        
        public override void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {

                if (xtraTabControl1.SelectedTabPageIndex == 0)
                {
                    //this.ToExcel(HTDataList);
                    this.ToExcelSelectColumn(gridView1);
                }
                if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    //this.ToExcel(gridView2);
                    this.ToExcelSelectColumn(gridView2);
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