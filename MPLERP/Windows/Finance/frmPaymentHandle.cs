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
using DevComponents.DotNetBar;

namespace MLTERP
{
    public partial class frmPaymentHandle : frmAPBaseUIForm
    {
        public frmPaymentHandle()
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
           
            if (txtSaleOPName.Text.Trim() != string.Empty)
            {
                tempStr += " AND SaleOPName LIKE " + SysString.ToDBString("%" + txtSaleOPName.Text.Trim() + "%");
            }
            if (txtVendorAttn.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorAttn LIKE " + SysString.ToDBString("%" + txtVendorAttn.Text.Trim() + "%");
            }
            if (chkFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtFormDateS.DateTime) + " AND " + SysString.ToDBString(txtFormDateE.DateTime);
            }

            //if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            //{
            //    tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            //}


            if (checkSef.Checked && !FParamConfig.LoginHTFlag)
            {
                tempStr += " AND MakeOPID=" + SysString.ToDBString(FParamConfig.LoginName);
            }
            tempStr += " ORDER BY FormNo Desc";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            PaymentHandleRule rule = new PaymentHandleRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            PaymentHandleRule rule = new PaymentHandleRule();
            PaymentHandle entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_PaymentHandle";
            this.HTDataList = gridView1;
            txtFormDateS.DateTime = DateTime.Now.AddDays(-30).Date;
            txtFormDateE.DateTime = DateTime.Now.Date;
            this.ToolBarItemAdd(26, "btnLoad", "����", true, btnLoad_Click);
        }

        #endregion
        public override void btnLoad_Click(object sender, EventArgs e)
        {
            if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��0))
            {
                this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                return;
            }
            ButtonItem btn = (ButtonItem)sender;
            PaymentHandleRule rule = new PaymentHandleRule();
            PaymentHandle entity = new PaymentHandle();
            entity.ID = HTDataID;
            entity.SelectByID();
            if (btn.Text == "��������")
            {
                if (entity.ReadFlag == 0)
                {
                    this.ShowMessage("�õ��ݻ�δ�ģ����賷��");
                    return;
                }
                entity.ReadFlag = 0;
                rule.RUpdate(entity);
            }
            if (btn.Text == "����")
            {
                if (entity.ReadFlag == 1)
                {
                    this.ShowMessage("�õ������ģ���������");
                    return;
                }
                entity.ReadFlag = 1;
                rule.RUpdate(entity);
            }
            btnQuery_Click(null, null);
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { entity.ID.ToString() });

        }
        public override void gridViewRowChanged1(object sender)
        {
            base.gridViewRowChanged1(sender);
            int ReadFlag = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ReadFlag"));
            if (ReadFlag == 1)
            {
                this.ToolBarItemSet(-1, "btnLoad", "��������", true, 27);
            }
            else
            {
                this.ToolBarItemSet(-1, "btnLoad", "����", true, 26);
            }
        }
        public override void _HTDataDts_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //base._HTDataDts_RowCellStyle(sender, e);
            if (SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "ReadFlag")) == 1)
            {
                e.Appearance.BackColor = Color.Pink;
            }
        }
        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private PaymentHandle EntityGet()
        {
            PaymentHandle entity = new PaymentHandle();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
    }
}