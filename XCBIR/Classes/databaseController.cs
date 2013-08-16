using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XCBIR.Classes
{
    /// <summary>
    /// Controls the link between the system and the database
    /// </summary>
    public class databaseController
    {
        /// <summary>
        /// Represents the current connection to SQL Server database
        /// </summary>
        private SqlConnection connectionString;
        /// <summary>
        /// Represents the current SQL command to execute
        /// </summary>
        private string commandText;
        /// <summary>
        /// Indicates wether the connection is opened or not
        /// </summary>
        private bool isConnected;

        /// <summary>
        /// Creates a new instance of the databaseController class
        /// </summary>
        /// <param name="ConnectionString">The connection string of this instance</param>
        public databaseController(SqlConnection ConnectionString)
        {
            this.connectionString = ConnectionString;
        }

        /// <summary>
        /// Gets or sets the current connection to SQL Server database
        /// </summary>
        public SqlConnection ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }

        /// <summary>
        /// Gets or sets the current SQL conmmand to execute
        /// </summary>
        public string CommandText
        {
            get
            {
                return commandText;
            }
            set
            {
                commandText = value;
            }
        }

        /// <summary>
        /// Gets a value indicating wether the connection is opened or not
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return isConnected;
            }
        }

        /// <summary>
        /// Connects to the database
        /// </summary>
        public bool Connect()
        {
            bool connected = false;
            this.connectionString.Open();
            connected = (this.connectionString.State == ConnectionState.Open);
            this.isConnected = connected;
            return connected;
        }

        /// <summary>
        /// Disconnects from the database
        /// </summary>
        public bool Disconnect()
        {
            bool disconnected = false;
            this.connectionString.Close();
            disconnected = (this.connectionString.State == ConnectionState.Closed);
            this.isConnected = !disconnected;
            return disconnected;
        }

        /// <summary>
        /// Execute an SQL query and returns its result in System.Data.DataSet
        /// </summary>
        public DataSet ExecuteQuery()
        {
            DataSet ds = new DataSet();
            if (this.isConnected)
            {
                SqlCommand com = new SqlCommand(this.commandText, this.connectionString);
                SqlDataAdapter adpt = new SqlDataAdapter(com);
                adpt.Fill(ds);
            }
            return ds;
        }

        /// <summary>
        /// Executes a non-query SQL command and returns the number of affected rows
        /// </summary>
        public int ExecuteNonQuery()
        {
            if (this.isConnected)
            {
                SqlCommand com = new SqlCommand(this.commandText, this.connectionString);
                return com.ExecuteNonQuery();
            }
            else
            {
                return -1;      //There is no connection
            }
        }
    }
}
