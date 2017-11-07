using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAPerformanceWeb
{
    public class DbRows
    {
        public static bool IsExistByColumn(string table, string column, string value)
        {
            string sql = "select * from " + table + " where " + column + " = \'" + value + "\'";
            return DbData.QuerySelectCount(sql) != 0;
        }

        public static bool IsExistById(string table, string id)
        {
            int item_id = 0;
            try
            {
                item_id = Int32.Parse(id);
            } catch (Exception e)
            {
                return false;
            }
            string sql = "select count(*) from " + table + " where status = 1 and id = \'" + item_id + "\'";
            return DbData.QueryCountRow(sql) == 1;
        }
    }
}
