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
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ�����ⱨ��
    /// </summary>
    public partial class frmInOutWHRpt : frmAPBaseUIRpt
    {
        public frmInOutWHRpt()
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
            if (SysConvert.ToString(drpQWHID.EditValue) != "")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }
           
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
           
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }
            if (txtQItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            }
            if (txtQItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }
            if (txtQColorNum.Text.Trim() != "")
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtQColorNum.Text.Trim() + "%");
            }
            if (txtQColorName.Text.Trim() != "")
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtQColorName.Text.Trim() + "%");
            }
            if (txtQJarNum.Text.Trim() != "")
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (txtQBatch.Text.Trim() != "")
            {
                tempStr += " AND Batch LIKE " + SysString.ToDBString("%" + txtQBatch.Text.Trim() + "%");
            }
            if (txtQVendorBatch.Text.Trim() != "")
            {
                tempStr += " AND VendorBatch LIKE " + SysString.ToDBString("%" + txtQVendorBatch.Text.Trim() + "%");
            }
            if (txtQFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtQFormNo.Text.Trim() + "%");
            }
            if (chkQFormDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtQFormDateS.DateTime.ToString("yyyy-MM-dd")) + " AND " + SysString.ToDBString(txtQFormDateE.DateTime.ToString("yyyy-MM-dd" + " 23:59:59"));
            }
            //if (chkLocalWH.Checked)//ֻ��Ĵ�Ϊ��Ŀ�
            //{
            //    tempStr += " AND WHID IN( SELECT WHID FROM WH_WH WHERE ISJK = 0) ";
            //}
            //if (drpQWHPosition.Text == "����")
            //{
            //    tempStr += " AND WHID IN( SELECT WHID FROM WH_WH WHERE ISJK = 0) ";
            //}
            //else if (drpQWHPosition.Text == "Ⱦ��")
            //{
            //    tempStr += " AND WHID IN( SELECT WHID FROM WH_WH WHERE ISNULL(ISJK,0) = 1) ";
            //}
            switch (drpQWHFormTypeID.SelectedIndex)
            {
                case 1:
                    //tempStr += " AND WHFormTypeID=1";
                    tempStr += " AND SubType IN(SELECT Code FROM Enum_FormList WHERE FormNM LIKE '%���'  AND ParentID<>9)";//���
                    break;
                case 2:
                    tempStr += " AND SubType IN(SELECT Code FROM Enum_FormList WHERE FormNM LIKE '%����')";//����
                    break;
                case 3:
                    tempStr += " AND SubType IN(SELECT Code FROM Enum_FormList WHERE FormNM LIKE '%�ڳ����')";//�ڳ����
                    break;
                case 4:
                    tempStr += " AND SubType IN(SELECT Code FROM Enum_FormList WHERE FormNM LIKE '%�ƿ�')";//�ƿ�
                    break;
                case 5:
                    tempStr += " AND SubType IN(SELECT Code FROM Enum_FormList WHERE FormNM LIKE '%�̵�' )";//�̵�
                    break;
            }
            switch (drpQSubmitFlagType.SelectedIndex)
            {
                case 1:
                    tempStr += " AND isnull(SubmitFlag,0)=1";
                    break;
                case 2:
                    tempStr += " AND isnull(SubmitFlag,0)=0";
                    break;
            }

            switch (drpQDelFlagType.SelectedIndex)
            {
                case 1:
                    tempStr += " AND isnull(DelFlag,0)=0";
                    break;
                case 2:
                    tempStr += " AND isnull(DelFlag,0)=1";
                    break;
            }


            tempStr += Common.GetWHRightCondition();

            //switch (this.FormListAID)//�ж���ԭ�ϻ��Ǹ���/ItemTypeID 1ԭ�� 2���� 3���� 4 ������ 5 Ŀ¼ 6 ɫ�� 7 ֻƬ 
            //{
            //    case 0://ԭ��
            //        tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=1)";
            //        break;
            //    case 1://����
            //        tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=2)";
            //        break;
            //    case 2://����
            //        tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=3)";
            //        break;
            //    case 3://������
            //        tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=4)";
            //        break;
            //    default:
            //        tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=1)";
            //        break;
            //}

            tempStr += " ORDER BY FormDate DESC ";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            IOFormDtsRule rule = new IOFormDtsRule();
            gridView1.GridControl.DataSource = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
            gridView1.GridControl.Show();
        }

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;

            txtQFormDateS.DateTime = DateTime.Now.AddDays(0 - ParamConfig.QueryDayNum);
            txtQFormDateE.DateTime = DateTime.Now.Date;

            //Common.BindVendor(drpQVendorID, "WH_IOForm", "VendorID", true);
            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.���� }, true);//�ͻ� 

         
            Common.BindAllWH(drpQWHID,true);


            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.���� }, true);//�ͻ� 
            Common.BindCLS(drpQWHPosition, "WH_WH", "WHID",false);//�󶨲ֿ�λ��

            drpQWHPosition.EditValue = "����";

            switch (this.FormListAID)//�ж���ԭ�ϻ��Ǹ���/ItemTypeID 1ԭ�� 2���� 3���� 4 ������ 5 Ŀ¼ 6 ɫ�� 7 ֻƬ 
            {
                case 0://ɴ��
                    new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.���� }, true, true);
                    break;
                //case 1://����
                //    new ItemProcLookUp(drpQItemCode, new int[] {(int)EnumItemType.���� }, true, true);
                //    break;
                //case 2://����
                //    new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.���� }, true, true);
                //    break;
                //case 3://������
                //    new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.ҩ�� }, true, true);
                //    break;
                //default:
                //    new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.ɴ��, (int)EnumItemType.����, (int)EnumItemType.����, (int)EnumItemType.ҩ�� }, true, true);
                //    break;
            }

            txtQFormNo_EditValueChanged(null,null);
            //InOutWHStatus.ColorIniTextBox(groupControlSOColor);
        }

        #endregion


        #region �����¼�
        /// <summary>
        /// ��ɫ�仯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                //int WHFormTypeID = SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "WHFormTypeID"));
                //e.Appearance.BackColor = InOutWHStatus.GetGridRowBackColor(WHFormTypeID);
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
        private void txtQFormNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetCondtion();
                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
       
        #endregion

        private void txtQItemCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtQItemName.Text = "";
                txtQItemStd.Text = "";
                txtQItemModel.Text = "";
                string sql = "SELECT ItemName,ItemStd,ItemAttnCode,ItemModel FROM Data_Item WHERE 1=1 AND ItemCode=" + SysString.ToDBString(txtQItemCode.Text.Trim());
                DataTable dt = SysUtils.Fill(sql);
                if (dt.Rows.Count != 0)
                {
                    txtQItemName.Text = dt.Rows[0]["ItemName"].ToString();
                    txtQItemStd.Text = dt.Rows[0]["ItemStd"].ToString();
                    txtQItemModel.Text = dt.Rows[0]["ItemModel"].ToString();
                }
                txtQFormNo_EditValueChanged(null, null);
            }
            catch (Exception E)
            {
                ShowMessage(E.Message);
            }
        }




    }
}