// --------------------------------------------------------------------------
// <copyright file="MakerCompanyMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a MakerCompany class.
    /// </summary>
    public class MakerCompanyMapper : MapperBase<MakerCompany>
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
                schema["Address"] = record["Address"];
                schema["City"] = record["City"];
                schema["Country"] = record["Country"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a MakerCompany object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>MakerCompany object.</returns>
        public override MakerCompany Map(System.Data.DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                MakerCompany mc = new MakerCompany(id);
                mc.Name = (DBNull.Value == record["Name"]) ?
                    string.Empty : record["Name"].ToString();
                mc.Address = (DBNull.Value == record["Address"]) ?
                    string.Empty : record["Address"].ToString();
                mc.City = (DBNull.Value == record["City"]) ?
                    string.Empty : record["City"].ToString();
                mc.Country = (DBNull.Value == record["Country"]) ?
                    string.Empty : record["Country"].ToString();

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
        /// <param name="item">MakerCompany class instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override DataRow UnMap(MakerCompany item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["Name"] = item.Name.ToString();
                record["Address"] = item.Address.ToString();
                record["City"] = item.City.ToString();
                record["Country"] = item.Country.ToString();

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
        public override List<PackedObject> Pack(List<MakerCompany> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var mc in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = mc.GetType().Name;
                po.Values["ID"] = mc.ID;
                po.Values["NAME"] = mc.Name;
                po.Values["ADDRESS"] = mc.Address;
                po.Values["CITY"] = mc.City;
                po.Values["COUNTRY"] = mc.Country;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override MakerCompany UnPack(PackedObject objectToUnpack)
        {
            var mc = new MakerCompany((Guid)objectToUnpack.Values["ID"]);

            mc.Name = objectToUnpack.Values["NAME"].ToString();
            mc.Address = objectToUnpack.Values["ADDRESS"].ToString();
            mc.City = objectToUnpack.Values["CITY"].ToString();
            mc.Country = objectToUnpack.Values["COUNTRY"].ToString();

            return mc;
        }

        /// <summary>
        /// Method maps a record from database to a MakerCompany object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>MakerCompany object.</returns>
        protected override MakerCompany Map(IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                MakerCompany mc = new MakerCompany(id);
                mc.Name = (DBNull.Value == record["Name"]) ?
                    string.Empty : record["Name"].ToString();
                mc.Address = (DBNull.Value == record["Address"]) ?
                    string.Empty : record["Address"].ToString();
                mc.City = (DBNull.Value == record["City"]) ?
                    string.Empty : record["City"].ToString();
                mc.Country = (DBNull.Value == record["Country"]) ?
                    string.Empty : record["Country"].ToString();

                return mc;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}