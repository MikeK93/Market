// --------------------------------------------------------------------------
// <copyright file="SalespersonMapper.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Market.Core;
using Market.Entities;
using Market.Middleware;
using Market.Readers;

namespace Market.Mappers
{
    /// <summary>
    /// Class represents a mapper for a Salesperson class.
    /// </summary>
    public class SalespersonMapper : MapperBase<Salesperson>
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
                schema["UserID"] = record["UserID"];
                schema["FName"] = record["FName"];
                schema["MName"] = record["MName"];
                schema["LName"] = record["LName"];
                schema["Gender"] = record["Gender"];
                schema["PhoneNumber"] = record["PhoneNumber"];
                schema["Email"] = record["Email"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a Salesperson object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Salesperson object.</returns>
        public override Salesperson Map(DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid userId = (DBNull.Value == record["UserID"]) ?
                    Guid.Empty : Guid.Parse(record["UserID"].ToString());

                Salesperson sp = new Salesperson(id, userId);
                sp.FirstName = (DBNull.Value == record["FName"]) ?
                    string.Empty : record["FName"].ToString();
                sp.MiddleName = (DBNull.Value == record["MName"]) ?
                    string.Empty : record["MName"].ToString();
                sp.LastName = (DBNull.Value == record["LName"]) ?
                    string.Empty : record["LName"].ToString();
                sp.Gender = (DBNull.Value == record["Gender"]) ?
                    (GenderType)0 : (GenderType)int.Parse(record["Gender"].ToString());
                sp.PhoneNumber = (DBNull.Value == record["PhoneNumber"]) ?
                    string.Empty : record["PhoneNumber"].ToString();
                sp.Email = (DBNull.Value == record["Email"]) ?
                    string.Empty : record["Email"].ToString();

                var res = SDMReader.Reader.GetByQuery("SalespersonID='" + sp.ID + "'");
                sp.SDMs = res;

                return sp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="item">Salesperson class instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override DataRow UnMap(Salesperson item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["FName"] = item.FirstName.ToString();
                record["MName"] = item.MiddleName.ToString();
                record["LName"] = item.LastName.ToString();
                record["Gender"] = (item.Gender == GenderType.Female) ? 0 : 1;
                record["UserID"] = item.UserID;
                record["PhoneNumber"] = item.PhoneNumber;
                record["Email"] = item.Email;

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
        public override List<PackedObject> Pack(List<Salesperson> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var s in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = s.GetType().Name;
                po.Values["ID"] = s.ID;
                po.Values["FN"] = s.FirstName;
                po.Values["MN"] = s.MiddleName;
                po.Values["LN"] = s.LastName;
                po.Values["EMAIL"] = s.Email;
                po.Values["PNUM"] = s.PhoneNumber;
                po.Values["USERID"] = s.UserID;
                po.Values["GENDER"] = (int)s.Gender;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override Salesperson UnPack(PackedObject objectToUnpack)
        {
            var s = new Salesperson((Guid)objectToUnpack.Values["ID"],
                                    (Guid)objectToUnpack.Values["USERID"]);
            s.FirstName = objectToUnpack.Values["FN"].ToString();
            s.MiddleName = objectToUnpack.Values["MN"].ToString();
            s.LastName = objectToUnpack.Values["LN"].ToString();
            s.Email = objectToUnpack.Values["EMAIL"].ToString();
            s.PhoneNumber = objectToUnpack.Values["PNUM"].ToString();
            s.Gender = (GenderType)objectToUnpack.Values["GENDER"];

            return s;
        }

        /// <summary>
        /// Method maps a record from database to Merchandise object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Salesperson object.</returns>
        protected override Salesperson Map(IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid userId = (DBNull.Value == record["UserID"]) ?
                    Guid.Empty : Guid.Parse(record["UserID"].ToString());

                Salesperson sp = new Salesperson(id, userId);
                sp.FirstName = (DBNull.Value == record["FName"]) ?
                    string.Empty : record["FName"].ToString();
                sp.MiddleName = (DBNull.Value == record["MName"]) ?
                    string.Empty : record["MName"].ToString();
                sp.LastName = (DBNull.Value == record["LName"]) ?
                    string.Empty : record["LName"].ToString();
                sp.Gender = (DBNull.Value == record["Gender"]) ?
                    (GenderType)0 : (GenderType)int.Parse(record["Gender"].ToString());
                sp.PhoneNumber = (DBNull.Value == record["PhoneNumber"]) ?
                    string.Empty : record["PhoneNumber"].ToString();
                sp.Email = (DBNull.Value == record["Email"]) ?
                    string.Empty : record["Email"].ToString();

                var res = SDMReader.Reader.GetByQuery("SalespersonID='" + sp.ID + "'");
                sp.SDMs = res;

                return sp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}