// --------------------------------------------------------------------------
// <copyright file="MerchandiseCategoryMapper.cs" company="MK inc.">
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
using Market.Middleware;

namespace Market.Mappers
{
    /// <summary>
    /// Class represents a mapper for a relation Merchandise-Category class.
    /// </summary>
    public class MerchandiseCategoryMapper : MapperBase<MerchandiseCategory>
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
                schema["MerchandiseID"] = record["MerchandiseID"];
                schema["CategoryID"] = record["CategoryID"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a relation Merchandise-Category object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Merchandise-Category object.</returns>
        public override MerchandiseCategory Map(System.Data.DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid mId = (DBNull.Value == record["MerchandiseID"]) ?
                    Guid.Empty : Guid.Parse(record["MerchandiseID"].ToString());
                Guid cId = (DBNull.Value == record["CategoryID"]) ?
                                    Guid.Empty : Guid.Parse(record["CategoryID"].ToString());

                var mc = new MerchandiseCategory(id, mId, cId);

                return mc;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="item">Merchandise-Category class instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override System.Data.DataRow UnMap(MerchandiseCategory item, System.Data.DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["MerchandiseID"] = item.MerchandiseID.ToString();
                record["CategoryID"] = item.CategoryID.ToString();

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
        public override List<PackedObject> Pack(List<MerchandiseCategory> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var mc in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = mc.GetType().Name;
                po.Values["ID"] = mc.ID;
                po.Values["CATEGORYID"] = mc.CategoryID;
                po.Values["MERCHANDISEID"] = mc.MerchandiseID;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override MerchandiseCategory UnPack(PackedObject objectToUnpack)
        {
            var mc = new MerchandiseCategory((Guid)objectToUnpack.Values["ID"],
                                             (Guid)objectToUnpack.Values["MERCHANDISEID"],
                                             (Guid)objectToUnpack.Values["CATEGORYID"],
                                             objectToUnpack.IsNew);

            return mc;
        }

        /// <summary>
        /// Method maps a record from database to a relation Merchandise-Category object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Merchandise-Category object.</returns>
        protected override MerchandiseCategory Map(IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid mId = (DBNull.Value == record["MerchandiseID"]) ?
                    Guid.Empty : Guid.Parse(record["MerchandiseID"].ToString());
                Guid cId = (DBNull.Value == record["CategoryID"]) ?
                                    Guid.Empty : Guid.Parse(record["CategoryID"].ToString());

                var mc = new MerchandiseCategory(id, mId, cId);

                return mc;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}