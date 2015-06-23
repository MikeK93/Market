// --------------------------------------------------------------------------
// <copyright file="CustomerSelectedItemsMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a relation Customer-SelectedItems class.
    /// </summary>
    public class CustomerSelectedItemsMapper : MapperBase<CustomerSelectedItems>
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
                schema["CustomerID"] = record["CustomerID"];
                schema["SalespersonDealerMerchandiseID"] = record["SalespersonDealerMerchandiseID"];
                schema["IsSubmited"] = record["IsSubmited"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a relation Customer-SelectedItems object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>A relation Customer-SelectedItems object.</returns>
        public override CustomerSelectedItems Map(DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid cId = (DBNull.Value == record["CustomerID"]) ?
                    Guid.Empty : Guid.Parse(record["CustomerID"].ToString());
                Guid sdmId = (DBNull.Value == record["SalespersonDealerMerchandiseID"]) ?
                    Guid.Empty : Guid.Parse(record["SalespersonDealerMerchandiseID"].ToString());

                CustomerSelectedItems csi = new CustomerSelectedItems(id, cId, sdmId);
                csi.IsSubmited = (DBNull.Value == record["IsSubmited"]) ?
                    false : Convert.ToBoolean(record["IsSubmited"]);

                return csi;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="item">Customer-SelectedItems instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override DataRow UnMap(CustomerSelectedItems item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["CustomerID"] = item.CustomerID.ToString();
                record["SalespersonDealerMerchandiseID"] = item.SDMID.ToString();
                record["IsSubmited"] = Convert.ToUInt32(item.IsSubmited);

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
        public override List<PackedObject> Pack(List<CustomerSelectedItems> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var csi in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = csi.GetType().Name;
                po.Values["ID"] = csi.ID;
                po.Values["CUSTOMERID"] = csi.CustomerID;
                po.Values["SDMID"] = csi.SDMID;
                po.Values["ISSUBMITED"] = csi.IsSubmited;
                po.IsNew = csi.IsNew;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override CustomerSelectedItems UnPack(PackedObject objectToUnpack)
        {
            var csi = new CustomerSelectedItems((Guid)objectToUnpack.Values["ID"],
                                                (Guid)objectToUnpack.Values["CUSTOMERID"],
                                                (Guid)objectToUnpack.Values["SDMID"]);
            csi.IsSubmited = Convert.ToBoolean(objectToUnpack.Values["ISSUBMITED"]);
            csi.IsNew = objectToUnpack.IsNew;

            return csi;
        }

        /// <summary>
        /// Method maps a record from database to a Customer-SelectedItems object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Customer-SelectedItems object.</returns>
        protected override CustomerSelectedItems Map(System.Data.IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid cId = (DBNull.Value == record["CustomerID"]) ?
                    Guid.Empty : Guid.Parse(record["CustomerID"].ToString());
                Guid sdmId = (DBNull.Value == record["SalespersonDealerMerchandiseID"]) ?
                    Guid.Empty : Guid.Parse(record["SalespersonDealerMerchandiseID"].ToString());

                CustomerSelectedItems csi = new CustomerSelectedItems(id, cId, sdmId);
                csi.IsSubmited = (DBNull.Value == record["IsSubmited"]) ?
                     false : Convert.ToBoolean(record["IsSubmited"]);

                return csi;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}