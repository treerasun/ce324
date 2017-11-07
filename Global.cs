using FAPerformanceWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Global
{
    public static bool loggedIn = false;
    public static int userId = 0;
    public static bool IsDailySystem = true;
    public static int Brake_Time;
    public static int queryCount = 0;
    public static long queryTime = 0;
    public static int RUN_TIME1 = 0;
    public static int ORIGIN_TIME1 = 0;
    public static int ERROR_TIME1 = 0;
    public static int STOP_TIME1 = 0;
    public static bool notfound = true;
    public static string data_n = "";
  
    public static string[] mc1_t = new string[30];
    public static string[] mc1_c = new string[30];

    public static string debug_text = "";

    public static string GetUserIP()
    {
        string ipaddress = null;
        if (HttpContext.Current != null)
        {
            HttpRequest request = HttpContext.Current.Request;
            ipaddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = request.ServerVariables["REMOTE_ADDR"];
        }
        return ipaddress;
    }

    public static void Initial()
    {
        loggedIn = false;

        userId = 0;

        notfound = true;

        queryCount = 0;
        queryTime = 0;

　
    }

    public static void ResponseMe(string s)
    {
        if (HttpContext.Current != null)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.Write(s);
        }
    }

    public static void ResponseEnd(string s)
    {
        if (HttpContext.Current != null)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.Write(s);
            response.End();
        }
    }

    public static string RequestUrl(string url)
    {
        int i = url.IndexOf('?');
        if (i >= 0)
        {
            string a = url.Substring(0, i);
            string b = url.Substring(i);

            if (i == 1)
            {
                return "/?" + b;
            }
            return RequestToGet(a) + b.Replace('?', '&');
        }
        else
        {
            return RequestToGet(url);
        }
    }

    public static string RequestToGet(string url)
    {
        string u = "/";
        string[] m = url.Split('/');
        int c = 1;
        for (int i = 0; i < m.Length; i++)
        {
            if (m[i] == "") continue;

            if (c == 1)
            {
                u += "?";
            }
            else
            {
                u += "&";
            }
            u += "m" + c + "=" + m[i];
            c++;
        }
        return u;
    }

    public static string test1(int u, string mc)
    {
        string sum = "google.visualization.arrayToDataTable([ ['Alarm Code', 'Time', 'Counter'],";
        for (int i = 0; i <= u; i++)
        {
            if (mc1_c[i] != "0" && mc1_t[i] != "0")
            {
                sum += "['"+mcerror(i+1,mc)+"'," + Global.mc1_c[i] + "," + mc1_t[i] + "],";
            }

        }
        if(sum == "google.visualization.arrayToDataTable([ ['Alarm Code', 'Time', 'Counter'],")
        {
            sum += "['" + 0 + "'," + 0 + "," + 0 + "],";
        }

        return sum + "]);";

    }
    public static string mcerror(int u, string mc)
    {
        string sql2 = "select * from " + FAPerformanceWeb.TableName.MC_ALARM1+ "  where MCNAME ='"+mc+ "' and ALARM_NUMBER  = 'Error"+u+"'";
        System.Data.DataTable dt2 = FAPerformanceWeb.DbData.QuerySelect(sql2);

        string mc1 = "";
        foreach (System.Data.DataRow dr1 in dt2.Rows)
        {
            mc1 = dr1["ALARM_NAME"].ToString();
        }
            return mc1;
    }
}
