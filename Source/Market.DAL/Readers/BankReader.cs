// --------------------------------------------------------------------------
// <copyright file="BankReader.cs" company="MK inc.">
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
    /// Class represents a reader for Bank class.
    /// </summary>
    public class BankReader : ObjectReaderBase<Bank>
    {
        private static BankReader _reader;

        static BankReader() { _reader = new BankReader(); }

        private BankReader() { }

        /// <summary>
        /// Gets a Reader for Bank.
        /// </summary>
        public static BankReader Reader
        {
            get { return BankReader._reader; }
        }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">Bank instance.</param>
        /// <param name="isNew">Parameter that inditates if a Bank instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override System.Data.DataRow GetDataRow(Bank item, bool isNew)
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
        /// <param name="item">Bank instance.</param>
        /// <param name="isNew">Parameter that inditates if a Bank instance is new.</param>
        public override void Save(Bank item, bool isNew)
        {
            BankMapper mapper = new BankMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of Bank items.</param>
        public override void Save(List<Bank> items)
        {
            foreach (Bank b in items)
                Save(b, b.IsNew);
        }

        /// <summary>
        /// Method delets Bank item.
        /// </summary>
        /// <param name="item">Bank instance.</param>
        public override void Delete(Bank item)
        { throw new NotImplementedException(); }

        /// <summary>
        /// Method delets list of Bank items.
        /// </summary>
        /// <param name="items">List of Bank items.</param>
        public override void Delete(List<Bank> items)
        { throw new NotImplementedException(); }

        /// <summary>
        /// Method gets a mapper for Bank.
        /// </summary>
        /// <returns>Mapper for Bank.</returns>
        protected override MapperBase<Bank> GetMapper()
        { return new BankMapper(); }
    }
}