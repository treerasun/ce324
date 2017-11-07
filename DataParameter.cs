using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAPerformanceWeb
{
    public class DataParameter
    {
        private string column;
        private string value;
        private bool qouted = false;
        private bool isParam = false;
        public DataParameter(string a, string b, bool c, bool d)
        {
            column = a;
            value = b;
            qouted = c;
            isParam = d;
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
                return AddSingleQuote(value);
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
