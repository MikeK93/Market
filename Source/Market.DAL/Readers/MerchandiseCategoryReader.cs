// --------------------------------------------------------------------------
// <copyright file="MerchandiseCategoryReader.cs" company="MK inc.">
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
    /// Class represents a reader for MerchandiseCategory class.
    /// </summary>
    public class MerchandiseCategoryReader : ObjectReaderBase<MerchandiseCategory>
    {
        private static MerchandiseCategoryReader _reader;

        static MerchandiseCategoryReader() { _reader = new MerchandiseCategoryReader(); }

        private MerchandiseCategoryReader() { }

        /// <summary>
        /// Gets a Reader for MerchandiseCategory.
        /// </summary>
        public static MerchandiseCategoryReader Reader { get { return MerchandiseCategoryReader._reader; } }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">MerchandiseCategory instance.</param>
        /// <param name="isNew">Parameter that inditates if a MerchandiseCategory instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override System.Data.DataRow GetDataRow(MerchandiseCategory item, bool isNew)
        {
            var row = Table.NewRow();
            if (!isNew)
            {
                row = (from mc in Table.AsEnumerable()
                       where mc["ID"].ToString() == item.ID.ToString()
                       select mc)
                           .ToList<DataRow>()
                           .First();
            }

            return row;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">MerchandiseCategory instance.</param>
        /// <param name="isNew">Parameter that inditates if a MerchandiseCategory instance is new.</param>
        public override void Save(MerchandiseCategory item, bool isNew)
        {
            MerchandiseCategoryMapper mapper = new MerchandiseCategoryMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of MerchandiseCategory items.</param>
        public override void Save(List<MerchandiseCategory> items)
        {
            foreach (MerchandiseCategory mc in items)
                Save(mc, mc.IsNew);
        }

        /// <summary>
        /// Method delets MerchandiseCategory item.
        /// </summary>
        /// <param name="item">MerchandiseCategory instance.</param>
        public override void Delete(MerchandiseCategory item)
        {
            MerchandiseCategoryMapper mapper = new MerchandiseCategoryMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, false));
            row.Delete();
            Update(row, false);
        }

        /// <summary>
        /// Method delets list of MerchandiseCategory items.
        /// </summary>
        /// <param name="items">List of MerchandiseCategory items.</param>
        public override void Delete(List<MerchandiseCategory> items)
        {
            foreach (MerchandiseCategory mc in items)
                Delete(mc);
        }

        /// <summary>
        /// Method gets a mapper for MerchandiseCategory.
        /// </summary>
        /// <returns>Mapper for MerchandiseCategory.</returns>
        protected override MapperBase<MerchandiseCategory> GetMapper()
        { return new MerchandiseCategoryMapper(); }
    }
}