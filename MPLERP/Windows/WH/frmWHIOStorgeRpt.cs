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
    /// ���ܣ��շ��汨��
    /// </summary>
    public partial class frmWHIOStorgeRpt : frmAPBaseUIRpt
    {
        public frmWHIOStorgeRpt()
        {
            InitializeComponent();
        }
        #region ȫ�ֱ���

        //int iLKParamSet = 0;//����������
        #endregion

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
            if (SysConvert.ToString(drpQWHTypeID.EditValue) != "")
            {
                tempStr += " AND WHTypeID=" + SysString.ToDBString(SysConvert.ToString(drpQWHTypeID.EditValue));
            }
            if (SysConvert.ToString(drpQVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(SysConvert.ToString(drpQVendorID.EditValue));
            }
            if (txtQSSN.Text.Trim() != "")
            {
                tempStr += " AND SSN LIKE " + SysString.ToDBString("%" + txtQSSN.Text.Trim() + "%");
            }
            if (txtQDSN.Text.Trim() != "")
            {
                tempStr += " AND DSN LIKE " + SysString.ToDBString("%" + txtQDSN.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpQItemCode.EditValue) != "")
            {
                tempStr += " AND ItemCode=" + SysString.ToDBString(SysConvert.ToString(drpQItemCode.EditValue));
            }
            if (txtQItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtQItemName.Text.Trim() + "%");
            }
            if (txtQItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
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
            switch (this.FormListAID)//�ж���ԭ�ϻ��Ǹ���/ItemTypeID 1ԭ�� 2���� 3���� 4 ������ 5 Ŀ¼ 6 ɫ�� 7 ֻƬ 
            {
                case 0://����
                    tempStr += " ";
                    break;
                //case 0://ԭ��
                //    tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=1)";
                //    break;
                //case 1://����
                //    tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=2)";
                //    break;
                //case 2://����
                //    tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=3)";
                //    break;
                //case 3://������
                //    tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=4)";
                //    break;
                //default:
                //    tempStr += " AND WHTypeID IN(SELECT ID FROM Enum_WHType WHERE ItemTypeID=1)";
                //    break;
            }
            //tempStr += " AND FormDate <=" + SysString.ToDBString(DateTime.Now.Date.AddDays(-iLKParamSet).ToString("yyyy-MM-dd"));

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            string sql = " Exec USP2_IOStorge " + SysString.ToDBString(FParamConfig.LoginID);
            sql += "," + SysString.ToDBString(SysConvert.ToString(txtWriteDateS.DateTime.Date));
            sql += "," + SysString.ToDBString(SysConvert.ToString(txtWriteDateE.DateTime.Date));
            sql += "," + SysString.ToDBString(HTDataConditionStr);
            //SystemConfiguration.DBTimeOut = 60;
            SysUtils.ExecuteNonQuery(sql);

            //sql = " Select * from WH_QWHJS where 1=1 ";
            //if (this.txtQBatch.Text.Trim() != "")
            //{
            //    sql += " AND Batch LIKE " + SysString.ToDBString("%" + this.txtQBatch.Text.Trim() + "%");
            //}
            //if (this.txtQVendorBatch.Text.Trim() != "")
            //{
            //    sql += " AND VendorBatch LIKE" + SysString.ToDBString("%" + this.txtQVendorBatch.Text.Trim() + "%");
            //}
            //if (this.txtQColorName.Text.Trim() != "")
            //{
            //    sql += " AND ColorName LIKE" + SysString.ToDBString("%" + this.txtQColorName.Text.Trim() + "%");
            //}
            //if (this.txtQColorNum.Text.Trim() != "")
            //{
            //    sql += " AND ColorNum LIKE" + SysString.ToDBString("%" + this.txtQColorNum.Text.Trim() + "%");
            //}
            //if (this.txtQJarNum.Text.Trim() != "")
            //{
            //    sql += " AND JarNum LIKE" + SysString.ToDBString("%" + this.txtQJarNum.Text.Trim() + "%");
            //}
           
            //if (txtQItemStd.Text.Trim() != string.Empty)
            //{
            //    sql += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtQItemStd.Text.Trim() + "%");
            //}
            //sql += " AND OPID = " + SysString.ToDBString(FParamConfig.LoginID);

            int tempDBTimeOut = SystemConfiguration.DBTimeOut;
            SystemConfiguration.DBTimeOut = 600;//10����
            DataTable  dt = SysUtils.Fill(sql);
            SystemConfiguration.DBTimeOut = tempDBTimeOut;

            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_Storge";
            this.HTDataList = gridView1;

            Common.BindVendor(drpQVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.���� }, true);//�ͻ� 

            Common.BindWHType(drpQWHTypeID, true);
            Common.BindWH(drpQWHID, true);

            switch (this.FormListAID)//�ж���ԭ�ϻ��Ǹ���/ItemTypeID 1ԭ�� 2���� 3���� 4 ������ 5 Ŀ¼ 6 ɫ�� 7 ֻƬ 
            {
                case 0://ԭ��
                    new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.���� }, true, true);
                    break;
                //case 1://����
                //    new ItemProcLookUp(drpQItemCode, new int[] { (int)EnumItemType.���� }, true, true);
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


            txtWriteDateS.DateTime = DateTime.Now.Date.AddDays(0 - 15);
            txtWriteDateE.DateTime = DateTime.Now.Date;

            SetTabIndex(0, groupControlQuery);
            new VendorProc(drpQVendorID);
        }

        #endregion

    }
}