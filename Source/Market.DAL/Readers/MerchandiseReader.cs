// --------------------------------------------------------------------------
// <copyright file="MerchandiseReader.cs" company="MK inc.">
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
    /// Class represents a reader for Merchandise class.
    /// </summary>
    public class MerchandiseReader : ObjectReaderBase<Merchandise>
    {
        private static MerchandiseReader _reader;

        static MerchandiseReader() { _reader = new MerchandiseReader(); }

        private MerchandiseReader() { }

        /// <summary>
        /// Gets a Reader for Merchandise.
        /// </summary>
        public static MerchandiseReader Reader
        {
            get
            {
                return MerchandiseReader._reader;
            }
        }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">Merchandise instance.</param>
        /// <param name="isNew">Parameter that inditates if a Merchandise instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override DataRow GetDataRow(Merchandise item, bool isNew)
        {
            var row = Table.NewRow();
            if (!isNew)
            {
                row = (from m in Table.AsEnumerable()
                       where m["ID"].ToString() == item.ID.ToString()
                       select m)
                          .ToList<DataRow>()
                          .FirstOrDefault();
            }

            return row;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">Merchandise instance.</param>
        /// <param name="isNew">Parameter that inditates if a Merchandise instance is new.</param>
        public override void Save(Merchandise item, bool isNew)
        {
            MerchandiseMapper mapper = new MerchandiseMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of Merchandise items.</param>
        public override void Save(System.Collections.Generic.List<Merchandise> items)
        {
            foreach (Merchandise m in items)
                Save(m, m.IsNew);
        }

        /// <summary>
        /// Method delets Merchandise item.
        /// </summary>
        /// <param name="item">Merchandise instance.</param>
        public override void Delete(Merchandise item)
        {
            MerchandiseMapper mapper = new MerchandiseMapper();
            DataRow rowToErase = mapper.UnMap(item, GetDataRow(item, false));
            rowToErase.Delete();
            Update(rowToErase, item.IsNew);
        }

        /// <summary>
        /// Method delets list of Merchandise items.
        /// </summary>
        /// <param name="items">List of Merchandise items.</param>
        public override void Delete(System.Collections.Generic.List<Merchandise> items)
        {
            foreach (var m in items)
                m.Delete();
        }

        /// <summary>
        /// Method gets a mapper for Merchandise.
        /// </summary>
        /// <returns>Mapper for Merchandise.</returns>
        protected override MapperBase<Merchandise> GetMapper()
        { return new MerchandiseMapper(); }
    }
}