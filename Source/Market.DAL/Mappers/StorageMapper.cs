// --------------------------------------------------------------------------
// <copyright file="StorageMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for storage class.
    /// </summary>
    public class StorageMapper : MapperBase<Storage>
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
                schema["Address"] = record["Address"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a storage object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Storage object.</returns>
        public override Storage Map(DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Storage s = new Storage(id);
                s.Address = (DBNull.Value == record["Address"]) ?
                    string.Empty : record["Address"].ToString();

                return s;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="item">Storage instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override DataRow UnMap(Storage item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["Address"] = item.Address.ToString();

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
        public override List<PackedObject> Pack(List<Storage> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var i in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = i.GetType().Name;
                po.Values["ID"] = i.ID;
                po.Values["ADDRESS"] = i.Address;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override Storage UnPack(PackedObject objectToUnpack)
        {
            var s = new Storage((Guid)objectToUnpack.Values["ID"]);
            s.Address = objectToUnpack.Values["ADDRESS"].ToString();

            return s;
        }

        /// <summary>
        /// Method maps a record from database to a storage object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Storage object.</returns>
        protected override Storage Map(IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Storage s = new Storage(id);
                s.Address = (DBNull.Value == record["Address"]) ?
                    string.Empty : record["Address"].ToString();

                return s;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}