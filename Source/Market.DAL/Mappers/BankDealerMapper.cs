// --------------------------------------------------------------------------
// <copyright file="BankDealerMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for relation Bank-Dealer class.
    /// </summary>
    public class BankDealerMapper : MapperBase<BankDealer>
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
                schema["BankID"] = record["BankID"];
                schema["DealerID"] = record["DealerID"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a Bank-Dealer object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Bank-Dealer object.</returns>
        public override BankDealer Map(System.Data.DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid bankId = (DBNull.Value == record["BankID"]) ?
                    Guid.Empty : Guid.Parse(record["BankID"].ToString());
                Guid dealerId = (DBNull.Value == record["DealerID"]) ?
                    Guid.Empty : Guid.Parse(record["DealerID"].ToString());
                BankDealer bd = new BankDealer(id, bankId, dealerId);

                return bd;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="item">BankDealer instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override System.Data.DataRow UnMap(BankDealer item, System.Data.DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["BankID"] = item.BankID.ToString();
                record["DealerID"] = item.DealerID.ToString();

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
        public override List<PackedObject> Pack(List<BankDealer> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var i in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = i.GetType().Name;
                po.Values["ID"] = i.ID;
                po.Values["BANKID"] = i.BankID;
                po.Values["DEALERID"] = i.DealerID;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override BankDealer UnPack(PackedObject objectToUnpack)
        {
            Guid id = (Guid)objectToUnpack.Values["ID"];
            Guid bankId = (Guid)objectToUnpack.Values["BANKID"];
            Guid dealerId = (Guid)objectToUnpack.Values["DEALERID"];

            return new BankDealer(id, bankId, dealerId);
        }

        /// <summary>
        /// Method maps a record from database to a Bank-Dealer object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Bank-Dealer object.</returns>
        protected override BankDealer Map(System.Data.IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid bankId = (DBNull.Value == record["BankID"]) ?
                    Guid.Empty : Guid.Parse(record["BankID"].ToString());
                Guid dealerId = (DBNull.Value == record["DealerID"]) ?
                    Guid.Empty : Guid.Parse(record["DealerID"].ToString());
                BankDealer bd = new BankDealer(id, bankId, dealerId);

                return bd;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}