// --------------------------------------------------------------------------
// <copyright file="MerchandiseMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for Merchandise class.
    /// </summary>
    public class MerchandiseMapper : MapperBase<Merchandise>
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
                schema["Name"] = record["Name"];
                schema["Cost"] = record["Cost"];
                schema["StorageID"] = record["StorageID"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to Merchandise object.
        /// </summary>
        /// <param name="item">Merchandise instance.</param>
        /// <param name="record">Record form a database.</param>
        /// <returns>Merchandise object.</returns>
        public override DataRow UnMap(Merchandise item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID;
                record["Name"] = item.Name;
                record["Cost"] = item.Cost;
                record["StorageID"] = item.StorageID;

                return record;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override Merchandise Map(DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ? Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid storageId = (DBNull.Value == record["StorageID"]) ? Guid.Empty : Guid.Parse(record["StorageID"].ToString());
                Merchandise m = new Merchandise(id, storageId);
                m.Name = (DBNull.Value == record["Name"]) ? string.Empty : record["Name"].ToString();
                m.Cost = (DBNull.Value == record["Cost"]) ? float.MinValue : float.Parse(record["Cost"].ToString());
                return m;
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
        public override List<PackedObject> Pack(List<Merchandise> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var i in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = i.GetType().Name;
                po.Values["ID"] = i.ID;
                po.Values["NAME"] = i.Name;
                po.Values["COST"] = i.Cost;
                po.Values["STORAGEID"] = i.StorageID;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override Merchandise UnPack(PackedObject objectToUnpack)
        {
            var m = new Merchandise((Guid)objectToUnpack.Values["ID"],
                                    (Guid)objectToUnpack.Values["STORAGEID"],
                                          objectToUnpack.IsNew);

            m.Name = objectToUnpack.Values["NAME"] == null ? string.Empty : objectToUnpack.Values["NAME"].ToString();
            m.Cost = (float)objectToUnpack.Values["COST"];

            return m;
        }

        /// <summary>
        /// Method maps a record from database to Merchandise object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Merchandise object.</returns>
        protected override Merchandise Map(System.Data.IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ? Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid storageId = (DBNull.Value == record["StorageID"]) ? Guid.Empty : Guid.Parse(record["StorageID"].ToString());
                Merchandise m = new Merchandise(id, storageId);
                m.Name = (DBNull.Value == record["Name"]) ? string.Empty : record["Name"].ToString();
                m.Cost = (DBNull.Value == record["Cost"]) ? float.MinValue : float.Parse(record["Cost"].ToString());

                return m;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}