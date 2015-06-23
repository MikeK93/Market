// --------------------------------------------------------------------------
// <copyright file="CategoryReader.cs" company="MK inc.">
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
    /// Class represents a reader for Category class.
    /// </summary>
    public class CategoryReader : ObjectReaderBase<Category>
    {
        private static CategoryReader _reader;

        static CategoryReader() { _reader = new CategoryReader(); }

        private CategoryReader() { }

        /// <summary>
        /// Gets a Reader for Category.
        /// </summary>
        public static CategoryReader Reader
        {
            get { return CategoryReader._reader; }
        }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">Category instance.</param>
        /// <param name="isNew">Parameter that inditates if a Category instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override System.Data.DataRow GetDataRow(Category item, bool isNew)
        {
            var row = Table.NewRow();
            if (!isNew)
            {
                row = (from c in Table.AsEnumerable()
                       where c["ID"].ToString() == item.ID.ToString()
                       select c)
                          .ToList<DataRow>()
                          .FirstOrDefault();
            }

            return row;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">Category instance.</param>
        /// <param name="isNew">Parameter that inditates if a Category instance is new.</param>
        public override void Save(Category item, bool isNew)
        {
            CategoryMapper mapper = new CategoryMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of Category items.</param>
        public override void Save(List<Category> items)
        {
            foreach (Category c in items)
                Save(c, c.IsNew);
        }

        /// <summary>
        /// Method delets Category item.
        /// </summary>
        /// <param name="item">Category instance.</param>
        public override void Delete(Category item)
        {
            CategoryMapper mapper = new CategoryMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, false));
            row.Delete();
            Update(row, false);
        }

        /// <summary>
        /// Method delets list of Category items.
        /// </summary>
        /// <param name="items">List of Category items.</param>
        public override void Delete(List<Category> items)
        {
            foreach (Category c in items)
                Delete(c);
        }

        /// <summary>
        /// Method gets a mapper for Category.
        /// </summary>
        /// <returns>Mapper for Category.</returns>
        protected override MapperBase<Category> GetMapper()
        { return new CategoryMapper(); }
    }
}