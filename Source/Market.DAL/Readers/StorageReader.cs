// --------------------------------------------------------------------------
// <copyright file="StorageReader.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Market.Core;
using Market.Entities;
using Market.Mappers;

namespace Market.Readers
{
    /// <summary>
    /// Class represents a reader for Storage class.
    /// </summary>
    public class StorageReader : ObjectReaderBase<Storage>
    {
        private static StorageReader _reader;

        static StorageReader() { _reader = new StorageReader(); }

        private StorageReader() { }

        /// <summary>
        /// Gets a Reader for Storage.
        /// </summary>
        public static StorageReader Reader { get { return StorageReader._reader; } }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">Storage instance.</param>
        /// <param name="isNew">Parameter that inditates if a Storage instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override DataRow GetDataRow(Storage item, bool isNew)
        {
            var row = Table.NewRow();
            if (!isNew)
            {
                row = (from s in Table.AsEnumerable()
                       where s["ID"].ToString() == item.ID.ToString()
                       select s)
                          .ToList<DataRow>()
                          .FirstOrDefault();
            }

            return row;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">Storage instance.</param>
        /// <param name="isNew">Parameter that inditates if a Storage instance is new.</param>
        public override void Save(Storage item, bool isNew)
        {
            StorageMapper mapper = new StorageMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of Storage items.</param>
        public override void Save(List<Storage> items)
        {
            foreach (Storage s in items)
                Save(s, s.IsNew);
        }

        /// <summary>
        /// Method delets Storage item.
        /// </summary>
        /// <param name="item">Storage instance.</param>
        public override void Delete(Storage item)
        { throw new NotImplementedException(); }

        /// <summary>
        /// Method delets list of Storage items.
        /// </summary>
        /// <param name="items">List of Storage items.</param>
        public override void Delete(List<Storage> items)
        { throw new NotImplementedException(); }

        /// <summary>
        /// Method gets a mapper for Storage.
        /// </summary>
        /// <returns>Mapper for Storage.</returns>
        protected override MapperBase<Storage> GetMapper()
        { return new StorageMapper(); }
    }
}