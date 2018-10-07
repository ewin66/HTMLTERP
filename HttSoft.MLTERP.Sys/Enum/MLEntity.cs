using System;
using System.Collections.Generic;
using System.Text;

namespace MLTERP
{
    public class MLEntity
    {
        string ItemCode = string.Empty;

        public string m_ItemCode
        {
            get { return ItemCode; }
            set { ItemCode = value; }
        }

        string ItemName = string.Empty;

        public string m_ItemName
        {
            get { return ItemName; }
            set { ItemName = value; }
        }

        string ItemStd = string.Empty;

        public string m_ItemStd
        {
            get { return ItemStd; }
            set { ItemStd = value; }
        }
        string ColorName = string.Empty;

        public string m_ColorName
        {
            get { return ColorName; }
            set { ColorName = value; }
        }
        string ColorNum = string.Empty;

        public string m_ColorNum
        {
            get { return ColorNum; }
            set { ColorNum = value; }
        }
    }
}
