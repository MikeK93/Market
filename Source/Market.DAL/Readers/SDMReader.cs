// --------------------------------------------------------------------------
// <copyright file="SDMReader.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using System.Linq;
using Market.Core;
using Market.Entities;
using Market.Mappers;

namespace Market.Readers
{
    /// <summary>
    /// Class represents a reader for SDM class.
    /// </summary>
    public class SDMReader : ObjectReaderBase<SDM>
    {
        private static SDMReader _reader;

        static SDMReader()
        {
            SDMReader.TableName = "SalespersonDealerMerchandise";
            _reader = new SDMReader();
        }

        private SDMReader() { }

        /// <summary>
        /// Gets a Reader for SDM.
        /// </summary>
        public static SDMReader Reader { get { return SDMReader._reader; } }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">SDM instance.</param>
        /// <param name="isNew">Parameter that inditates if a SDM instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override DataRow GetDataRow(SDM item, bool isNew)
        {
            var row = Table.NewRow();
            if (!isNew)
            {
                row = (from sdm in Table.AsEnumerable()
                       where sdm["ID"].ToString() == item.ID.ToString()
                       select sdm)
                           .ToList<DataRow>()
                           .First();
            }

            return row;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">SDM instance.</param>
        /// <param name="isNew">Parameter that inditates if a SDM instance is new.</param>
        public override void Save(SDM item, bool isNew)
        {
            SDMMapper mapper = new SDMMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of SDM items.</param>
        public override void Save(List<SDM> items)
        {
            foreach (var item in items)
                Save(item, item.IsNew);
        }

        /// <summary>
        /// Method delets SDM item.
        /// </summary>
        /// <param name="item">SDM instance.</param>
        public override void Delete(SDM item)
        {
            SDMMapper mapper = new SDMMapper();
            DataRow rowToErase = mapper.UnMap(item, GetDataRow(item, false));
            rowToErase.Delete();
            Update(rowToErase, item.IsNew);
        }

        /// <summary>
        /// Method delets list of SDM items.
        /// </summary>
        /// <param name="items">List of SDM items.</param>
        public override void Delete(List<SDM> items)
        {
            foreach (SDM sdm in items)
                Delete(sdm);
        }

        /// <summary>
        /// Method gets a mapper for SDM.
        /// </summary>
        /// <returns>Mapper for SDM.</returns>
        protected override MapperBase<SDM> GetMapper()
        { return new SDMMapper(); }
    }
}