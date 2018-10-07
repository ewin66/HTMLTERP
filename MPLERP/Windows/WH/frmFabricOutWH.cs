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
    public partial class frmFabricOutWH : frmAPBaseUIForm
    {
        public frmFabricOutWH()
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

            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN "+SysString.ToDBString(txtOrderDateS.DateTime)+" AND "+SysString.ToDBString(txtOrderDateE.DateTime);
            }

            if (txtVendorID.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorName LIKE"+SysString.ToDBString("%"+txtVendorID.Text.Trim()+"%");
            }

            if (txtQDtsOrderFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND DtsOrderFormNo LIKE" + SysString.ToDBString("%" + txtQDtsOrderFormNo.Text.Trim() + "%");
            }

            if (SysConvert.ToString(drpVendorID.EditValue) != "")
            {
                tempStr += " AND VendorID="+SysString.ToDBString(SysConvert.ToString(drpVendorID.EditValue));
            }

            if (drpXZ.Text.Trim() != string.Empty)
            {
                tempStr += " AND XZ="+SysString.ToDBString(drpXZ.Text.Trim());
            }

            if (txtJarNum.Text.Trim() != "")
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtJarNum.Text.Trim() + "%");
            }

            if (txtBatch.Text.Trim() != "")
            {
                tempStr += " AND Batch LIKE " + SysString.ToDBString("%" + txtBatch.Text.Trim() + "%");
            }

            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }
           

            if(txtItemCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }

            if(txtGoodsCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND GoodsCode="+SysString.ToDBString(txtGoodsCode.Text.Trim());
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(8009)) == 0)//��ѯģʽ 0��ģ����ѯ�� 1��ȷ��ѯ
                {
                    tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
                }
                else
                {
                    tempStr += " AND ColorNum = " + SysString.ToDBString(txtColorNum.Text.Trim());
                }

            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(8009)) == 0)//��ѯģʽ 0��ģ����ѯ�� 1��ȷ��ѯ
                {
                    tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
                }
                else
                {
                    tempStr += " AND ColorName = " + SysString.ToDBString(txtColorName.Text.Trim());
                }
            }
            if (txtQDtsSO.Text.Trim() != string.Empty)
            {
                tempStr += " AND DtsSO LIKE " + SysString.ToDBString("%" + txtQDtsSO.Text.Trim() + "%");
            }

            if(txtVColorNum.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND VColorNum LIKE "+SysString.ToDBString("%"+txtVColorNum.Text.Trim()+"%");
            }

            if(txtVColorName.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND VColorName LIKE "+SysString.ToDBString("%"+txtVColorName.Text.Trim()+"%");
            }

            if(txtVItemCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND VItemCode LIKE "+SysString.ToDBString("%"+txtVItemCode.Text.Trim()+"%");
            }

            //if(txtBatch.Text.Trim()!=string.Empty)
            //{
            //    tempStr+=" AND Batch="+SysString.ToDBString(txtBatch.Text.Trim());
            //}

            //if(txtJarNum.Text.Trim()!=string.Empty)
            //{
            //    tempStr+=" AND JarNum LIKE "+SysString.ToDBString("%"+txtJarNum.Text.Trim()+"%");
            //}
            if (SysConvert.ToString(drpSubType.EditValue) != string.Empty)
            {
                tempStr += " AND SubType=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
            }
            if (this.FormListAID != 0)
            {
                tempStr += " AND HeadType=" + this.FormListAID;
            }


            tempStr += Common.GetWHRightCondition();


            tempStr += " ORDER BY FormDate DESC,ID DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            IOFormRule rule = new IOFormRule();
            DataTable dt = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("DtsVendorName", "'' DtsVendorName"));
            if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(6425)))//��ѯ���������ͻ�
            {
                SetGirdDataSource(dt);
            }
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();
        }

        private void SetGirdDataSource(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr["DtsVendorName"] = GetSOVendor(SysConvert.ToString(dr["DtsOrderFormNo"]));
            }
        }

        private string GetSOVendor(string p_SO)
        {
            string VendorName = "";
            string sql = "SELECT VendorAttn from UV1_Sale_SaleOrder WHERE FormNo=" + SysString.ToDBString(p_SO);
            DataTable dt = SysUtils.Fill(sql);
            if (dt.Rows.Count > 0)
            {
                VendorName = SysConvert.ToString(dt.Rows[0][0]);
            }
            return VendorName;
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
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            Common.BindSubType(drpSubType, this.FormListAID, true);
            Common.BindCLS(drpXZ, "WH_IOForm", "XZ", true);
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.���� }, true);
            new VendorProc(drpVendorID);
            //this.ToolBarItemAdd(32, "btnUpdateWHVendor", "�޸Ŀͻ�̧ͷ", true, btnUpdateWHVendor_Click, eShortcut.F9);

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

        #region �޸Ŀͻ�̧ͷ

        /// <summary>
        /// �޸Ŀͻ�̧ͷ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateWHVendor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��2))
                {
                    this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                    return;
                }
                frmUpdateWHVendor frm = new frmUpdateWHVendor();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(580, 280);
                frm.FormNo = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FormNo"));
                frm.VendorID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "VendorID"));
                frm.ShowDialog();

                btnQuery_Click(null, null);

                ProcessGrid.GridViewFocus(gridView1, new string[1] { "FormNo" }, new string[1] { frm.FormNo.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion



       


    }
}