// -----------------------------------------------------------------------------+
// File Name: ICustomer.cs
// Description: This file containing the service contract of POCO Customers class.
// Developed By: Arnab Roy Chowdhury.
// Date: 2nd March 2012.
// -----------------------------------------------------------------------------+

namespace Northwind.Poco
{
    /// <summary>
    /// The service contract of POCO Customers class.
    /// </summary>
    public interface ICustomer
    {
        /// <summary>
        /// Gets or sets the CustomerId.
        /// </summary>
        /// <value>The customer id.</value>
        string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the CompanyName.
        /// </summary>
        /// <value>The company name.</value>
        string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the ContactName.
        /// </summary>
        /// <value>The contact name.</value>
        string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the ContactTitle.
        /// </summary>
        /// <value>The contact title.</value>
        string ContactTitle { get; set; }

        /// <summary>
        /// Gets or sets the Address.
        /// </summary>
        /// <value>The address.</value>
        string Address { get; set; }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        /// <value>The city.</value>
        string City { get; set; }

        /// <summary>
        /// Gets or sets the Region.
        /// </summary>
        /// <value>The region.</value>
        string Region { get; set; }

        /// <summary>
        /// Gets or sets the PostalCode.
        /// </summary>
        /// <value>The postal code.</value>
        string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        /// <value>The country.</value>
        string Country { get; set; }

        /// <summary>
        /// Gets or sets the Phone number.
        /// </summary>
        /// <value>The phone number.</value>
        string Phone { get; set; }

        /// <summary>
        /// Gets or sets the Fax.
        /// </summary>
        /// <value>The fax number.</value>
        string Fax { get; set; }
    }
}
