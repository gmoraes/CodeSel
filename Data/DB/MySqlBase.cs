#region Assembly

using System;
using System.Text;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Configuration;

#endregion

namespace QuickCodeSel.Data.DB
{
    public abstract class MySqlBase
    {
        public MySqlConnection Connection { get; private set; }

        public MySqlBase(string ConnectionString)
        {
            Connection = new MySqlConnection(ConnectionString);
        }

        public MySqlBase()
        {
            if (!string.IsNullOrEmpty(Entities.Database.ConnectionString)) 
                Connection = new MySqlConnection(Entities.Database.ConnectionString);
            else
                Connection = new MySqlConnection(System.Configuration.ConfigurationSettings.AppSettings["DefaultConnection"]);
        }

        protected virtual T FillAtribute<T>(MySqlDataReader lDataReader, string ColumnName)
        {
            return FillAtribute<T>(lDataReader, lDataReader.GetOrdinal(ColumnName));
        }

        protected virtual T FillAtribute<T>(MySqlDataReader lDataReader, int ColumnNumber)
        {
            if (lDataReader.IsDBNull(ColumnNumber))
            {
                return default(T);
            }

            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), lDataReader.GetValue(ColumnNumber).ToString());
            }

            dynamic value = lDataReader.GetValue(ColumnNumber);

            if (typeof(T).Name == "Boolean")
            {
                value = Convert.ToBoolean(value);
            }

            return (T)value;
        }

        #region AddParameter Methods

        protected virtual void AddInParameter(MySqlCommand lCommand, string lFieldName, object lValue)
        {
            object DataBaseValue = null;
            if (lValue != null)
            {
                if (lValue.GetType().IsEnum)
                {
                    if (lValue.ToString() == "Undefined")
                    {
                        DataBaseValue = DBNull.Value;
                    }
                    else
                    {
                        DataBaseValue = Convert.ToInt32(lValue);
                    }
                }
                else
                {
                    DataBaseValue = lValue;
                }
            }

            MySqlParameter Param = new MySqlParameter(lFieldName, GatherDBType(DataBaseValue));
            Param.Value = DataBaseValue == null ? DBNull.Value : DataBaseValue;
            Param.IsNullable = true;
            lCommand.Parameters.Add(Param);
        }

        private MySqlDbType GatherDBType(object Value)
        {
            if (Value == null)
            {
                return MySqlDbType.String;
            }

            switch (Value.GetType().Name)
            {
                case "String":
                    return MySqlDbType.String;
                case "Decimal":
                    return MySqlDbType.Decimal;
                case "Boolean":
                    return MySqlDbType.Bit;
                case "Date":
                    return MySqlDbType.Date;
                case "DateTime":
                    return MySqlDbType.DateTime;
                case "Int16":
                    return MySqlDbType.Int16;
                case "Int32":
                    return MySqlDbType.Int32;
                case "Int64":
                    return MySqlDbType.Int64;
                case "Double":
                    return MySqlDbType.Double;
                case "Byte":
                    return MySqlDbType.Byte;
                case "Binary":
                    return MySqlDbType.Binary;
                case "Char":
                    return MySqlDbType.String;
                default:
                    return MySqlDbType.String;
            }
        }

        #endregion

        #region Excecute Commands

        protected int ExecuteNonQuery(MySqlCommand lCommand)
        {
            if (lCommand.Connection.State != ConnectionState.Open)
            {
                lCommand.Connection.Open();
            }
            return lCommand.ExecuteNonQuery();
        }

        protected MySqlDataReader ExecuteReader(MySqlCommand lCommand)
        {
            if (lCommand.Connection.State != ConnectionState.Open)
            {
                lCommand.Connection.Open();
            }
            return lCommand.ExecuteReader();
        }

        protected object ExecuteScalar(MySqlCommand lCommand)
        {
            if (lCommand.Connection.State != ConnectionState.Open)
            {
                lCommand.Connection.Open();
            }
            return lCommand.ExecuteScalar();
        }

        protected void CloseConnection()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        #endregion

        #region Create Command

        protected MySqlCommand GetSqlStringCommand(string lStrSQL)
        {
            MySqlCommand Command = new MySqlCommand(lStrSQL, Connection);
            Command.CommandTimeout = 50000;
            return Command;
        }

        #endregion
    }
}