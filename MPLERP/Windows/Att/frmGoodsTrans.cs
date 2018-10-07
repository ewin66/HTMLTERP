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
    public partial class frmGoodsTrans : frmAPBaseUIForm
    {
        public frmGoodsTrans()
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

            if (chkJSDate.Checked)
            {
                tempStr += " AND JSDate BETWEEN " + SysString.ToDBString(txtJSDateS.DateTime) + " AND " + SysString.ToDBString(txtJSDateE.DateTime);
            }
            if (chkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtMakeDateE.DateTime);
            }
      
            if (SysConvert.ToString(drpShopID.EditValue) != "")
            {
                tempStr += " AND ShopID = " + SysString.ToDBString(SysConvert.ToString(drpShopID.EditValue));
            }
            if (SysConvert.ToString(drpResive.EditValue) != "")
            {
                tempStr += " AND VendorID = " + SysString.ToDBString(SysConvert.ToString(drpResive.EditValue));
            }
            if (SysConvert.ToString(drpTransComID.EditValue) != "")
            {
                tempStr += " AND TransComID = " + SysString.ToDBString(SysConvert.ToString(drpTransComID.EditValue));
            }
            //if (chkJSFlag.Checked)
            //{
            //    tempStr += " AND JSFlag=1";
            //}
            //if (chkNOJSFlag.Checked)
            //{
            //    tempStr += " AND ISNULL(JSFlag,0)=0";
            //}
            //if (chkFHDFlag.Checked)
            //{
            //    tempStr += " AND FHDFlag=1";
            //}
            //if (chkYSFlag.Checked)
            //{
            //    tempStr += " AND YSFlag=1";
            //}
            if (txtSendNo.Text.Trim() != "")
            {
                tempStr += " AND SendNo LIKE "+SysString.ToDBString("%"+txtSendNo.Text.Trim()+"%");
            }
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            GoodsTransRule rule = new GoodsTransRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();

           
        }

       

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            GoodsTransRule rule = new GoodsTransRule();
            GoodsTrans entity = EntityGet();
            rule.RDelete(entity);
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
            this.HTDataTableName = "Att_GoodsTrans";
            this.HTDataList = gridView1;
           // this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2 };
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);
            txtJSDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtJSDateE.DateTime = DateTime.Now.Date;
            txtMakeDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindVendor(drpTransComID, new int[] { (int)EnumVendorType.��ݹ�˾ }, true);
            new VendorProc(drpTransComID);
            Common.BindVendor(drpShopID, new int[] { (int)EnumVendorType.���� }, true);
            new VendorProc(drpShopID);
            Common.BindVendor(drpResive, new int[] { (int)EnumVendorType.�ͻ� }, true);
            new VendorProc(drpResive);
            txtFHDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFHDateE.DateTime = DateTime.Now.Date;


        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private GoodsTrans EntityGet()
        {
            GoodsTrans entity = new GoodsTrans();
            entity.ID = HTDataID;      
            return entity;
        }

        
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
       

        #endregion

        private void chkJSFlag_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if (chkJSFlag.Checked)
                {
                    chkNOJSFlag.Checked = false;
                }
                else
                {
                    chkNOJSFlag.Checked=true;
                }
                txtFormNo_EditValueChanged(null, null);
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void chkNOJSFlag_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                if(chkNOJSFlag.Checked)
                {
                    chkJSFlag.Checked=false;
                }
                else
                {
                    chkJSFlag.Checked=true;
                }
                txtFormNo_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

       

        

       

      
    }
}