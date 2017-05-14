// ----------------------------------------------------------------------+
// File Name: Customer.cs
// Description: This file containing the Business Logic of Customers class.
// Developed By: Arnab Roy Chowdhury.
// Date: 25th February 2012.
// ----------------------------------------------------------------------+

using System;
using System.Collections.Generic;
using Dal = Northwind.Dal;
using Poco = Northwind.Poco;

namespace Northwind.Bll
{
    /// <summary>
    /// Business Logic of Customer.
    /// </summary>
    public class Customer : ICustomer
    {
        private Dal::ICustomer _customer; // _customer is a Interface type to decouple the DAL.
        private bool _isDisposed;

        /// <summary>
        /// Creates a new instense of Customer. This is a 
        /// Parameterised constructer.
        /// </summary>
        public Customer()
        {
            this._customer = new Dal::Customer();
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
            this._customer.Dispose();
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
                return this._customer.GetData();
            }
            else
            {
                throw new ObjectDisposedException("Bll.Customer class object is already disposed.");
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
                return this._customer.GetData(customerId);
            }
            else
            {
                throw new ObjectDisposedException("Bll.Customer class object is already disposed.");
            }
        }

        /// <summary>
        /// Creates a new customer record.
        /// </summary>
        /// <param name="newCustomer">The customer intence.</param>
        /// <returns>The number of effected records.</returns>
        /// <exception cref="System.Data.SqlClient.SqlException">
        /// An exception occurred while executing the command against a locked row. This exception is 
        /// not generated when you are using Microsoft .NET Framework version 1.0.
        /// </exception>
        /// <exception cref="System.ObjectDisposedException">
        /// The object is disposed.
        /// </exception>
        public int Create(Poco::ICustomer newCustomer)
        {
            if (!this.IsDisposed)
            {
                return this._customer.Create(newCustomer);
            }
            else
            {
                throw new ObjectDisposedException("Bll.Customer class object is already disposed.");
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
                return this._customer.Update(existingCustomer);
            }
            else
            {
                throw new ObjectDisposedException("Bll.Customer class object is already disposed.");
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
                return this._customer.Delete(customerId);
            }
            else
            {
                throw new ObjectDisposedException("Bll.Customer class object is already disposed.");
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
    }
}
