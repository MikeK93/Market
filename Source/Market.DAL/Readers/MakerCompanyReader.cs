// --------------------------------------------------------------------------
// <copyright file="MakerCompanyReader.cs" company="MK inc.">
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
    /// Class represents a reader for MakerCompany class.
    /// </summary>
    public class MakerCompanyReader : ObjectReaderBase<MakerCompany>
    {
        private static MakerCompanyReader _reader;

        static MakerCompanyReader() { _reader = new MakerCompanyReader(); }

        private MakerCompanyReader() { }

        /// <summary>
        /// Gets a Reader for MakerCompany.
        /// </summary>
        public static MakerCompanyReader Reader
        {
            get
            {
                return MakerCompanyReader._reader;
            }
        }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">MakerCompany instance.</param>
        /// <param name="isNew">Parameter that inditates if a MakerCompany instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override DataRow GetDataRow(MakerCompany item, bool isNew)
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
        /// <param name="item">MakerCompany instance.</param>
        /// <param name="isNew">Parameter that inditates if a MakerCompany instance is new.</param>
        public override void Save(MakerCompany item, bool isNew)
        {
            MakerCompanyMapper mapper = new MakerCompanyMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of MakerCompany items.</param>
        public override void Save(List<MakerCompany> items)
        {
            foreach (MakerCompany mc in items)
                Save(mc, mc.IsNew);
        }

        /// <summary>
        /// Method delets MakerCompany item.
        /// </summary>
        /// <param name="item">MakerCompany instance.</param>
        public override void Delete(MakerCompany item)
        { throw new NotImplementedException(); }

        /// <summary>
        /// Method delets list of MakerCompany items.
        /// </summary>
        /// <param name="items">List of MakerCompany items.</param>
        public override void Delete(List<MakerCompany> items)
        { throw new NotImplementedException(); }

        /// <summary>
        /// Method gets a mapper for MakerCompany.
        /// </summary>
        /// <returns>Mapper for MakerCompany.</returns>
        protected override MapperBase<MakerCompany> GetMapper()
        { return new MakerCompanyMapper(); }
    }
}