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

namespace MLTERP
{
    public partial class frmZPInWH : frmAPBaseUIForm
    {
        public frmZPInWH()
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
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }
            if (txtQItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND  ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtVendorAttn.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorAttn LIKE " + SysString.ToDBString("%" + txtVendorAttn.Text.Trim() + "%");
            }
            if (txtQItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }
            if (txtQJarNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (txtQColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtQColorNum.Text.Trim() + "%");
            }
            if (txtQColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtQColorName.Text.Trim() + "%");
            }
            if (txtDtsOrderFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND DtsOrderFormNo LIKE " + SysString.ToDBString("%" + txtDtsOrderFormNo.Text.Trim() + "%");
            }
            
            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN "+SysString.ToDBString(txtQFormDateS.DateTime)+" AND "+SysString.ToDBString(txtQFormDateE.DateTime);
            }

            if (txtQBoxNo.Text.Trim() != string.Empty)//�����ѯ
            {
                tempStr += " AND ID =(select MainID from WH_IOFormDtsPack where BoxNo =" + SysString.ToDBString(txtQBoxNo.Text.Trim())+")";
            }

       
            if (SysConvert.ToString(drpSubType.EditValue) != string.Empty)
            {
                tempStr += " AND SubType=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
            }
            if (this.FormListAID != 0)
            {
                tempStr += " AND HeadType=" + this.FormListAID;
            }

            tempStr += Common.GetWHRightCondition();

            tempStr += " AND ISNULL(DelFlag,0)<>1";
            tempStr += " ORDER BY FormDate DESC,ID DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            IOFormRule rule = new IOFormRule();
            DataTable dt = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
         
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }


        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
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
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;

            this.HTQryContainer = groupControlQuery;
            txtQFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQFormDateE.DateTime = DateTime.Now.Date;
            Common.BindSubType(drpSubType, this.FormListAID, true);
          
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�,(int)EnumVendorType.����},true);
            new VendorProc(drpVendorID);

            //Common.BindQueryMethod(drpQueryMethod, true);

            this.ToolBarItemAdd(32, "btnScanInWH", "ɨ�����", true, btnScanInWH_Click, eShortcut.F9);

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

        #region ɨ�����
        /// <summary>
        /// ɨ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScanInWH_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��1))
                {
                    this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                    return;
                }


                frmScanInWH frm = new frmScanInWH();

                frm.ShowDialog();



            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion




    }
}