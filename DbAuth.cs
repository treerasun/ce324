using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace FAPerformanceWeb
{
    public class DbAuth
    {
       /* public static bool CreateSession(string user_id, bool cookie, string ipaddress, string user_agent)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            string token = SessionManager.GetToken(r);

            List<DataValue> data = new List<DataValue>();
            data.Add(new DataValue("id", "session_seq.NEXTVAL"));
            data.Add(new DataValue("created_at", "SYSTIMESTAMP"));
            data.Add(new DataValue("created_by", user_id));
            data.Add(new DataValue("updated_at", "SYSTIMESTAMP"));
            data.Add(new DataValue("token", token, true));
            data.Add(new DataValue("ip", ipaddress, true));
            data.Add(new DataValue("user_agent", user_agent, true));
            data.Add(new DataValue("cookie", cookie ? "1" : "0"));
            data.Add(new DataValue("expired", "0"));
            data.Add(new DataValue("expired_at", "SYSTIMESTAMP + INTERVAL '1' YEAR"));

            string sql = SQL.CreateInsertSQL(TableName.SESSION, data) + "returning \"ID\" into :p1";
            OracleParameter p1 = new OracleParameter("p1", OleDbType.Integer);
            p1.Direction = ParameterDirection.Output;

            DbData.QueryInsertWithParameter(sql, p1);

            string value = token + p1.Value;
            HttpContext.Current.Session[SessionManager.SESSION_USER_ID] = value;

            if (cookie)
            {
                //Global.ResponseMe(value);
                SessionManager.CreateSessionCookie(value);
            }

            UserDt user1 = new UserDt(user_id);
            user1.UpdateColumn("last_login", "SYSTIMESTAMP", false);
            return true;
        }*/

        public static int CheckLogin(string sql)
        {
            DataTable dt = DbData.QuerySelect(sql);
            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                DataRow dr = dt.Rows[0];
                return Int32.Parse(dr["id"].ToString());
            }
        }

    }
}
