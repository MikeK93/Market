// --------------------------------------------------------------------------
// <copyright file="UserMapper.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using Market.Core;
using Market.Entities;
using Market.Middleware;

namespace Market.Mappers
{
    /// <summary>
    /// Class represents a mapper for user.
    /// </summary>
    public class UserMapper : MapperBase<User>
    {
        /// <summary>
        /// Method generates a new row and adds to a cache table.
        /// </summary>
        /// <param name="record">Data from database.</param>
        /// <param name="schema">Table schema.</param>
        /// <returns>A new data row with data.</returns>
        public override System.Data.DataRow GenerateRow(System.Data.IDataRecord record, System.Data.DataRow schema)
        {
            try
            {
                schema["ID"] = record["ID"];
                schema["Login"] = record["Login"];
                schema["PWord"] = record["PWord"];
                schema["Role"] = record["Role"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps record from database to a user object.
        /// </summary>
        /// <param name="record">A record from database to map a user.</param>
        /// <returns>User object.</returns>
        public override User Map(DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                User u = new User(id);
                u.Login = (DBNull.Value == record["Login"]) ?
                    string.Empty : record["Login"].ToString();
                u.Password = (DBNull.Value == record["PWord"]) ?
                    string.Empty : record["PWord"].ToString();
                u.Role = (DBNull.Value == record["Role"]) ?
                    Role.Customer : (Role)int.Parse(record["Role"].ToString());

                return u;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmap user object and transfors it to datarow for database.
        /// </summary>
        /// <param name="item">Instance of user.</param>
        /// <param name="record">New or retrieved datarow from table.</param>
        /// <returns>Freshed up or new DataRow object.</returns>
        public override DataRow UnMap(User item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["Login"] = item.Login.ToString();
                record["PWord"] = item.Password.ToString();
                record["Role"] = (int)item.Role;

                return record;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method packs all data of list with objects of type T into a list of PackedObject.
        /// </summary>
        /// <param name="objectsToPack">List of objects to pack.</param>
        /// <returns>List of packed objects.</returns>
        public override List<PackedObject> Pack(List<User> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var i in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = i.GetType().Name;
                po.Values["ID"] = i.ID;
                po.Values["ROLE"] = (int)i.Role;
                po.Values["LOGIN"] = i.Login;
                po.Values["PWD"] = i.Password;
                po.IsNew = i.IsNew;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override User UnPack(PackedObject objectToUnpack)
        {
            var u = new User((Guid)objectToUnpack.Values["ID"]);
            u.Password = objectToUnpack.Values["PWD"].ToString();
            u.Login = objectToUnpack.Values["LOGIN"].ToString();
            u.Role = (Role)objectToUnpack.Values["ROLE"];
            u.IsNew = objectToUnpack.IsNew;

            return u;
        }

        /// <summary>
        /// Method maps record from database to a user object.
        /// </summary>
        /// <param name="record">A record from database to map a user.</param>
        /// <returns>User object.</returns>
        protected override User Map(IDataRecord record)
        {
            try
            {
                User u = new User((DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString()));
                u.Login = (DBNull.Value == record["Login"]) ?
                    string.Empty : record["Login"].ToString();
                u.Password = (DBNull.Value == record["PWord"]) ?
                    string.Empty : record["PWord"].ToString();
                u.Role = (DBNull.Value == record["Role"]) ?
                    Role.Customer : (Role)int.Parse(record["Role"].ToString());

                return u;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}