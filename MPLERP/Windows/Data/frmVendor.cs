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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;
using DevExpress.XtraGrid.Views.Grid;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ��ͻ�����
    /// ���ߣ�����ǿ
    /// ���ڣ�2012-04-18
    /// ����������
    /// </summary>
    public partial class frmVendor : frmAPBaseUIForm
    {
        public frmVendor()
        {
            InitializeComponent();
        }


        #region �Զ����鷽������[��Ҫ�޸�]

        /// <summary>
        /// ��ѯ����
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtVendorName.Text.Trim() != "")//��ѯ��
            {
                tempStr = " AND VendorName LIKE " + SysString.ToDBString("%" + txtVendorName.Text.Trim() + "%");
            }
            if (txtVendorID.Text.Trim() != "")
            {
                tempStr = " AND VendorID LIKE " + SysString.ToDBString("%" + txtVendorID.Text.Trim() + "%");
            }
            if (txtTelPhone.Text.Trim() != "")
            {
                tempStr = " AND Tel LIKE " + SysString.ToDBString("%" + txtTelPhone.Text.Trim() + "%");
            }
            if (txtTelPerson.Text.Trim() != "")
            {
                tempStr = " AND Contact LIKE " + SysString.ToDBString("%" + txtTelPerson.Text.Trim() + "%");
            }
            if (txtArea.Text.Trim() != "")
            {
                tempStr = " AND Area LIKE " + SysString.ToDBString("%" + txtArea.Text.Trim() + "%");
            }

            tempStr += " AND ( VendorTypeID IN(0," + SysString.ToDBString(FormListAID) + ") OR";
            tempStr += " VendorID IN(SELECT VendorID FROM Data_VendorTypeDts WHERE VendorTypeID IN(0," + SysString.ToDBString(FormListAID) + "))";
            tempStr += ")";
            //if (FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.���2)&&!FParamConfig.LoginHTFlag)
            //{
            //    tempStr+="AND InSaleOP="+SysString.ToDBString(FParamConfig.LoginID);
            //}

            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��0))//��ѯ���пͻ���Ϣ
            {
                if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//���۶���ҵ��Աֻ�鿴�Լ��ĵĶ���
                {
                    tempStr += " AND InSaleOP IN(" + WCommon.GetStructureMemberOPStr() + ")";
                }
            }


            tempStr += " ORDER BY ID";
            HTDataConditionStr = tempStr;
        }

        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            VendorRule rule = new VendorRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("AddFlag", "0 AddFlag"));
            //if (FormListAID == (int)EnumVendorType.����)
            //{
            //    SetGrid(dt);
            //}
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
            gridViewRowChanged1(gridView1);
        }

        private void SetGrid(DataTable dt)
        {
            //foreach (DataRow dr in dt.Rows)
            //{
            //    string sql = "SELECT * FROM Data_VendorAdd WHERE VendorID="+SysString.ToDBString(dr["VendorID"].ToString());
            //    if (SysUtils.Fill(sql).Rows.Count > 0)
            //    {
            //        dr["AddFlag"] = 1;
            //    }
            //    else
            //    {
            //        dr["AddFlag"] = 0;
            //    }
            //}
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            VendorRule rule = new VendorRule();
            Vendor entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Vendor";
            this.HTDataList = gridView1;
            //if (FormListAID == (int)EnumVendorType.����)
            //{
            //    this.ToolBarItemAdd(32, "btnAddVendor", "����������Ϣ", true, btnAddVendor_Click, eShortcut.F9);
            //}
            Common.BindCLS(drpVendorLevel, "Data_Vendor", "VendorLevel", true);
            btnQuery_Click(null, null);

            this.ToolBarItemAdd(32, "btnDealSaleOPID", "�������ҵ��Ա", true, btnDealSaleOPID_Click);
            this.gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);
            this.ToolBarItemAdd(32, "btnDeal", "��ȡ�ֶ�", true, btnDeal_Click);
        }

        public void btnDeal_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }
        /// <summary>
        /// ����ͻ�����ҵ��Ա
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDealSaleOPID_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    int p_ID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));

                    Vendor entity = new Vendor();
                    entity.ID = p_ID;
                    entity.SelectByID();

                    if (entity.InSaleOP != "")
                    {
                        string sql = "Select * from Data_VendorSaleOP where OPID=" + SysString.ToDBString(entity.InSaleOP);
                        sql += " AND MainID=" + entity.ID;
                        DataTable dt = SysUtils.Fill(sql);
                        if (dt.Rows.Count == 0)
                        {
                            VendorSaleOPRule rule = new VendorSaleOPRule();
                            VendorSaleOP entityOP = new VendorSaleOP();
                            entityOP.MainID = entity.ID;
                            entityOP.OPID = entity.InSaleOP;
                            entityOP.Remark = "�Զ����";
                            rule.RAdd(entityOP);
                        }
                    }
                }

                this.ShowInfoMessage("������ɣ�");

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }


        /// <summary>
        /// ����������Ϣ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            try
            {

                frmVendorAdd frm = new frmVendorAdd();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(580, 280);
                frm.ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frm.VendorID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VendorID"));
                frm.ShowDialog();
                txtName_EditValueChanged(null, null);
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { frm.ID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        public override void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.���3))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }
                this.ToExcelSelectColumn(gridView1);
                FCommon.AddDBLog(this.Text, "�����б�", "������" + FParamConfig.LoginName, "����ʱ��:" + DateTime.Now.Date.ToShortDateString());
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private Vendor EntityGet()
        {
            Vendor entity = new Vendor();
            entity.ID = HTDataID;
            return entity;
        }

        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_EditValueChanged(object sender, EventArgs e)
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
        public override void gridViewRowChanged1(object sender)
        {
            base.gridViewRowChanged1(sender);
            //this.BaseFocusLabel.Focus();
            GridView view = sender as GridView;
            int id = SysConvert.ToInt32(view.GetFocusedRowCellValue("ID"));
            string sql = "SELECT * FROM Data_VendorAddress WHERE MainID =" + id;
            DataTable dt = SysUtils.Fill(sql);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
            //gridView1.Focus();
        }
        #endregion


    }
}