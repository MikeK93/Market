// --------------------------------------------------------------------------
// <copyright file="CustomerSelectedItemsReader.cs" company="MK inc.">
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
    /// Class represents a reader for CustomerSelectedItems class.
    /// </summary>
    public class CustomerSelectedItemsReader : ObjectReaderBase<CustomerSelectedItems>
    {
        private static CustomerSelectedItemsReader _reader;

        static CustomerSelectedItemsReader() { _reader = new CustomerSelectedItemsReader(); }

        private CustomerSelectedItemsReader() { }

        /// <summary>
        /// Gets a Reader for CustomerSelectedItems.
        /// </summary>
        public static CustomerSelectedItemsReader Reader
        {
            get { return CustomerSelectedItemsReader._reader; }
        }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">CustomerSelectedItems instance.</param>
        /// <param name="isNew">Parameter that inditates if a CustomerSelectedItems instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override System.Data.DataRow GetDataRow(CustomerSelectedItems item, bool isNew)
        {
            var row = Table.NewRow();
            if (!isNew)
            {
                row = (from csi in Table.AsEnumerable()
                       where csi["ID"].ToString() == item.ID.ToString()
                       select csi)
                           .ToList<DataRow>()
                           .First();
            }

            return row;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">CustomerSelectedItems instance.</param>
        /// <param name="isNew">Parameter that inditates if a CustomerSelectedItems instance is new.</param>
        public override void Save(CustomerSelectedItems item, bool isNew)
        {
            CustomerSelectedItemsMapper mapper = new CustomerSelectedItemsMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of CustomerSelectedItems items.</param>
        public override void Save(List<CustomerSelectedItems> items)
        {
            foreach (var item in items)
                Save(item, item.IsNew);
        }

        /// <summary>
        /// Method delets CustomerSelectedItems item.
        /// </summary>
        /// <param name="item">CustomerSelectedItems instance.</param>
        public override void Delete(CustomerSelectedItems item)
        {
            CustomerSelectedItemsMapper mapper = new CustomerSelectedItemsMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, false));
            row.Delete();
            Update(row, false);
        }

        /// <summary>
        /// Method delets list of CustomerSelectedItems items.
        /// </summary>
        /// <param name="items">List of CustomerSelectedItems items.</param>
        public override void Delete(List<CustomerSelectedItems> items)
        {
            foreach (var item in items)
                Delete(item);
        }

        /// <summary>
        /// Method gets a mapper for CustomerSelectedItems.
        /// </summary>
        /// <returns>Mapper for CustomerSelectedItems.</returns>
        protected override MapperBase<CustomerSelectedItems> GetMapper()
        { return new CustomerSelectedItemsMapper(); }
    }
}