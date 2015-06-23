// --------------------------------------------------------------------------
// <copyright file="DealerReader.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Data;
using System.Linq;
using Market.Core;
using Market.Entities;
using Market.Mappers;

namespace Market.Readers
{
    /// <summary>
    /// Class represents a reader for Dealer class.
    /// </summary>
    public class DealerReader : ObjectReaderBase<Dealer>, IRoleReader<Dealer>
    {
        private static DealerReader _reader;

        static DealerReader() { _reader = new DealerReader(); }

        private DealerReader() { }

        /// <summary>
        /// Gets a Reader for Dealer.
        /// </summary>
        public static DealerReader Reader
        {
            get
            {
                return DealerReader._reader;
            }
        }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">Dealer instance.</param>
        /// <param name="isNew">Parameter that inditates if a Dealer instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override DataRow GetDataRow(Dealer item, bool isNew)
        {
            var row = Table.NewRow();
            if (!isNew)
            {
                row = (from d in Table.AsEnumerable()
                       where d["ID"].ToString() == item.ID.ToString()
                       select d)
                          .ToList<DataRow>()
                          .FirstOrDefault();
            }

            return row;
        }

        /// <summary>
        /// Method gets a dealer by his/her user account.
        /// </summary>
        /// <param name="user">User attached to dealer.</param>
        /// <returns>Dealer instance.</returns>
        public Dealer InitializeRole(User user)
        { return Reader.GetByQuery("UserID = '" + user.ID + "'").ToList().FirstOrDefault(); }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">Dealer instance.</param>
        /// <param name="isNew">Parameter that inditates if a Dealer instance is new.</param>
        public override void Save(Dealer item, bool isNew)
        {
            DealerMapper mapper = new DealerMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of Dealer items.</param>
        public override void Save(System.Collections.Generic.List<Dealer> items)
        {
            foreach (Dealer d in items)
                Save(d, d.IsNew);
        }

        /// <summary>
        /// Method delets Dealer item.
        /// </summary>
        /// <param name="item">Dealer instance.</param>
        public override void Delete(Dealer item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method delets list of Dealer items.
        /// </summary>
        /// <param name="items">List of Dealer items.</param>
        public override void Delete(System.Collections.Generic.List<Dealer> items)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method gets a mapper for Dealer.
        /// </summary>
        /// <returns>Mapper for Dealer.</returns>
        protected override MapperBase<Dealer> GetMapper()
        { return new DealerMapper(); }
    }
}