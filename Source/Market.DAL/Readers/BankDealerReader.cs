// --------------------------------------------------------------------------
// <copyright file="BankDealerReader.cs" company="MK inc.">
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
    /// Class represents a reader for BankDealer class.
    /// </summary>
    public class BankDealerReader : ObjectReaderBase<BankDealer>
    {
        private static BankDealerReader _reader;

        static BankDealerReader()
        { _reader = new BankDealerReader(); }

        private BankDealerReader() { }

        /// <summary>
        /// Gets a Reader for BankDealer.
        /// </summary>
        public static BankDealerReader Reader
        {
            get { return BankDealerReader._reader; }
        }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">BankDealer instance.</param>
        /// <param name="isNew">Parameter that inditates if a BankDealer instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override System.Data.DataRow GetDataRow(BankDealer item, bool isNew)
        {
            var row = Table.NewRow();
            if (!isNew)
            {
                row = (from dm in Table.AsEnumerable()
                       where dm["ID"].ToString() == item.ID.ToString()
                       select dm)
                           .ToList<DataRow>()
                           .First();
            }

            return row;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">BankDealer instance.</param>
        /// <param name="isNew">Parameter that inditates if a BankDealer instance is new.</param>
        public override void Save(BankDealer item, bool isNew)
        {
            BankDealerMapper mapper = new BankDealerMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of BankDealer items.</param>
        public override void Save(List<BankDealer> items)
        {
            foreach (BankDealer bd in items)
                Save(bd, bd.IsNew);
        }

        /// <summary>
        /// Method delets BankDealer item.
        /// </summary>
        /// <param name="item">BankDealer instance.</param>
        public override void Delete(BankDealer item)
        {
            BankDealerMapper mapper = new BankDealerMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, false));
            row.Delete();
            Update(row, false);
        }

        /// <summary>
        /// Method delets list of BankDealer items.
        /// </summary>
        /// <param name="items">List of BankDealer items.</param>
        public override void Delete(List<BankDealer> items)
        {
            foreach (BankDealer bd in items)
                Delete(bd);
        }

        /// <summary>
        /// Method gets a mapper for BankDealer.
        /// </summary>
        /// <returns>Mapper for BankDealer.</returns>
        protected override MapperBase<BankDealer> GetMapper()
        { return new BankDealerMapper(); }
    }
}