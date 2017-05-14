// ------------------------------------------------------------------------------------------+
// File Name: ICustomer.cs
// Description: This file containing the service contract interface of Business Logic Layer of 
//              Customers class.
// Developed By: Arnab Roy Chowdhury.
// Date: 26th February 2012.
// ------------------------------------------------------------------------------------------+

using System;
using System.Collections.Generic;
using Poco = Northwind.Poco;

namespace Northwind.Bll
{
    /// <summary>
    /// Service contract of customer BLL.
    /// </summary>
    public interface ICustomer : IDisposable
    {
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
        IList<Poco::ICustomer> GetData();

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
        IList<Poco::ICustomer> GetData(string customerId);

        /// <summary>
        /// Creates a new customer record.
        /// </summary>
        /// <param name="newCustomer">The customer intence.</param>
        /// <returns>The number of effected records.</returns>
        /// <exception cref="System.Data.SqlClient.SqlException">
        /// An exception occurred while executing the command against a locked row. This exception is 
        /// not generated when you are using Microsoft .NET Framework version 1.0.
        /// </exception>
        ///<exception cref="System.ObjectDisposedException">
        /// The object is disposed.
        /// </exception>
        int Create(Poco::ICustomer newCustomer);

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
        int Update(Poco::ICustomer existingCustomer);

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
        int Delete(string customerId);
    }
}
