// --------------------------------------------------------------------------
// <copyright file="SDMMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a relation Salesperson-Dealer-Merchandise class.
    /// </summary>
    public class SDMMapper : MapperBase<SDM>
    {
        /// <summary>
        /// Method generates a new row and adds to a cache table.
        /// </summary>
        /// <param name="record">Data from database.</param>
        /// <param name="schema">Table schema.</param>
        /// <returns>A new data row with data.</returns>
        public override DataRow GenerateRow(IDataRecord record, DataRow schema)
        {
            try
            {
                schema["ID"] = record["ID"];
                schema["DealerMerchandiseID"] = record["DealerMerchandiseID"];
                schema["SalespersonID"] = record["SalespersonID"];
                schema["Cost"] = record["Cost"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a relation Salesperson-Dealer-Merchandise object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Salesperson-Dealer-Merchandise object.</returns>
        public override SDM Map(DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid dmId = (DBNull.Value == record["DealerMerchandiseID"]) ?
                    Guid.Empty : Guid.Parse(record["DealerMerchandiseID"].ToString());
                Guid sId = (DBNull.Value == record["SalespersonID"]) ?
                    Guid.Empty : Guid.Parse(record["SalespersonID"].ToString());

                var sdm = new SDM(id, dmId, sId);
                sdm.Cost = (DBNull.Value == record["Cost"]) ?
                    float.NaN : float.Parse(record["Cost"].ToString());

                return sdm;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="item">Salesperson-Dealer-Merchandise class instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override DataRow UnMap(SDM item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["SalespersonID"] = item.SalespersonID.ToString();
                record["DealerMerchandiseID"] = item.DealerMerchandiseID.ToString();
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
        public override List<PackedObject> Pack(List<SDM> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var sdm in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = sdm.GetType().Name;
                po.Values["ID"] = sdm.ID;
                po.Values["SALESPERSONID"] = sdm.SalespersonID;
                po.Values["DMID"] = sdm.DealerMerchandiseID;
                po.Values["COST"] = sdm.Cost;
                po.IsNew = sdm.IsNew;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override SDM UnPack(PackedObject objectToUnpack)
        {
            var sdm = new SDM((Guid)objectToUnpack.Values["ID"],
                              (Guid)objectToUnpack.Values["DMID"],
                              (Guid)objectToUnpack.Values["SALESPERSONID"]);
            sdm.Cost = (float)objectToUnpack.Values["COST"];
            sdm.IsNew = objectToUnpack.IsNew;

            return sdm;
        }

        /// <summary>
        /// Method maps a record from database to a relation Salesperson-Dealer-Merchandise object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Salesperson-Dealer-Merchandise object.</returns>
        protected override SDM Map(IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid dmId = (DBNull.Value == record["DealerMerchandiseID"]) ?
                    Guid.Empty : Guid.Parse(record["DealerMerchandiseID"].ToString());
                Guid sId = (DBNull.Value == record["SalespersonID"]) ?
                    Guid.Empty : Guid.Parse(record["SalespersonID"].ToString());

                var sdm = new SDM(id, dmId, sId);
                sdm.Cost = (DBNull.Value == record["Cost"]) ?
                    float.NaN : float.Parse(record["Cost"].ToString());

                return sdm;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}