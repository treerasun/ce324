using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FAPerformanceWeb
{
    public class DbData
    {
        private static bool closeDebug = false;
        private static string GetConnectionString()
        {
            return "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=PDEM-DB-TEST.cht-dm.cht.canon.co.th)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=HTPDEMT)));" +
                    "User Id=fanet ;Password=fanet5602";
        }

        public static DataTable QuerySelect(string sql)
        {
            string connectionString = GetConnectionString();

            OracleConnection connection = null;

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = sql;

                OracleDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                return dt;
            }
            catch (Exception e)
            {
                Global.ResponseMe(e.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();

                    if (closeDebug)
                    {
                        Global.ResponseMe("<div>State: " + connection.State + " [QuerySelect]</div>");
                    }
                }

                stopwatch.Stop();
                Global.queryTime += stopwatch.ElapsedMilliseconds;
                Global.queryCount++;
            }

            return null;
        }

        public static int QuerySelectCount(string sql)
        {
            return QuerySelect(sql).Rows.Count;
        }

        public static bool QueryScalar(string sql)
        {
            string connectionString = GetConnectionString();

            OracleConnection connection = null;

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {
                Global.ResponseMe(e.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                    if (closeDebug)
                    {
                        Global.ResponseMe("<div>State: " + connection.State + " [QueryScalar]</div>");
                    }
                }

                stopwatch.Stop();
                Global.queryTime += stopwatch.ElapsedMilliseconds;
                Global.queryCount++;
            }

            return false;
        }

        public static bool UpdateQuery(string sql)
        {
            string connectionString = GetConnectionString();

            OracleConnection connection = null;

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Global.ResponseMe(e.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                    if (closeDebug)
                    {
                        Global.ResponseMe("<div>State: " + connection.State + " [QueryScalar]</div>");
                    }
                }

                stopwatch.Stop();
                Global.queryTime += stopwatch.ElapsedMilliseconds;
                Global.queryCount++;
            }

            return false;
        }

        public static object QueryObjectScalar(string sql)
        {
            string connectionString = GetConnectionString();

            OracleConnection connection = null;

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = sql;
                return command.ExecuteScalar();
            }
            catch (Exception e)
            {
                Global.ResponseMe(e.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                    if (closeDebug)
                    {
                        Global.ResponseMe("<div>State: " + connection.State + " [QueryObjectScalar]</div>");
                    }
                }

                stopwatch.Stop();
                Global.queryTime += stopwatch.ElapsedMilliseconds;
                Global.queryCount++;
            }

            return 0;
        }

        public static object QueryCount(string sql)
        {
            string connectionString = GetConnectionString();

            OracleConnection connection = null;

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = sql;
                return command.ExecuteScalar();
            }
            catch (Exception e)
            {
                Global.ResponseMe(e.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }

                stopwatch.Stop();
                Global.queryTime += stopwatch.ElapsedMilliseconds;
                Global.queryCount++;
            }

            return -1;
        }

        public static int QueryCountRow(string sql)
        {
            string connectionString = GetConnectionString();

            OracleConnection connection = null;

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = sql;
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception e)
            {
                Global.ResponseMe(e.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }

                stopwatch.Stop();
                Global.queryTime += stopwatch.ElapsedMilliseconds;
                Global.queryCount++;
            }

            return 0;
        }

        public static bool QueryInsertWithParameter(string sql, OracleParameter p1)
        {
            string connectionString = GetConnectionString();

            OracleConnection connection = null;

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                OracleCommand command = connection.CreateCommand();
                command.CommandText = sql;
                command.Parameters.Add(p1);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Global.ResponseMe(e.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();

                    if (closeDebug)
                    {
                        Global.ResponseMe("<div>State: " + connection.State + " [QueryScalar]</div>");
                    }
                }

                stopwatch.Stop();
                Global.queryTime += stopwatch.ElapsedMilliseconds;
                Global.queryCount++;
            }

            return false;
        }
    }
}
