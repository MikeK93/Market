// --------------------------------------------------------------------------
// <copyright file="SpotReader.cs" company="MK inc.">
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
    /// Class represents a reader for Spot class.
    /// </summary>
    public class SpotReader : ObjectReaderBase<Spot>
    {
        private static SpotReader _reader;

        static SpotReader() { _reader = new SpotReader(); }

        private SpotReader() { }

        /// <summary>
        /// Gets a Reader for Spot.
        /// </summary>
        public static SpotReader Reader { get { return SpotReader._reader; } }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">Spot instance.</param>
        /// <param name="isNew">Parameter that inditates if a Spot instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override DataRow GetDataRow(Spot item, bool isNew)
        {
            var row = Table.NewRow();
            if (!isNew)
            {
                row = (from s in Table.AsEnumerable()
                       where s["ID"].ToString() == item.ID.ToString()
                       select s)
                           .ToList<DataRow>()
                           .First();
            }

            return row;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">Spot instance.</param>
        /// <param name="isNew">Parameter that inditates if a Spot instance is new.</param>
        public override void Save(Spot item, bool isNew)
        {
            SpotMapper mapper = new SpotMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of Spot items.</param>
        public override void Save(List<Spot> items)
        {
            foreach (var item in items)
                Save(item, item.IsNew);
        }

        /// <summary>
        /// Method delets Spot item.
        /// </summary>
        /// <param name="item">Spot instance.</param>
        public override void Delete(Spot item)
        { throw new NotImplementedException(); }

        /// <summary>
        /// Method delets list of Spot items.
        /// </summary>
        /// <param name="items">List of Spot items.</param>
        public override void Delete(List<Spot> items)
        { throw new NotImplementedException(); }

        /// <summary>
        /// Method gets a mapper for Spot.
        /// </summary>
        /// <returns>Mapper for Spot.</returns>
        protected override MapperBase<Spot> GetMapper()
        { return new SpotMapper(); }
    }
}