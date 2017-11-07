using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAPerformanceWeb
{
    public class DataValue
    {
        private string column;
        private string value;
        private bool qouted;
        private bool n = false;
        public DataValue(string a, string b)
        {
            column = a;
            value = b;

        }
        public DataValue(string a, string b, bool c)
        {
            column = a;
            value = b;
            qouted = c;
        }

        public DataValue(string a, string b, bool c, bool d)
        {
            column = a;
            value = b;
            qouted = c;
            n = d;
        }

        private string PrepareQuote(string n)
        {
            if (qouted)
                return n.Replace("'", "''");
            else
                return n;
        }

        public string Column
        {
            get
            {
                return ReservedWord(column);
            }
        }

        public string Value
        {
            get
            {
                return AddSingleQuote(PrepareQuote(value));
            }
        }

        private string ReservedWord(string c)
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

        private string AddSingleQuote(string s)
        {
            if (qouted)
            {
                if(n)
                    return "N'" + s + "'";
                else
                    return "'" + s + "'";
            }
            else
            {
                return s;
            }
        }

        private string AddDoubleQuote(string s)
        {
            return "\"" + s + "\"";
        }
    }
}
