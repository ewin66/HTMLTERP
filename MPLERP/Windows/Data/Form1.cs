using HttSoft.FrameFunc;
using HttSoft.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MLTERP
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                string tableName = txtTable.Text.Trim();
                string sql = "SELECT * FROM " + tableName;
                string sqlTotal = string.Empty;
                DataTable dt = SysUtils.Fill(sql);
                int count = dt.Columns.Count;
                foreach (DataRow dr in dt.Rows)
                {
                    string Column = string.Empty;
                    string Name = string.Empty;
                    for (int i = 0; i < count - 1; i++)
                    {
                        if (Column != string.Empty)
                        {
                            Column += ",";
                        }
                        Column += dt.Columns[i].ColumnName;
                        if (Name != string.Empty)
                        {
                            Name += ",";
                        }
                        Name += SysString.ToDBString(SysConvert.ToString(dr[i]));
                    }
                    string insert = "INSERT " + tableName + "(" + Column + ")VALUES(" + Name + ")";
                    if (sqlTotal != string.Empty)
                    {
                        sqlTotal += " \r\n";
                    }
                    sqlTotal += insert;
                }
                txtSql.Text = sqlTotal;
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}
