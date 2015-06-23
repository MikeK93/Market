// --------------------------------------------------------------------------
// <copyright file="SpotSDMReader.cs" company="MK inc.">
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
    /// Class represents a reader for SpotSDM class.
    /// </summary>
    public class SpotSDMReader : ObjectReaderBase<SpotSDM>
    {
        private static SpotSDMReader _reader;

        static SpotSDMReader() { _reader = new SpotSDMReader(); }

        private SpotSDMReader() { }

        /// <summary>
        /// Gets a Reader for SpotSDM.
        /// </summary>
        public static SpotSDMReader Reader { get { return SpotSDMReader._reader; } }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">SpotSDM instance.</param>
        /// <param name="isNew">Parameter that inditates if a SpotSDM instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override System.Data.DataRow GetDataRow(SpotSDM item, bool isNew)
        {
            var row = Table.NewRow();
            if (!isNew)
            {
                row = (from ssdm in Table.AsEnumerable()
                       where ssdm["ID"].ToString() == item.ID.ToString()
                       select ssdm).ToList().First();
            }

            return row;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">SpotSDM instance.</param>
        /// <param name="isNew">Parameter that inditates if a SpotSDM instance is new.</param>
        public override void Save(SpotSDM item, bool isNew)
        {
            SpotSDMMapper mapper = new SpotSDMMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, item.IsNew));
            Update(row, item.IsNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of SpotSDM items.</param>
        public override void Save(List<SpotSDM> items)
        {
            foreach (var item in items)
                Save(item, item.IsNew);
        }

        /// <summary>
        /// Method delets SpotSDM item.
        /// </summary>
        /// <param name="item">SpotSDM instance.</param>
        public override void Delete(SpotSDM item)
        {
            SpotSDMMapper mapper = new SpotSDMMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, item.IsNew));
            row.Delete();
            Update(row, item.IsNew);
        }

        /// <summary>
        /// Method delets list of SpotSDM items.
        /// </summary>
        /// <param name="items">List of SpotSDM items.</param>
        public override void Delete(List<SpotSDM> items)
        {
            foreach (var item in items)
                Delete(item);
        }

        /// <summary>
        /// Method gets a mapper for SpotSDM.
        /// </summary>
        /// <returns>Mapper for SpotSDM.</returns>
        protected override MapperBase<SpotSDM> GetMapper()
        { return new SpotSDMMapper(); }
    }
}