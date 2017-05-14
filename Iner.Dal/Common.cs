// -------------------------------------------------------------+
// File Name: Common.cs
// Description: This file containing the common DAL related work.
// Developed By: Arnab Roy Chowdhury.
// Date: 25th February 2012.
// -------------------------------------------------------------+

using System;
using System.Data;
using System.Data.SqlClient;

namespace Northwind.Dal
{
    // Common DAL related work.
    internal class Common : IDisposable
    {
        private static string _connectionString; 
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private bool _isDisposed;
        
        static Common()
        {
            // It will hold the connection string when the class loads.
            _connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings
                ["NorthwindConnectionString"].ConnectionString;
        }

        public Common()
        {
            this._connection = new SqlConnection(_connectionString); // Initialised the connection string for every object.
            this._command = new SqlCommand()
            {
                Connection = this._connection,
                CommandType = CommandType.Text
            };
            this._isDisposed = false;
        }

        // Gets the state of the object weather it is disposed or not.
        protected bool IsDisposed
        {
            get
            {
                lock (this) // Make it thread safe.
                {
                    return this._isDisposed;
                }
            }
        }

        public SqlDataReader ExecuteReader(string query)
        {
            if (!this.IsDisposed)
            {
                this._command.CommandText = query;

                this._connection.Open();
                this._reader = _command.ExecuteReader(CommandBehavior.CloseConnection);

                return this._reader;
            }
            else
            {
                throw new ObjectDisposedException("Common class object is already disposed.");
            }
        }

        public SqlDataReader ExecuteReader(string query, params  SqlParameter[] parameters)
        {
            if (!this.IsDisposed)
            {
                this._command.CommandText = query;
                foreach (SqlParameter parameter in parameters)
                {
                    this._command.Parameters.Add(parameter);
                }

                this._connection.Open();
                this._reader = _command.ExecuteReader(CommandBehavior.CloseConnection);

                return _reader;
            }
            else
            {
                throw new ObjectDisposedException("Common class object is already disposed.");
            }
        }

        public int ExecuteNonQuery(string query)
        {
            if (!this.IsDisposed)
            {
                this._command.CommandText = query;

                int effectedRecords = 0;
                try
                {
                    this._connection.Open();
                    effectedRecords = this._command.ExecuteNonQuery();
                }
                finally
                {
                    this._connection.Close();
                }

                return effectedRecords;
            }
            else
            {
                throw new ObjectDisposedException("Common class object is already disposed.");
            }
        }

        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            if (!this.IsDisposed)
            {
                this._command.CommandText = query;
                foreach (SqlParameter parameter in parameters)
                {
                    this._command.Parameters.Add(parameter);
                }

                int effectedRecords = 0;
                try
                {
                    this._connection.Open();
                    effectedRecords = this._command.ExecuteNonQuery();
                }
                finally
                {
                    this._connection.Close();
                }

                return effectedRecords;
            }
            else
            {
                throw new ObjectDisposedException("Common class object is already disposed.");
            }
        }

        public object ExecuteScalar(string query)
        {
            if (!this.IsDisposed)
            {
                this._command.CommandText = query;

                this._connection.Open();
                object scalarValue = this._command.ExecuteScalar();
                this._connection.Close();

                return scalarValue;
            }
            else
            {
                throw new ObjectDisposedException("Common class object is already disposed.");
            }
        }

        public object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            if (!this.IsDisposed)
            {
                this._command.CommandText = query;
                foreach (SqlParameter parameter in parameters)
                {
                    this._command.Parameters.Add(parameter);
                }

                object scalarValue = null;
                try
                {
                    this._connection.Open();
                    scalarValue = this._command.ExecuteScalar();
                }
                finally
                {
                    this._connection.Close();
                }

                return scalarValue;
            }
            else
            {
                throw new ObjectDisposedException("Common class object is already disposed.");
            }
        }

        #region IDisposable Members
        public void Dispose()
        {
            lock (this) // Make it thread safe.
            {
                if (!this.IsDisposed)
                {
                    this.CleanUp();
                    this._isDisposed = true;
                    GC.SuppressFinalize(this); // No longer need finalizing.
                } 
            }
        }
        #endregion

        // Derive class can override this method to implement specific logic.
        protected virtual void CleanUp()
        {
            if (this._connection != null)
            {
                this._connection.Dispose(); 
            }

            if (this._command != null)
            {
                this._command.Dispose(); 
            }

            if (this._reader != null)
            {
                this._reader.Dispose(); 
            }
        }
    }
}
