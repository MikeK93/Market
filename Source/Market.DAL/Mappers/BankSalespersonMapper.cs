// --------------------------------------------------------------------------
// <copyright file="BankSalespersonMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a relation Bank-Salesperson class.
    /// </summary>
    public class BankSalespersonMapper : MapperBase<BankSalesperson>
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
                schema["BankID"] = record["BankID"];
                schema["SalespersonID"] = record["SalespersonID"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a relation Bank-Salesperson object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Bank-Salesperson object.</returns>
        public override BankSalesperson Map(DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid bankId = (DBNull.Value == record["BankID"]) ?
                    Guid.Empty : Guid.Parse(record["BankID"].ToString());
                Guid salespersonId = (DBNull.Value == record["SalespersonID"]) ?
                    Guid.Empty : Guid.Parse(record["SalespersonID"].ToString());
                BankSalesperson bd = new BankSalesperson(id, bankId, salespersonId);

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
        /// <param name="item">Bank-Salesperson instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override DataRow UnMap(BankSalesperson item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["BankID"] = item.BankID.ToString();
                record["SalespersonID"] = item.SalespersonID.ToString();

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
        public override List<PackedObject> Pack(List<BankSalesperson> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var i in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = i.GetType().Name;
                po.Values["ID"] = i.ID;
                po.Values["BANKID"] = i.BankID;
                po.Values["SALESPERSONID"] = i.SalespersonID;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override BankSalesperson UnPack(PackedObject objectToUnpack)
        {
            Guid id = (Guid)objectToUnpack.Values["ID"];
            Guid bId = (Guid)objectToUnpack.Values["BANKID"];
            Guid sId = (Guid)objectToUnpack.Values["SALESPERSONID"];
            var bs = new BankSalesperson(id, bId, sId);

            return bs;
        }

        /// <summary>
        /// Method maps a record from database to a relation Bank-Salesperson object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Bank-Salesperson object.</returns>
        protected override BankSalesperson Map(IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid bankId = (DBNull.Value == record["BankID"]) ?
                    Guid.Empty : Guid.Parse(record["BankID"].ToString());
                Guid salespersonId = (DBNull.Value == record["SalespersonID"]) ?
                    Guid.Empty : Guid.Parse(record["SalespersonID"].ToString());
                BankSalesperson bd = new BankSalesperson(id, bankId, salespersonId);

                return bd;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}