using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
namespace LayingOff
{
   public class XmlProcess
    {
       const string Flag="T";
       public XmlDocument xml;
       string LoadPath = Application.StartupPath+"\\XML\\Equation.xml";
       public  XmlProcess()
       {
           xml = new XmlDocument();

       }
       public  XmlNode GetXml()
       {
           xml.Load(LoadPath);
           return xml.SelectSingleNode("ROOT");
       }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="Type">门的类型</param>
       /// <param name="Version">门的型号</param>
       /// <param name="Name">计算的名称</param>
       /// <returns>返回求得的数据</returns>
        public  string  Search(string Second,string Type,string Open,string Name)
       {
           try
           {
               return GetXml().SelectSingleNode(Second).SelectSingleNode(Type).SelectSingleNode(AddF(Open)).SelectSingleNode(Name).InnerText;
           }
            catch
           {
               MessageBox.Show("未找到");
                return null;
           }
       }
        public XmlNode Search( string Name,string Value)
        {
            try
            {
                return GetXml().SelectSingleNode("CONTROLS").SelectSingleNode(Name).SelectSingleNode(AddF(Value));
            }
            catch
            {
                return null;
            }
        }

        public   void AddItem(string type,string value)
        {
           
                if(Search(type, value)!=null)
                { 
                  MessageBox.Show("该名称已存在!!!");
                }
                 else
                {
                    AddComBoxItem(type, value);
                 }
        }
        public void DelItem(string type, string value)
        {
            XmlNode node;
            if ((node=Search(type, value)) == null)
            {
                MessageBox.Show("该名称不存在!!!");
            }
            else
            {
                node.ParentNode.RemoveChild(node);
                Save();
                MessageBox.Show("删除成功!!");
            }

        }
        public int ItemCount(string type,string value)
        {
            int i = 0;
            string tmpName = "";
            if ((Search("防盗门", value)) != null)
            {
                tmpName = "防盗门";
                i++;
            }
            if ((Search("楼宇门", value)) != null)
            {
                tmpName = "楼宇门";
                i++;
            }
            if ((Search("防火门", value)) != null)
            {
                tmpName = "防火门";
                i++;
            }
            if (i == 1 && tmpName == type)
                return 1;
            else if (i!=1)
                return i;
            else
                return -1;

        }



    
        public void UpdateData(string Second,string StrType, string StrOpen, string Name,string Data)
       {
           xml.SelectSingleNode("ROOT").SelectSingleNode(Second).SelectSingleNode(StrType).SelectSingleNode(AddF(StrOpen)).SelectSingleNode(Name).InnerText = Data;
       }

       public void AddComBoxItem(string Name,string Value)
       {

           try
           {
               XmlElement Element =  xml.CreateElement(AddF(Value));
               xml.SelectSingleNode("ROOT//CONTROLS").SelectSingleNode(Name).AppendChild(Element);
               MessageBox.Show(Value + "已添加");
                   
           }
           catch
           {
               return;
           }
        
           Save();
       }
       public void DelComBoxItem(string Name, string Value)
       {
           try
           {
               XmlNode SonNode = Search(Name, Value);
               SonNode.ParentNode.RemoveChild(SonNode);
               Save();
               MessageBox.Show(Value + "已删除");
           }
           catch
           {
               return;
           }

       }

       public string AddF(string str)
       {
           return Flag + str;
       }
       public  string DelF(string str)
        {
            return str.Substring(1);
        }
 
       public void Save()
       {
           xml.Save(LoadPath);

       }


    }
}
