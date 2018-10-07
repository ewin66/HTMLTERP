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
    public partial class frmFlowerTypeContol : frmAPBaseUIForm
    {
        public frmFlowerTypeContol()
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
            //
            if (txtCode.Text.Trim() !="")
            {
                tempStr += " AND Code LIKE" + SysString.ToDBString("%"+txtCode.Text.Trim()+"%"); 
            }
            if (txtName.Text.Trim() != "")
            {
                tempStr += " AND Name LIKE" + SysString.ToDBString("%" + txtName.Text.Trim() + "%");
            }

            //tempStr += " ORDER BY Code DESC ";
            
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            FlowerTypeContolRule rule = new FlowerTypeContolRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FlowerTypeContolRule rule = new FlowerTypeContolRule();
            FlowerTypeContol entity = EntityGet();
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
            this.HTDataTableName = "Data_FlowerTypeContol";
            this.HTDataList = gridView1;

            ///���ذ�ť
            this.btnSubmitCancelVisible = false;
            this.btnSubmitVisible = false;
            this.btnUpdateVisible = false;
            this.btnDeleteVisible = false;
            //txtQRecordDateS.DateTime = DateTime.Now.AddMonths(-1);
            //txtQRecordDateE.DateTime = DateTime.Now.Date;
            //Common.BindCompanyType(drpQCompanyTypeID, true);//�󶨹�˾��
            //Common.BindOPID(drpQRecordOPID, true);//ҵ��Ա
            //txtCode_EditValueChanged(null,null);


            //btnPrintVisible = true;
        }

        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FlowerTypeContol EntityGet()
        {
            FlowerTypeContol entity = new FlowerTypeContol();
            entity.ID = HTDataID;      
            return entity;
        }
        #endregion
        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void txtCode_EditValueChanged(object sender, EventArgs e)
        //{
        //    GetCondtion();
        //    BindGrid();
        //}

        //private void txtQItemCode_EditValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtQItemName.Text = "";
        //        txtQItemStd.Text = "";
        //        //txtQItemModel.Text = "";
        //        string sql = "SELECT ItemName,ItemStd,ItemAttnCode FROM Data_Item WHERE 1=1 AND ItemCode=" + SysString.ToDBString(txtQItemCode.Text.Trim());
        //        DataTable dt = SysUtils.Fill(sql);
        //        if (dt.Rows.Count != 0)
        //        {
        //            txtQItemName.Text = dt.Rows[0]["ItemName"].ToString();
        //            txtQItemStd.Text = dt.Rows[0]["ItemStd"].ToString();
        //            //txtQItemModel.Text = dt.Rows[0]["ItemModel"].ToString();
        //        }
        //        txtCode_EditValueChanged(null, null);
        //    }
        //    catch (Exception E)
        //    {
        //        ShowMessage(E.Message);
        //    }
        //}
    }
}