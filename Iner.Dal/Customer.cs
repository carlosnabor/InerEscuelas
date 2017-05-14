// --------------------------------------------------------------------------+
// File Name: Customer.cs
// Description: This file containing the Data Access Layer of Customers class.
// Developed By: Arnab Roy Chowdhury.
// Date: 25th February 2012.
// --------------------------------------------------------------------------+

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Northwind.Dal.Extentions;
using Poco = Northwind.Poco;

namespace Northwind.Dal
{
    /// <summary>
    /// Data Access Layer of customer.
    /// </summary>
    public class Customer : ICustomer
    {
        private Common _common;
        private bool _isDisposed; 

        /// <summary>
        /// Creates an instence of customer. This is a 
        /// parameterised constructor.
        /// </summary>
        public Customer()
        {
            this._common = new Common();
            this._isDisposed = false;
        }

        /// <summary>
        /// Gets the state of the object weather it is disposed or not.
        /// </summary>
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

        /// <summary>
        /// Cleans up the unmanaged recources. Derive class can override this method to implement 
        /// specific logic.
        /// </summary>
        protected virtual void CleanUp()
        {
            this._common.Dispose();
        }

        #region ICustomer Members
        /// <summary>
        /// GetData all customer data.
        /// </summary>
        /// <returns>The customer collection.</returns>
        /// <exception cref="System.InvalidCastException">
        /// The specified cast is not valid.
        /// </exception>
        /// <exception cref="System.IndexOutOfRangeException">
        /// The index is out of range.
        /// </exception>
        /// <exception cref="System.ObjectDisposedException">
        /// The object is disposed.
        /// </exception>
        public IList<Poco::ICustomer> GetData()
        {
            if (!this.IsDisposed)
            {
                List<Northwind.Poco.ICustomer> customers;

                SqlDataReader reader = this._common.ExecuteReader("SELECT * FROM Customers");
                customers = reader.GetCustomers(); // Thanks to extention method.

                return customers; 
            }
            else
            {
                throw new ObjectDisposedException("Dal.Customer object is already disposed.");
            }
        }

        /// <summary>
        /// GetData customer data by customer id.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <returns>The customer collection.</returns>
        /// <exception cref="System.InvalidCastException">
        /// The specified cast is not valid.
        /// </exception>
        /// <exception cref="System.IndexOutOfRangeException">
        /// The index is out of range.
        /// </exception>
        /// <exception cref="System.ObjectDisposedException">
        /// The object is disposed.
        /// </exception>
        public IList<Poco::ICustomer> GetData(string customerId)
        {
            if (!this.IsDisposed)
            {
                SqlParameter customerIdParameter = new SqlParameter("@CustomerID", SqlDbType.NChar, 5)
                {
                    Value = customerId,
                    Direction = ParameterDirection.Input
                };

                List<Northwind.Poco.ICustomer> customers;
                SqlDataReader reader = this._common.ExecuteReader
                    ("SELECT * FROM Customers WHERE CustomerID = @CustomerID", customerIdParameter);
                customers = reader.GetCustomers(); // Thanks to extention method.

                return customers; 
            }
            else
            {
                throw new ObjectDisposedException("Dal.Customer object is already disposed.");
            }
        }

        /// <summary>
        /// Creates a new customer record.
        /// </summary>
        /// <param name="newCustomer">The customer intence.</param>
        /// <returns>The number of effected records.</returns>
        /// <exception cref="System.Data.SqlClient.SqlException">
        /// An exception occurred while executing the command against  a locked row. This exception is 
        /// not generated when you are using Microsoft .NET Framework version 1.0.
        /// </exception>
        /// <exception cref="System.ObjectDisposedException">
        /// The object is disposed.
        /// </exception>
        public int Create(Poco::ICustomer newCustomer)
        {
            if (!this.IsDisposed)
            {
                SqlParameter[] parameters = GetParameters(newCustomer);
                StringBuilder insertCommand = GetInsertCommand();
                int effectedRecords = this._common.ExecuteNonQuery(insertCommand.ToString(), parameters);

                return effectedRecords;
            }
            else
            {
                throw new ObjectDisposedException("Dal.Customer object is already disposed.");
            }
        }

        /// <summary>
        /// Update an existing customer record.
        /// </summary>
        /// <param name="existingCustomer">The existing customer instence.</param>
        /// <returns>The number of effected records.</returns>
        /// <exception cref="System.Data.SqlClient.SqlException">
        /// An exception occurred while executing the command against a locked row. This exception is
        /// not generated when you are using Microsoft .NET Framework version 1.0.
        /// </exception>
        /// <exception cref="System.ObjectDisposedException">
        /// The object is disposed.
        /// </exception>
        public int Update(Poco::ICustomer existingCustomer)
        {
            if (!this.IsDisposed)
            {
                SqlParameter[] parameters = GetParameters(existingCustomer);
                StringBuilder updateCommand = GetUpdateCommand();
                int effectedRecords = this._common.ExecuteNonQuery(updateCommand.ToString(), parameters);

                return effectedRecords;
            }
            else
            {
                throw new ObjectDisposedException("Dal.Customer object is already disposed.");
            }
        }

        /// <summary>
        /// Delete a customer record.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <returns>The number of effected records.</returns>
        /// <exception cref="System.Data.SqlClient.SqlException">
        /// An exception occurred while executing the command against a locked row. This exception is 
        /// not generated when you are using Microsoft .NET Framework version 1.0.
        /// </exception>
        /// <exception cref="System.ObjectDisposedException">
        /// The object is disposed.
        /// </exception>
        public int Delete(string customerId)
        {
            if (!this.IsDisposed)
            {
                SqlParameter customerIdParameter = new SqlParameter("@CustomerID", SqlDbType.NChar, 5)
                {
                    Value = customerId,
                    Direction = ParameterDirection.Input
                };

                int effectedRecords = this._common.ExecuteNonQuery
                    ("DELETE Customers WHERE CustomerID = @CustomerId", customerIdParameter);

                return effectedRecords;
            }
            else
            {
                throw new ObjectDisposedException("Dal.Customer object is already disposed.");
            }
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Dispose the instence.
        /// </summary>
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

        #region Helpers
        private static SqlParameter[] GetParameters(Poco::ICustomer newCustomer)
        {
            SqlParameter customerIdParameter = new SqlParameter("@CustomerID", SqlDbType.NChar, 5)
            {
                Value = newCustomer.CustomerId != null ? newCustomer.CustomerId : string.Empty,
                Direction = ParameterDirection.Input
            };

            SqlParameter companyNameParameter = new SqlParameter("@CompanyName", SqlDbType.NVarChar, 40)
            {
                Value = newCustomer.CompanyName != null ? newCustomer.CompanyName : string.Empty,
                Direction = ParameterDirection.Input
            };

            SqlParameter contactNameParameter = new SqlParameter("@ContactName", SqlDbType.NVarChar, 30)
            {
                Value = newCustomer.ContactName != null ? newCustomer.ContactName : string.Empty,
                Direction = ParameterDirection.Input
            };

            SqlParameter contactTitleParameter = new SqlParameter("@ContactTitle", SqlDbType.NVarChar, 30)
            {
                Value = newCustomer.ContactTitle != null ? newCustomer.ContactTitle : string.Empty,
                Direction = ParameterDirection.Input
            };

            SqlParameter addressParameter = new SqlParameter("@Address", SqlDbType.NVarChar, 60)
            {
                Value = newCustomer.Address != null ? newCustomer.Address : string.Empty,
                Direction = ParameterDirection.Input
            };

            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar, 15)
            {
                Value = newCustomer.City != null ? newCustomer.City : string.Empty,
                Direction = ParameterDirection.Input
            };

            SqlParameter regionParameter = new SqlParameter("@Region", SqlDbType.NVarChar, 15)
            {
                Value = newCustomer.Region != null ? newCustomer.Region : string.Empty,
                Direction = ParameterDirection.Input
            };

            SqlParameter postalCodeParameter = new SqlParameter("@PostalCode", SqlDbType.NVarChar, 10)
            {
                Value = newCustomer.PostalCode != null ? newCustomer.PostalCode : string.Empty,
                Direction = ParameterDirection.Input
            };

            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar, 15)
            {
                Value = newCustomer.Country != null ? newCustomer.Country : string.Empty,
                Direction = ParameterDirection.Input
            };

            SqlParameter phoneParameter = new SqlParameter("@Phone", SqlDbType.NVarChar, 24)
            {
                Value = newCustomer.Phone != null ? newCustomer.Phone : string.Empty,
                Direction = ParameterDirection.Input
            };

            SqlParameter faxParameter = new SqlParameter("@Fax", SqlDbType.NVarChar, 24)
            {
                Value = newCustomer.Fax != null ? newCustomer.Fax : string.Empty,
                Direction = ParameterDirection.Input
            };

            SqlParameter[] parameters = 
            {
                customerIdParameter,
                companyNameParameter,
                contactNameParameter,
                contactTitleParameter,
                addressParameter,
                cityParameter,
                countryParameter,
                postalCodeParameter,
                phoneParameter,
                faxParameter,
                regionParameter
            };

            return parameters;
        }

        private static StringBuilder GetInsertCommand()
        {
            StringBuilder insertCommand = new StringBuilder();

            insertCommand = insertCommand.Append("INSERT INTO Customers");
            insertCommand = insertCommand.Append("(CustomerId, CompanyName, ContactName, ContactTitle, ");
            insertCommand = insertCommand.Append("Country, Address, City, Region, PostalCode, Phone, Fax)");
            insertCommand = insertCommand.Append("VALUES (@CustomerId, @CompanyName, @ContactName,");
            insertCommand = insertCommand.Append("@ContactTitle, @Country, @Address, @City, @Region, ");
            insertCommand = insertCommand.Append("@PostalCode, @Phone, @Fax)");

            return insertCommand;
        }

        private static StringBuilder GetUpdateCommand()
        {
            StringBuilder insertCommand = new StringBuilder();

            insertCommand = insertCommand.Append("UPDATE Customers ");
            insertCommand = insertCommand.Append("SET CompanyName = @CompanyName, ");
            insertCommand = insertCommand.Append("ContactName = @ContactName, ContactTitle = @ContactTitle, ");
            insertCommand = insertCommand.Append("Country = @Country, Address = @Address, City = @City, ");
            insertCommand = insertCommand.Append("Region = @Region, PostalCode = @PostalCode, Phone = @Phone, Fax = @Fax ");
            insertCommand = insertCommand.Append("WHERE CustomerId = @CustomerId");

            return insertCommand;
        }
        #endregion
    }
}
