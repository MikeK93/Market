// --------------------------------------------------------------------------
// <copyright file="DMReader.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System.Data;
using System.Linq;
using Market.Core;
using Market.Entities;
using Market.Mappers;

namespace Market.Readers
{
    /// <summary>
    /// Class represents a reader for DealerMerchandise class.
    /// </summary>
    public class DMReader : ObjectReaderBase<DM>
    {
        private static DMReader _reader;

        static DMReader()
        {
            DMReader.TableName = "DealerMerchandise";
            _reader = new DMReader();
        }

        private DMReader() { }

        /// <summary>
        /// Gets a Reader for DealerMerchandise.
        /// </summary>
        public static DMReader Reader
        {
            get
            {
                return DMReader._reader;
            }
        }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">DealerMerchandise instance.</param>
        /// <param name="isNew">Parameter that inditates if a DealerMerchandise instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override DataRow GetDataRow(DM item, bool isNew)
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
        /// <param name="item">DealerMerchandise instance.</param>
        /// <param name="isNew">Parameter that inditates if a DealerMerchandise instance is new.</param>
        public override void Save(DM item, bool isNew)
        {
            DMMapper mapper = new DMMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of DealerMerchandise items.</param>
        public override void Save(System.Collections.Generic.List<DM> items)
        {
            foreach (DM dm in items)
                Save(dm, dm.IsNew);
        }

        /// <summary>
        /// Method delets DealerMerchandise item.
        /// </summary>
        /// <param name="item">DealerMerchandise instance.</param>
        public override void Delete(DM item)
        {
            DMMapper mapper = new DMMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, false));
            row.Delete();
            Update(row, false);
        }

        /// <summary>
        /// Method delets list of DealerMerchandise items.
        /// </summary>
        /// <param name="items">List of DealerMerchandise items.</param>
        public override void Delete(System.Collections.Generic.List<DM> items)
        {
            foreach (DM dm in items)
                Delete(dm);
        }

        /// <summary>
        /// Method gets a mapper for DealerMerchandise.
        /// </summary>
        /// <returns>Mapper for DealerMerchandise.</returns>
        protected override MapperBase<DM> GetMapper()
        { return new DMMapper(); }
    }
}