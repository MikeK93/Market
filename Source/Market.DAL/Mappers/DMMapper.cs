// --------------------------------------------------------------------------
// <copyright file="DMMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a relation Dealer-Merchandise class.
    /// </summary>
    public class DMMapper : MapperBase<DM>
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
                schema["DealerID"] = record["DealerID"];
                schema["MerchandiseId"] = record["MerchandiseId"];
                schema["Cost"] = record["Cost"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a relation Dealer-Merchandise object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Dealer-Merchandise object.</returns>
        public override DM Map(DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid dealerId = (DBNull.Value == record["DealerID"]) ?
                    Guid.Empty : Guid.Parse(record["DealerID"].ToString());
                Guid merchandiseId = (DBNull.Value == record["MerchandiseId"]) ?
                    Guid.Empty : Guid.Parse(record["MerchandiseId"].ToString());

                var dm = new DM(id, dealerId, merchandiseId);
                dm.Cost = (DBNull.Value == record["Cost"]) ?
                    float.MinValue : float.Parse(record["Cost"].ToString());

                return dm;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="item">Dealer-Merchandise class instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override DataRow UnMap(DM item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID;
                record["MerchandiseID"] = item.MerchandiseID;
                record["DealerID"] = item.DealerID;
                record["Cost"] = item.Cost;

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
        public override List<PackedObject> Pack(List<DM> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var dm in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = dm.GetType().Name;
                po.Values["ID"] = dm.ID;
                po.Values["DEALERID"] = dm.DealerID;
                po.Values["MERCHANDISEID"] = dm.MerchandiseID;
                po.Values["COST"] = dm.Cost;
                po.IsNew = dm.IsNew;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override DM UnPack(PackedObject objectToUnpack)
        {
            var dm = new DM((Guid)objectToUnpack.Values["ID"],
                            (Guid)objectToUnpack.Values["DEALERID"],
                            (Guid)objectToUnpack.Values["MERCHANDISEID"]);

            dm.Cost = (float)objectToUnpack.Values["COST"];
            dm.IsNew = objectToUnpack.IsNew;

            return dm;
        }

        /// <summary>
        /// Method maps a record from database to a relation Dealer-Merchandise object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Dealer-Merchandise object.</returns>
        protected override DM Map(IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid dealerId = (DBNull.Value == record["DealerID"]) ?
                    Guid.Empty : Guid.Parse(record["DealerID"].ToString());
                Guid merchandiseId = (DBNull.Value == record["MerchandiseId"]) ?
                    Guid.Empty : Guid.Parse(record["MerchandiseId"].ToString());

                var dm = new DM(id, dealerId, merchandiseId);
                dm.Cost = (DBNull.Value == record["Cost"]) ?
                    float.MinValue : float.Parse(record["Cost"].ToString());

                return dm;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}