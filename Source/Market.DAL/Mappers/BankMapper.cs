// --------------------------------------------------------------------------
// <copyright file="BankMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for Bank class.
    /// </summary>
    public class BankMapper : MapperBase<Bank>
    {
        /// <summary>
        /// Method generates a new row and adds to a cache table.
        /// </summary>
        /// <param name="record">Data from database.</param>
        /// <param name="schema">Table schema.</param>
        /// <returns>A new data row with data.</returns>
        public override System.Data.DataRow GenerateRow(System.Data.IDataRecord record, DataRow schema)
        {
            try
            {
                schema["ID"] = record["ID"];
                schema["Address"] = record["Address"];
                schema["Name"] = record["Name"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a Bank object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Bank object.</returns>
        public override Bank Map(DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Bank b = new Bank(id);
                b.Address = (DBNull.Value == record["Address"]) ?
                    string.Empty : record["Address"].ToString();
                b.Name = (DBNull.Value == record["Name"]) ?
                    string.Empty : record["Name"].ToString();

                return b;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="item">Bank instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override DataRow UnMap(Bank item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["Address"] = item.Address.ToString();
                record["Name"] = item.Name.ToString();

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
        public override List<PackedObject> Pack(List<Bank> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var i in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = i.GetType().Name;
                po.Values["ID"] = i.ID;
                po.Values["ADDRESS"] = i.Address;
                po.Values["NAME"] = i.Name;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override Bank UnPack(PackedObject objectToUnpack)
        {
            Guid id = (Guid)objectToUnpack.Values["ID"];
            Bank b = new Bank(id);
            b.Address = objectToUnpack.Values["ADDRESS"].ToString();
            b.Name = objectToUnpack.Values["NAME"].ToString();

            return b;
        }

        /// <summary>
        /// Method maps a record from database to a Bank object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Bank object.</returns>
        protected override Bank Map(IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Bank b = new Bank(id);
                b.Address = (DBNull.Value == record["Address"]) ?
                    string.Empty : record["Address"].ToString();
                b.Name = (DBNull.Value == record["Name"]) ?
                    string.Empty : record["Name"].ToString();

                return b;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}