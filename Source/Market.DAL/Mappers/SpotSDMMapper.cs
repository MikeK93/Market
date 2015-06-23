// --------------------------------------------------------------------------
// <copyright file="SpotSDMMapper.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Core;
using Market.Entities;
using Market.Middleware;

namespace Market.Mappers
{
    /// <summary>
    /// Class represents a mapper for a relation Spot-[Salesperson-[Dealer-Merchandise]] class.
    /// </summary>
    public class SpotSDMMapper : MapperBase<SpotSDM>
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
                schema["SpotID"] = record["SpotID"];
                schema["SalespersonDealerMerchandiseID"] = record["SalespersonDealerMerchandiseID"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a relation Spot-[Salesperson-[Dealer-Merchandise]] object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>SpotSDM object.</returns>
        public override SpotSDM Map(System.Data.DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid sId = (DBNull.Value == record["SpotID"]) ?
                    Guid.Empty : Guid.Parse(record["SpotID"].ToString());
                Guid sdmId = (DBNull.Value == record["SalespersonDealerMerchandiseID"]) ?
                    Guid.Empty : Guid.Parse(record["SalespersonDealerMerchandiseID"].ToString());

                SpotSDM ssdm = new SpotSDM(id, sId, sdmId);
                return ssdm;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="item">SpotSDM class instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override System.Data.DataRow UnMap(SpotSDM item, System.Data.DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["SpotID"] = item.SpotID.ToString();
                record["SalespersonDealerMerchandiseID"] = item.SDMID.ToString();

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
        public override List<Middleware.PackedObject> Pack(List<SpotSDM> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var ssdm in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = ssdm.GetType().Name;
                po.Values["ID"] = ssdm.ID;
                po.Values["SPOTID"] = ssdm.SpotID;
                po.Values["SDMID"] = ssdm.SDMID;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override SpotSDM UnPack(PackedObject objectToUnpack)
        {
            var ssdm = new SpotSDM((Guid)objectToUnpack.Values["ID"],
                                   (Guid)objectToUnpack.Values["SPOTID"],
                                   (Guid)objectToUnpack.Values["SDMID"]);
            ssdm.IsNew = objectToUnpack.IsNew;

            return ssdm;
        }

        /// <summary>
        /// Method maps a record from database to a relation Spot-[Salesperson-[Dealer-Merchandise]] object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>SpotSDM object.</returns>
        protected override SpotSDM Map(System.Data.IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid sId = (DBNull.Value == record["SpotID"]) ?
                    Guid.Empty : Guid.Parse(record["SpotID"].ToString());
                Guid sdmId = (DBNull.Value == record["SalespersonDealerMerchandiseID"]) ?
                    Guid.Empty : Guid.Parse(record["SalespersonDealerMerchandiseID"].ToString());

                SpotSDM ssdm = new SpotSDM(id, sId, sdmId);
                return ssdm;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}