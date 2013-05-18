using System;
using System.Collections.Generic;
using System.Data;
using System.Web;


public static class Util
{
    public static string GenerateBianhao(string header, string tableName)
    {
        int nDigit = 0;
        string ret = header;
        using (DataBase db = new DataBase())
        {
            string sql = "select count(*) as nRow from " + tableName;
            DataTable dt = db.ExecuteDataTable(sql);
            int nRow = (int)dt.Rows[0][0];
            if (nRow == 0) nDigit = 1;
            while (nRow > 0)
            {
                nRow /= 10;
                nDigit++;
            }
            int tmp = 6 - nDigit;
            while (tmp--!=0)
            {
                ret += "0";
            }
            nRow = (int)dt.Rows[0][0]+1;
            while (nDigit-- > 0)
            {
                if (nDigit == 0)
                {
                    ret += (nRow % 10);
                }
                else
                {
                    ret += (nRow / (nDigit * 10)) % 10 ;
                }

            }

        }
        return ret;

    }

    public static int GenZuoci(string tableName)
    {
        using (DataBase db = new DataBase())
        {
            string sql = "select count(*) as nrow from "+tableName;
            DataTable dt = db.ExecuteDataTable(sql);
            return (int)dt.Rows[0][0]+1;
        }
    }

    public static int GenZuoci(string tableName, string fahuiName)
    {
        using (DataBase db = new DataBase())
        {
            string sql = "select count(*) as nrow from " + tableName+" where FAHUI_NAME ='"+fahuiName+"'"+
                "AND YEAR(LOG_TIME)="+DateTime.Now.Year;
            DataTable dt = db.ExecuteDataTable(sql);
            return (int)dt.Rows[0][0] + 1;
        }
    }
}