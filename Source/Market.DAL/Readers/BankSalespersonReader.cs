// --------------------------------------------------------------------------
// <copyright file="BankSalespersonReader.cs" company="MK inc.">
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
    /// Class represents a reader for BankSalesperson class.
    /// </summary>
    public class BankSalespersonReader : ObjectReaderBase<BankSalesperson>
    {
        private static BankSalespersonReader _reader;

        static BankSalespersonReader() { _reader = new BankSalespersonReader(); }

        private BankSalespersonReader() { }

        /// <summary>
        /// Gets a Reader for BankSalesperson.
        /// </summary>
        public static BankSalespersonReader Reader
        {
            get { return BankSalespersonReader._reader; }
        }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">BankSalesperson instance.</param>
        /// <param name="isNew">Parameter that inditates if a BankSalesperson instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override System.Data.DataRow GetDataRow(BankSalesperson item, bool isNew)
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
        /// <param name="item">BankSalesperson instance.</param>
        /// <param name="isNew">Parameter that inditates if a BankSalesperson instance is new.</param>
        public override void Save(BankSalesperson item, bool isNew)
        {
            BankSalespersonMapper mapper = new BankSalespersonMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of BankSalesperson items.</param>
        public override void Save(List<BankSalesperson> items)
        {
            foreach (BankSalesperson bd in items)
                Save(bd, bd.IsNew);
        }

        /// <summary>
        /// Method delets BankSalesperson item.
        /// </summary>
        /// <param name="item">BankSalesperson instance.</param>
        public override void Delete(BankSalesperson item)
        {
            BankSalespersonMapper mapper = new BankSalespersonMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, false));
            row.Delete();
            Update(row, false);
        }

        /// <summary>
        /// Method delets list of BankSalesperson items.
        /// </summary>
        /// <param name="items">List of BankSalesperson items.</param>
        public override void Delete(List<BankSalesperson> items)
        {
            foreach (BankSalesperson bd in items)
                Delete(bd);
        }

        /// <summary>
        /// Method gets a mapper for BankSalesperson.
        /// </summary>
        /// <returns>Mapper for BankSalesperson.</returns>
        protected override MapperBase<BankSalesperson> GetMapper()
        { return new BankSalespersonMapper(); }
    }
}