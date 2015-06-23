// --------------------------------------------------------------------------
// <copyright file="SalespersonReader.cs" company="MK inc.">
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
    /// Class represents a reader for Salesperson class.
    /// </summary>
    public class SalespersonReader : ObjectReaderBase<Salesperson>, IRoleReader<Salesperson>
    {
        private static SalespersonReader _reader;

        static SalespersonReader() { _reader = new SalespersonReader(); }

        private SalespersonReader() { }

        /// <summary>
        /// Gets a Reader for Salesperson.
        /// </summary>
        public static SalespersonReader Reader { get { return SalespersonReader._reader; } }

        /// <summary>
        /// Method gets a Salesperson by his/her user account.
        /// </summary>
        /// <param name="user">User attached to Salesperson.</param>
        /// <returns>Salesperson instance.</returns>
        public Salesperson InitializeRole(User user)
        {
            return Reader.GetByQuery("UserID = '" + user.ID + "'").ToList().First();
        }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">Salesperson instance.</param>
        /// <param name="isNew">Parameter that inditates if a Salesperson instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override DataRow GetDataRow(Salesperson item, bool isNew)
        {
            var res = Table.NewRow();
            if (!isNew)
            {
                res = (from s in Table.AsEnumerable()
                       where s["ID"].ToString() == item.ID.ToString()
                       select s)
                           .ToList<DataRow>()
                           .FirstOrDefault();
            }

            return res;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">Salesperson instance.</param>
        /// <param name="isNew">Parameter that inditates if a Salesperson instance is new.</param>
        public override void Save(Salesperson item, bool isNew)
        {
            SalespersonMapper mapper = new SalespersonMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of Salesperson items.</param>
        public override void Save(System.Collections.Generic.List<Salesperson> items)
        {
            foreach (Salesperson s in items)
                Save(s, s.IsNew);
        }

        /// <summary>
        /// Method delets Salesperson item.
        /// </summary>
        /// <param name="item">Salesperson instance.</param>
        public override void Delete(Salesperson item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Method delets list of Salesperson items.
        /// </summary>
        /// <param name="items">List of Salesperson items.</param>
        public override void Delete(System.Collections.Generic.List<Salesperson> items)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Method gets a mapper for Salesperson.
        /// </summary>
        /// <returns>Mapper for Salesperson.</returns>
        protected override MapperBase<Salesperson> GetMapper() { return new SalespersonMapper(); }
    }
}