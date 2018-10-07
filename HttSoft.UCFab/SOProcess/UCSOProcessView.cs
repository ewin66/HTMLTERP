using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;

namespace HttSoft.UCFab
{

    /// <summary>
    /// ҵ���վ��
    /// �¼Ӻ�
    /// 2014.4.18
    /// </summary>
    public enum EnumUCSaleProcedure
    {
        ɴ�߲ɹ��� = 1,
        �����ɹ��� = 2,
        ��Ʒ�ɹ��� = 3,
        ���ϲɹ��� = 4,//һ�㲻�������
        Ⱦɴ�ӹ��� = 10,
        ֯�߼ӹ��� = 11,
        Ⱦ���ӹ��� = 12,
        ӡ���ӹ��� = 13,
        ���ϼӹ��� = 14,
        ������ = 20,
        �����ӹ��� = 25,

    }


    /// <summary>
    /// ���ܣ����ݴ��������ʾ
    ///    �����Ľ�֧�ֶ�ģʽ�����ȿ��ٳ���
    /// ���ߣ�Standy
    /// ���ڣ�2015-5-15
    /// </summary>
    public partial class UCSOProcessView : UCFabBase
    {
        public UCSOProcessView()
        {
            InitializeComponent();
        }
        #region ���� (�������뵽����)
        /// <summary>
        /// ��ͬ��
        /// </summary>
        private string m_FormNo = "";
        /// <summary>
        /// ��ͬ��
        /// </summary>
        public string FormNo
        {
            get
            {
                return m_FormNo;
            }
            set
            {
                m_FormNo = value;
            }
        }

        public int FormDataID = 0;//����ID
        #endregion

        #region ��������  (�������뵽�����鷽��)
        /// <summary>
        /// ִ�пؼ�
        /// </summary>
        public void UCAct()
        {
            IniData();
            SetData();
        }
        #endregion

        #region �ڲ�����(��ʼ��ֵ)
        /// <summary>
        /// ��������ֵ
        /// </summary>
        void SetData()
        {
            ClearData();
            string sql = string.Empty;
            //������Ϣ����
            sql = "SELECT FormNo,MAX(OrderDate) FormDate,SUM(Qty) Qty,SUM(TotalRecQty) ReceiveQty FROM UV1_Sale_SaleOrderDts WHERE FormNo=" + SysString.ToDBString(FormNo);
            sql += " GROUP BY FormNo";
            DataTable dt = SysUtils.Fill(sql);
            ucsoProcessSOStandard1.UCDataSource = dt;
            ucsoProcessSOStandard1.UCAct();


            //�ɹ���������
            sql = "SELECT FormNo,FormDate,SUM(Qty) Qty,SUM(TotalRecQty) ReceiveQty,MLType FROM UV1_Buy_ItemBuyFormDts WHERE DtsSO=" + SysString.ToDBString(FormNo);
            sql += " GROUP BY FormNo,FormDate,MLType";
            DataTable dtBuy = SysUtils.Fill(sql);
         
            //�ӹ���������
            sql = "SELECT FormNo,FormDate,SUM(Qty) Qty,SUM(TotalRecQty) ReceiveQty,ProcessTypeID FROM UV1_WO_FabricProcessDts WHERE DtsSO=" + SysString.ToDBString(FormNo);
            sql += " GROUP BY FormNo,FormDate,ProcessTypeID";
            DataTable dtWO = SysUtils.Fill(sql);

          
            for (int i = 1; i <= 8; i++)
            {
                UCSOProcessOneStandard uspos=FindOneCtl(i);
                SetDataOne(uspos,dtBuy, dtWO);
            }
        }

        void SetDataOne(UCSOProcessOneStandard uspos,DataTable dtBuy, DataTable dtWO)
        {

            if (uspos.Visible)
            {
                switch (uspos.UCStepID)
                {
                    case (int)EnumUCSaleProcedure.ɴ�߲ɹ���:
                        uspos.UCDataSource = dtBuy.Select("MLType=3");
                        break;


                    case (int)EnumUCSaleProcedure.��Ʒ�ɹ���:
                        uspos.UCDataSource = dtBuy.Select("MLType=1");
                        break;

                    case (int)EnumUCSaleProcedure.�����ɹ���:
                        uspos.UCDataSource = dtBuy.Select("MLType=2");
                        break;
                    case (int)EnumUCSaleProcedure.���ϲɹ���:
                        uspos.UCDataSource = dtBuy.Select("MLType=5");

                        break;

                    case (int)EnumUCSaleProcedure.֯�߼ӹ���:
                        uspos.UCDataSource = dtWO.Select("ProcessTypeID=2");
                        break;

                    case (int)EnumUCSaleProcedure.Ⱦ���ӹ���:
                        uspos.UCDataSource = dtWO.Select("ProcessTypeID=1");
                        break;

                    case (int)EnumUCSaleProcedure.ӡ���ӹ���:
                        uspos.UCDataSource = dtWO.Select("ProcessTypeID=3");
                        break;

                    case (int)EnumUCSaleProcedure.�����ӹ���:
                        uspos.UCDataSource = dtWO.Select("ProcessTypeID=4");
                        break;
                }
                uspos.UCAct();
            }

            //for (int i = 0; i < dtBuy.Rows.Count; i++)//�ɹ�
            //{
            //    // 1/2/3/4/5����Ʒ��������ɴ�ߣ�ɫ��������

            //}
            //for (int i = 0; i < dtWO.Rows.Count; i++)//�ӹ�
            //{
            //    //2��֯�� 1��Ⱦ�� 3��ӡ�� 4������


            //}
        }

        /// <summary>
        /// �������
        /// </summary>
        void ClearData()
        {
            for (int i = 1; i <= 6; i++)
            {
                UCSOProcessOneStandard ucpos = FindOneCtl(i);
                if (ucpos.Visible)
                {
                    ucpos.UCDataSource = null;
                }
            }
        }
        #endregion

        #region �ڲ�����(��ʼ��������Ϣ)
        /// <summary>
        /// ��ʼ������
        /// </summary>
        void IniData()
        {
            string sql=string.Empty;
            sql = "SELECT ID,Name FROM Enum_SaleProcedure WHERE ShowFlag=1 AND ID IN (SELECT SaleProcedureID FROM Sale_SaleOrderProcedureDts WHERE MainID=" + FormDataID + ") ORDER BY Code";
            DataTable dt = SysUtils.Fill(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IniDataOneProcess(dt.Rows[i], i + 1);
            }
        }
        /// <summary>
        /// ��ʼ��һ������
        /// </summary>
        /// <param name="p_Dr"></param>
        void IniDataOneProcess(DataRow p_Dr,int p_StepIndex)
        {
            UCSOProcessOneStandard ucpos = FindOneCtl(p_StepIndex);
            ucpos.UCSettingDr=p_Dr;
            ucpos.UCStepIndex=p_StepIndex;
            ucpos.Visible = true;
        }

        /// <summary>
        /// Ѱ�ҿؼ�
        /// </summary>
        /// <param name="p_StepIndex"></param>
        /// <returns></returns>
        UCSOProcessOneStandard FindOneCtl(int p_StepIndex)
        {
            foreach (Control ctl in panAll.Controls)
            {
                if (ctl is UCSOProcessOneStandard)
                {
                    if (ctl.Name == "ucsoProcessOneStandard" + p_StepIndex.ToString())
                    {
                        return (UCSOProcessOneStandard)ctl;
                    }
                }
            }
            return new UCSOProcessOneStandard();
            
        }
        #endregion

        #region �ؼ��¼�
        /// <summary>
        /// �ؼ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCSOProcessView_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
    }
}
