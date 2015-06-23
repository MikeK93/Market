// --------------------------------------------------------------------------
// <copyright file="UserReader.cs" company="MK inc.">
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
    /// Class represents a reader for User class.
    /// </summary>
    public class UserReader : ObjectReaderBase<User>
    {
        private static UserReader _reader;

        static UserReader() { _reader = new UserReader(); }

        private UserReader() { }

        /// <summary>
        /// Gets a Reader for User.
        /// </summary>
        public static UserReader Reader { get { return UserReader._reader; } }

        /// <summary>
        /// Method gets data row from table in database.
        /// </summary>
        /// <param name="item">User instance.</param>
        /// <param name="isNew">Parameter that inditates if a User instance is new.</param>
        /// <returns>DataRow form database.</returns>
        public override DataRow GetDataRow(User item, bool isNew)
        {
            var res = Table.NewRow();
            if (!isNew)
            {
                res = (from u in Table.AsEnumerable()
                       where u["ID"].ToString() == item.ID.ToString()
                       select u)
                         .ToList<DataRow>()
                         .FirstOrDefault();
            }

            return res;
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="item">User instance.</param>
        /// <param name="isNew">Parameter that inditates if a User instance is new.</param>
        public override void Save(User item, bool isNew)
        {
            UserMapper mapper = new UserMapper();
            DataRow row = mapper.UnMap(item, GetDataRow(item, isNew));
            Update(row, isNew);
        }

        /// <summary>
        /// Method saves changes.
        /// </summary>
        /// <param name="items">List of User items.</param>
        public override void Save(System.Collections.Generic.List<User> items)
        {
            foreach (User u in items)
                Save(u, u.IsNew);
        }

        /// <summary>
        /// Method delets User item.
        /// </summary>
        /// <param name="item">User instance.</param>
        public override void Delete(User item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Method delets list of User items.
        /// </summary>
        /// <param name="items">List of User items.</param>
        public override void Delete(System.Collections.Generic.List<User> items)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Method gets a mapper for User.
        /// </summary>
        /// <returns>Mapper for User.</returns>
        protected override MapperBase<User> GetMapper() { return new UserMapper(); }
    }
}