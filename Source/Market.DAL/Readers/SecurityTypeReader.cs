// --------------------------------------------------------------------------
// <copyright file="SecurityTypeReader.cs" company="MK inc.">
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
    /// Class represents a reader for SecurityType class.
    /// </summary>
    public class SecurityTypeReader : ObjectReaderBase<SecurityType>
    {
        private static SecurityTypeReader _reader;

        static SecurityTypeReader() { _reader = new SecurityTypeReader(); }

        private SecurityTypeReader() { }

        /// <summary>
        /// Gets a Reader for SecurityType.
        /// </summary>
        public static SecurityTypeReader Reader { get { return SecurityTypeReader._reader; } }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">SecurityType instance.</param>
        /// <param name="isNew">Parameter that inditates if a SecurityType instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override System.Data.DataRow GetDataRow(SecurityType item, bool isNew)
        {
            var row = Table.NewRow();
            if (!isNew)
            {
                row = (from st in Table.AsEnumerable()
                       where st["ID"].ToString() == item.ID.ToString()
                       select st)
                           .ToList<DataRow>()
                           .First();
            }

            return row;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">SecurityType instance.</param>
        /// <param name="isNew">Parameter that inditates if a SecurityType instance is new.</param>
        public override void Save(SecurityType item, bool isNew)
        {
            SecurityTypeMapper mapper = new SecurityTypeMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of SecurityType items.</param>
        public override void Save(List<SecurityType> items)
        {
            foreach (var item in items)
                Save(item, item.IsNew);
        }

        /// <summary>
        /// Method delets SecurityType item.
        /// </summary>
        /// <param name="item">SecurityType instance.</param>
        public override void Delete(SecurityType item)
        { throw new NotImplementedException(); }

        /// <summary>
        /// Method delets list of SecurityType items.
        /// </summary>
        /// <param name="items">List of SecurityType items.</param>
        public override void Delete(List<SecurityType> items)
        { throw new NotImplementedException(); }

        /// <summary>
        /// Method gets a mapper for SecurityType.
        /// </summary>
        /// <returns>Mapper for SecurityType.</returns>
        protected override MapperBase<SecurityType> GetMapper()
        { return new SecurityTypeMapper(); }
    }
}