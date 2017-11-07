using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAPerformanceWeb
{
    public class SQL
    {
        public static string CreateInsertSQL(string table, List<DataValue> data)
        {
            string key = "";
            string val = "";
            int length = data.Count, i = 0;
            foreach (DataValue a in data)
            {
                key += a.Column;
                val += a.Value;
                if (++i < length)
                {
                    key += ", ";
                    val += ", ";
                }
            }
          return "insert into " + table + "(" + key + ") values(" + val + ")";
        }

        public static string CreateUpdate(string table, List<DataValue> data, string condition)
        {
            string text = "";
            int length = data.Count, i = 0;
            foreach (DataValue a in data)
            {
                text += (a.Column + " = " + a.Value);
                if (++i < length)
                {
                    text += ", ";
                }
            }
            return "update " + table + " set " + text + condition;
        }

       /* public static string SelectLogin(string username, string password)
        {
            
            string sql = "select * from " + TableName.USER +
                " where status = 1 and (username = '" + username + "' or email = '" + username +
                "' or employee_id = '" + username +
                "') and password = '" + password + "'";
            return sql;
            
            string sql = "select * from " + TableName.USER +
                " where status = 1 and employee_id = '" + username +
                "' and password = '" + password + "'";
            return sql;
        }*/

        private static string ReservedWord(string c)
        {
            string[] reserved = { "id", "password", "level" };
            foreach (string a in reserved)
            {
                if (a == c)
                {
                    return AddDoubleQuote(c.ToUpper());
                }
            }
            return c;
        }

        public static string GetCol(string s)
        {
            return ReservedWord(s);
        }

        private static string AddSingleQuote(string s)
        {
            return "'" + s + "'";
        }

        private static string AddDoubleQuote(string s)
        {
            return "\"" + s + "\"";
        }
    }
}
