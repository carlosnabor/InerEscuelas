// -------------------------------------------------------------+
// File Name: Customer.cs
// Description: This file containing the POCO of Customers class.
// Developed By: Arnab Roy Chowdhury.
// Date: 25th February 2012.
// -------------------------------------------------------------+

namespace Northwind.Poco
{
    /// <summary>
    /// POCO of Customer class.
    /// </summary>
    public class Customer : ICustomer
    {
        #region ICustomer Members.
        /// <summary>
        /// Gets or sets the CustomerId.
        /// </summary>
        /// <value>The customer id.</value>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the CompanyName.
        /// </summary>
        /// <value>The company name.</value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the ContactName.
        /// </summary>
        /// <value>The contact name.</value>
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the ContactTitle.
        /// </summary>
        /// <value>The contact title.</value>
        public string ContactTitle { get; set; }

        /// <summary>
        /// Gets or sets the Address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the Region.
        /// </summary>
        /// <value>The region.</value>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the PostalCode.
        /// </summary>
        /// <value>The postal code.</value>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the Phone number.
        /// </summary>
        /// <value>The phone number.</value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the Fax.
        /// </summary>
        /// <value>The fax number.</value>
        public string Fax { get; set; }
        #endregion

        /// <summary>
        /// Creates a new instance of Customer.
        /// </summary>
        public Customer()
        {
            this.CustomerId = string.Empty;
            this.CompanyName = string.Empty;
            this.ContactName = string.Empty;
            this.ContactTitle = string.Empty;
            this.Address = string.Empty;
            this.Country = string.Empty;
            this.Region = string.Empty;
            this.City = string.Empty;
            this.PostalCode = string.Empty;
            this.Phone = string.Empty;
            this.Fax = string.Empty;
        }

        /// <summary>
        /// Creates a new instance of Customer.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <param name="companyName">The company name.</param>
        /// <param name="contactName">The contact name.</param>
        /// <param name="contactTitle">The contact title.</param>
        /// <param name="address">The address.</param>
        /// <param name="region">The region.</param>
        /// <param name="country">The country.</param>
        /// <param name="city">The city.</param>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="phone">The phone number.</param>
        /// <param name="fax">The fax number.</param>
        public Customer(string customerId, string companyName, string contactName, string contactTitle,
            string address, string region, string country, string city, string postalCode, string phone,
            string fax)
        {
            this.CustomerId = customerId;
            this.CompanyName = companyName;
            this.ContactName = contactName;
            this.ContactTitle = contactTitle;
            this.Address = address;
            this.Country = country;
            this.Region = region;
            this.City = city;
            this.PostalCode = postalCode;
            this.Phone = phone;
            this.Fax = fax;
        }
    }
}
