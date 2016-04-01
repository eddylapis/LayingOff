using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace LayingOff
{
 
    public  class DBProcess
    {
       // const string conStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\DataBase\LayingOff.mdb";
        string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\DataBase\\LayingOff.accdb";
        
        OleDbConnection conn ;
        DataSet Ds = new DataSet();
      public  DBProcess()
        {
             conn = new OleDbConnection(conStr);
        }

        public int DataProcess(string sqlStr)
        {
            try
            {
                Open();
               
                OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
                return 1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Close();
                return -1;
            }
        }

        public  DataSet Search(string sqlStr)
        {
            try
            {
                Open();
                Ds.Tables.Clear();
                OleDbDataAdapter Adapter = new OleDbDataAdapter(sqlStr, conn);
                Adapter.Fill(Ds);
                Adapter.Dispose();
                Close();
                return Ds;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Close();
                return null;
            }
        }

        public int AlterTableAdd(string type,string tname)
        {
            string sql="";
            try
            {
                Open();
                if (type == "add")
                    sql = "ALTER TABLE LIAODAN ADD " + tname + " text null";
                else if (type == "del")
                    sql = "ALTER TABLE LIAODAN DROP COLUMN  " + tname;
                else
                    return -1;

                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Close();
                return 1;
            }
            catch 
            {
                Close();
                return -1;
            }
        }

        void Close()
        {
            conn.Close();
        }
        void Open()
        {
            conn.Open();
        }

    }
}
