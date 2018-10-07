using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;

using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmItemBuyFollow : frmAPBaseUIForm
    {
        public frmItemBuyFollow()
        {
            InitializeComponent();
        }


        int saveNoLoadCheckDayNum = 0;//δ���رȶ���������ֹ����ʱ�������ϵͳ����
        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (!Common.CheckLookUpEditBlank(drpQVendorID))
            {
                tempStr += " AND ShopID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
         
            if (ChkMakeDate.Checked)
            {
                tempStr += " AND MakeDate BETWEEN " + SysString.ToDBString(txtQMakeDateS.DateTime) + " AND " + SysString.ToDBString(txtQMakeDateE.DateTime);
            }

            if (txtFormNo.Text.Trim() != "")
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if (txtGoodsCode.Text.Trim() != "")
            {
                tempStr += " AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if (txtItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE "+SysString.ToDBString("%"+txtItemName.Text.Trim()+"%");
            }
            if (chkJQ.Checked)
            {
                tempStr += " AND ReqDate BETWEEN " + SysString.ToDBString(txtFactFinishDateS.DateTime)+" AND "+SysString.ToDBString(txtFactFinishDateE.DateTime);
            }
            if (txtOrderFormNo.Text.Trim() != "")
            {
                tempStr += " AND BuyFormNo LIKE "+SysString.ToDBString("%"+txtOrderFormNo.Text.Trim()+"%");
            }
            tempStr += " ORDER BY FormNo DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            ItemBuyFollowRule rule = new ItemBuyFollowRule();
            gridView1.GridControl.DataSource=rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();



            string sql = "SELECT FormNo,ShopID,ReqDate,MakeDate,TotalQty FROM Buy_ItemBuyForm WHERE 1=1";
            sql += " AND FormNo NOT IN (SELECT BuyFormNo FROM Buy_ItemBuyFollow";
            if (saveNoLoadCheckDayNum != 0)
            {
                sql += " WHERE FormDate BETWEEN " + SysString.ToDBString(DateTime.Now.AddDays(0 - saveNoLoadCheckDayNum).ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            sql +=") ";
            if (ChkMakeDate.Checked)
            {
                sql += " AND FormDate BETWEEN " + SysString.ToDBString(txtBuyDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtBuyDateE.DateTime.ToString("yyyy-MM-dd"));
            }
            sql += " AND SubmitFlag=1 ORDER BY FormNo DESC ";
            DataTable dt = SysUtils.Fill(sql);
            gridView2.GridControl.DataSource = dt;
            gridView2.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            ItemBuyFollowRule rule = new ItemBuyFollowRule();
            ItemBuyFollow entity = EntityGet();
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
            ProcessGrid.BindGridColumn(gridView1, this.FormID);//����				
            ProcessGrid.SetGridColumnUI(gridView1, FormListAID, FormListBID);//������UI
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.���� }, true);
            new VendorProc(drpQVendorID);
            this.HTDataTableName = "Buy_ItemBuyFollow";
            this.HTDataList = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2 };
            txtQMakeDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtQMakeDateE.DateTime = DateTime.Now;
            txtBuyDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtBuyDateE.DateTime = DateTime.Now.Date;
            txtFactFinishDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtFactFinishDateE.DateTime = DateTime.Now.Date;

            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.δ�������ݱȶ�����);
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private ItemBuyFollow EntityGet()
        {
            ItemBuyFollow entity = new ItemBuyFollow();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion

      
        #region ���ٲ�ѯ
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
        private void txtMakeOPName_EditValueChanged(object sender, EventArgs e)
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
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_EditValueChanged_1(object sender, EventArgs e)
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

      

     
        


      


    }
}