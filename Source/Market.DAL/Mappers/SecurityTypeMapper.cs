// --------------------------------------------------------------------------
// <copyright file="SecurityTypeMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a SecurityType class.
    /// </summary>
    public class SecurityTypeMapper : MapperBase<SecurityType>
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
                schema["Guards"] = record["Guards"];
                schema["Cost"] = record["Cost"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a SecurityType object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>SecurityType object.</returns>
        public override SecurityType Map(System.Data.DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                string name = (DBNull.Value == record["Name"]) ?
                    string.Empty : record["Name"].ToString();
                int guards = (DBNull.Value == record["Guards"]) ?
                    0 : int.Parse(record["Guards"].ToString());
                float cost = (DBNull.Value == record["Cost"]) ?
                    float.NaN : float.Parse(record["Cost"].ToString());

                SecurityType st = new SecurityType(id, name, guards, cost);

                return st;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="item">SecurityType class instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override DataRow UnMap(SecurityType item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID;
                record["Name"] = item.Name.ToString();
                record["Guards"] = item.Guards;
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
        public override List<PackedObject> Pack(List<SecurityType> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var st in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = st.GetType().Name;
                po.Values["ID"] = st.ID;
                po.Values["NAME"] = st.Name;
                po.Values["GUARDS"] = st.Guards;
                po.Values["COST"] = st.Cost;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override SecurityType UnPack(PackedObject objectToUnpack)
        {
            var st = new SecurityType((Guid)objectToUnpack.Values["ID"],
                                       objectToUnpack.Values["NAME"].ToString(),
                                      (int)objectToUnpack.Values["GUARDS"],
                                      (float)objectToUnpack.Values["COST"]);

            return st;
        }

        /// <summary>
        /// Method maps a record from database to a SecurityType object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>SecurityType object.</returns>
        protected override SecurityType Map(System.Data.IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                string name = (DBNull.Value == record["Name"]) ?
                    string.Empty : record["Name"].ToString();
                int guards = (DBNull.Value == record["Guards"]) ?
                    0 : int.Parse(record["Guards"].ToString());
                float cost = (DBNull.Value == record["Cost"]) ?
                    float.NaN : float.Parse(record["Cost"].ToString());

                SecurityType st = new SecurityType(id, name, guards, cost);

                return st;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}