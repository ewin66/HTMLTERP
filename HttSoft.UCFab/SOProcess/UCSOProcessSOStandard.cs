using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HttSoft.UCFab
{
    /// <summary>
    /// ���ܣ����� ������ʾ ��׼��ʽ
    /// ���ߣ�Standy
    /// ���ڣ�2015-5-15
    /// </summary>
    public partial class UCSOProcessSOStandard : UCSOProcessSOBase
    {
        public UCSOProcessSOStandard()
        {
            InitializeComponent();
        }


        #region �鷽����д

        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public override void UCAct()
        {
            if (UCDataSource != null)
            {
                if (UCDataSource.Rows.Count > 0)
                {
                    SetOneDataSource(UCDataSource.Rows[0], 0);
                }
            }
        }

        #endregion

        #region �ڲ�����
        /// <summary>
        /// ����һ������Դ
        /// </summary>
        /// <param name="dr">������Դ</param>
        /// <param name="rowIndex">�к�</param>
        void SetOneDataSource(DataRow dr, int rowIndex)
        {
            txtFormDate.Text = dr["FormDate"].ToString();
            txtFormNo.Text = dr["FormNo"].ToString();
            txtTotalQty.Text = dr["Qty"].ToString();
            txtReceiveQty.Text = dr["ReceiveQty"].ToString();
        }
        #endregion
    }
}
