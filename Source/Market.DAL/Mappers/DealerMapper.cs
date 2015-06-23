// --------------------------------------------------------------------------
// <copyright file="DealerMapper.cs" company="MK inc.">
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
using Market.Readers;

namespace Market.Mappers
{
    /// <summary>
    /// Class represents a mapper for a Dealer class.
    /// </summary>
    public class DealerMapper : MapperBase<Dealer>
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
        /// Method maps a record from database to a Dealer object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Dealer object.</returns>
        public override Dealer Map(DataRow record)
        {
            try
            {
                Guid id = DBNull.Value == record["ID"] ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid userId = DBNull.Value == record["UserID"] ?
                    Guid.Empty : Guid.Parse(record["UserID"].ToString());

                Dealer d = new Dealer(id, userId);
                d.FirstName = DBNull.Value == record["FName"] ?
                    string.Empty : record["FName"].ToString();
                d.MiddleName = DBNull.Value == record["MName"] ?
                    string.Empty : record["MName"].ToString();
                d.LastName = DBNull.Value == record["LName"] ?
                    string.Empty : record["LName"].ToString();
                d.Gender = DBNull.Value == record["Gender"] ?
                    (GenderType)0 : (GenderType)int.Parse(record["Gender"].ToString());
                d.PhoneNumber = DBNull.Value == record["PhoneNumber"] ?
                    string.Empty : record["PhoneNumber"].ToString();
                d.Email = DBNull.Value == record["Email"] ?
                    string.Empty : record["Email"].ToString();
                d.AllMerchandise = new List<Merchandise>();
                var merchendise = DMReader.Reader.GetByQuery("DealerID='" + id + "'");
                foreach (DM dm in merchendise)
                    d.AllMerchandise.Add(dm.Merchandise);

                return d;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="item">Dealer class instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override DataRow UnMap(Dealer item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["FName"] = item.FirstName.ToString();
                record["MName"] = item.MiddleName.ToString();
                record["LName"] = item.LastName.ToString();
                record["Gender"] = (int)item.Gender;
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
        public override List<PackedObject> Pack(List<Dealer> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var d in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = d.GetType().Name;
                po.Values["ID"] = d.ID;
                po.Values["USERID"] = d.UserID;
                po.Values["FN"] = d.FirstName;
                po.Values["MN"] = d.MiddleName;
                po.Values["LN"] = d.LastName;
                po.Values["EMAIL"] = d.Email;
                po.Values["PNUM"] = d.PhoneNumber;
                po.Values["GENDER"] = (int)d.Gender;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override Dealer UnPack(PackedObject objectToUnpack)
        {
            var d = new Dealer((Guid)objectToUnpack.Values["ID"],
                               (Guid)objectToUnpack.Values["USERID"]);
            d.FirstName = objectToUnpack.Values["FN"].ToString();
            d.MiddleName = objectToUnpack.Values["MN"].ToString();
            d.LastName = objectToUnpack.Values["LN"].ToString();
            d.Email = objectToUnpack.Values["EMAIL"].ToString();
            d.PhoneNumber = objectToUnpack.Values["PNUM"].ToString();
            d.Gender = (GenderType)objectToUnpack.Values["GENDER"];

            return d;
        }

        /// <summary>
        /// Method maps a record from database to a Dealer object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Dealer object.</returns>
        protected override Dealer Map(IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid userId = (DBNull.Value == record["UserID"]) ?
                    Guid.Empty : Guid.Parse(record["UserID"].ToString());

                Dealer d = new Dealer(id, userId);
                d.FirstName = (DBNull.Value == record["FName"]) ?
                    string.Empty : record["FName"].ToString();
                d.MiddleName = (DBNull.Value == record["MName"]) ?
                    string.Empty : record["MName"].ToString();
                d.LastName = (DBNull.Value == record["LName"]) ?
                    string.Empty : record["LName"].ToString();
                d.Gender = (DBNull.Value == record["Gender"]) ?
                    (GenderType)0 : (GenderType)int.Parse(record["Gender"].ToString());
                d.PhoneNumber = (DBNull.Value == record["PhoneNumber"]) ?
                    string.Empty : record["PhoneNumber"].ToString();
                d.Email = (DBNull.Value == record["Email"]) ?
                    string.Empty : record["Email"].ToString();
                d.AllMerchandise = new List<Merchandise>();
                var merchendise = DMReader.Reader.GetByQuery("DealerID='" + id + "'");
                foreach (DM dm in merchendise)
                    d.AllMerchandise.Add(dm.Merchandise);

                return d;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}