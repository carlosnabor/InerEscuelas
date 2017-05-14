// -------------------------------------------------------------------------------------------------+
// File Name: SqlDataReaderExtention.cs
// Description: This file containing the SqlDataReaderExtention class which is holding the extention 
//              method of SqlDataReader.
// Developed By: Arnab Roy Chowdhury.
// Date: 25th February 2012.
// -------------------------------------------------------------------------------------------------+

using System.Collections.Generic;
using System.Data.SqlClient;

namespace Northwind.Dal.Extentions
{
    // Having the extention method of SqlDataReader.
    internal static class SqlDataReaderExtention
    {
        // Get customer collection from data reader.
        public static List<Northwind.Poco.ICustomer> GetCustomers(this SqlDataReader reader)
        {
            List<Northwind.Poco.ICustomer> customers = new List<Northwind.Poco.ICustomer>();
            
            if (reader.HasRows)
            {
                int customerIdOrdinal = reader.GetOrdinal("CustomerID");
                int companyNameOrdinal = reader.GetOrdinal("CompanyName");
                int contactNameOrdinal = reader.GetOrdinal("ContactName");
                int contactTitleOrdinal = reader.GetOrdinal("ContactTitle");
                int addressOrdinal = reader.GetOrdinal("Address");
                int cityOrdinal = reader.GetOrdinal("City");
                int regionOrdinal = reader.GetOrdinal("Region");
                int postalCodeOrdinal = reader.GetOrdinal("PostalCode");
                int countryOrdinal = reader.GetOrdinal("Country");
                int phoneOrdinal = reader.GetOrdinal("Phone");
                int faxOrdinal = reader.GetOrdinal("Fax");

                while (reader.Read())
                {
                    Northwind.Poco.ICustomer customer = new Northwind.Poco.Customer();

                    customer.CustomerId = GetStringOrEmpty(reader, customerIdOrdinal);
                    customer.CompanyName = GetStringOrEmpty(reader, companyNameOrdinal);
                    customer.ContactName = GetStringOrEmpty(reader, contactNameOrdinal);
                    customer.ContactTitle = GetStringOrEmpty(reader, contactTitleOrdinal);
                    customer.Address = GetStringOrEmpty(reader, addressOrdinal);
                    customer.City = GetStringOrEmpty(reader, cityOrdinal);
                    customer.Region = GetStringOrEmpty(reader, regionOrdinal);
                    customer.PostalCode = GetStringOrEmpty(reader, postalCodeOrdinal);
                    customer.Country = GetStringOrEmpty(reader, countryOrdinal);
                    customer.Phone = GetStringOrEmpty(reader, phoneOrdinal);
                    customer.Fax = GetStringOrEmpty(reader, faxOrdinal);

                    customers.Add(customer);
                }
            }

            return customers;
        }

        // Return the string value if present or empty string if null. 
        private static string GetStringOrEmpty(SqlDataReader reader, int ordinal)
        {
            return !reader.IsDBNull(ordinal) ? reader.GetString(ordinal) : string.Empty;
        }
    }
}
