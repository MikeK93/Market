// --------------------------------------------------------------------------
// <copyright file="CustomerReader.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Core;
using Market.Entities;
using Market.Mappers;

namespace Market.Readers
{
    /// <summary>
    /// Class represents a reader for Customer class.
    /// </summary>
    public class CustomerReader : ObjectReaderBase<Customer>, IRoleReader<Customer>
    {
        private static CustomerReader _reader;

        static CustomerReader() { _reader = new CustomerReader(); }

        private CustomerReader() { }

        /// <summary>
        /// Gets a Reader for Customer.
        /// </summary>
        public static CustomerReader Reader
        {
            get { return CustomerReader._reader; }
        }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">Customer instance.</param>
        /// <param name="isNew">Parameter that inditates if a Customer instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override DataRow GetDataRow(Customer item, bool isNew)
        {
            var row = Table.NewRow();
            if (!isNew)
            {
                row = (from c in Table.AsEnumerable()
                       where c["ID"].ToString() == item.ID.ToString()
                       select c)
                           .ToList<DataRow>()
                           .FirstOrDefault();
            }

            return row;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">Customer instance.</param>
        /// <param name="isNew">Parameter that inditates if a Customer instance is new.</param>
        public override void Save(Customer item, bool isNew)
        {
            CustomerMapper mapper = new CustomerMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of Customer items.</param>
        public override void Save(List<Customer> items)
        {
            foreach (var item in items)
                Save(item, item.IsNew);
        }

        /// <summary>
        /// Method delets Customer item.
        /// </summary>
        /// <param name="item">Customer instance.</param>
        public override void Delete(Customer item)
        { throw new NotImplementedException(); }

        /// <summary>
        /// Method delets list of Customer items.
        /// </summary>
        /// <param name="items">List of Customer items.</param>
        public override void Delete(List<Customer> items)
        { throw new NotImplementedException(); }

        /// <summary>
        /// Method gets a customer by his/her user account.
        /// </summary>
        /// <param name="user">User attached to customer.</param>
        /// <returns>Customer instance.</returns>
        public Customer InitializeRole(User user)
        { return Reader.GetByQuery("UserID='" + user.ID + "'").ToList().First(); }

        /// <summary>
        /// Method gets a mapper for Customer.
        /// </summary>
        /// <returns>Mapper for Customer.</returns>
        protected override MapperBase<Customer> GetMapper()
        { return new CustomerMapper(); }
    }
}