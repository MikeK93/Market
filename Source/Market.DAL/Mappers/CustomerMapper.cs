// --------------------------------------------------------------------------
// <copyright file="CustomerMapper.cs" company="MK inc.">
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
using Market.Readers;

namespace Market.Mappers
{
    /// <summary>
    /// Class represents a mapper for a Customer class.
    /// </summary>
    public class CustomerMapper : MapperBase<Customer>
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
                schema["Age"] = record["Age"];
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
        /// Method maps a record from database to a Customer object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Customer object.</returns>
        public override Customer Map(DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid uId = (DBNull.Value == record["UserID"]) ?
                    Guid.Empty : Guid.Parse(record["UserID"].ToString());

                Customer c = new Customer(id, uId);

                c.FirstName = (DBNull.Value == record["FName"]) ?
                    string.Empty : record["FName"].ToString();
                c.MiddaleName = (DBNull.Value == record["MName"]) ?
                    string.Empty : record["MName"].ToString();
                c.LastName = (DBNull.Value == record["LName"]) ?
                    string.Empty : record["LName"].ToString();
                c.Age = (DBNull.Value == record["Age"]) ?
                    0 : int.Parse(record["Age"].ToString());
                c.Gender = (DBNull.Value == record["Gender"]) ?
                    (GenderType)0 : (GenderType)int.Parse(record["Gender"].ToString());
                c.PhoneNumber = (DBNull.Value == record["PhoneNumber"]) ?
                    string.Empty : record["PhoneNumber"].ToString();
                c.Email = (DBNull.Value == record["Email"]) ?
                    string.Empty : record["Email"].ToString();
                c.CSIs = CustomerSelectedItemsReader.Reader.GetByQuery("CustomerID='" + id + "'");

                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="item">Customer instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override DataRow UnMap(Customer item, DataRow record)
        {
            try
            {
                record["ID"] = item.ID.ToString();
                record["UserID"] = item.UserID.ToString();
                record["FName"] = item.FirstName.ToString();
                record["MName"] = item.MiddaleName.ToString();
                record["LName"] = item.LastName.ToString();
                record["Age"] = item.Age;
                record["Gender"] = (item.Gender == GenderType.Female) ? 0 : 1;
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
        public override List<PackedObject> Pack(List<Customer> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var c in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = c.GetType().Name;
                po.Values["ID"] = c.ID;
                po.Values["USERID"] = c.UserID;
                po.Values["FN"] = c.FirstName;
                po.Values["MN"] = c.MiddaleName;
                po.Values["LN"] = c.LastName;
                po.Values["AGE"] = c.Age;
                po.Values["GENDER"] = (int)c.Gender;
                po.Values["EMAIL"] = c.Email;
                po.Values["PNUM"] = c.PhoneNumber;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override Customer UnPack(PackedObject objectToUnpack)
        {
            var c = new Customer((Guid)objectToUnpack.Values["ID"],
                                 (Guid)objectToUnpack.Values["USERID"]);
            c.FirstName = objectToUnpack.Values["FN"].ToString();
            c.MiddaleName = objectToUnpack.Values["MN"].ToString();
            c.LastName = objectToUnpack.Values["LN"].ToString();
            c.Age = (int)objectToUnpack.Values["AGE"];
            c.Gender = (GenderType)objectToUnpack.Values["GENDER"];
            c.Email = objectToUnpack.Values["EMAIL"].ToString();
            c.PhoneNumber = objectToUnpack.Values["PNUM"].ToString();
            c.IsNew = objectToUnpack.IsNew;

            return c;
        }

        /// <summary>
        /// Method maps a record from database to a Customer object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Customer object.</returns>
        protected override Customer Map(IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid uId = (DBNull.Value == record["UserID"]) ?
                    Guid.Empty : Guid.Parse(record["UserID"].ToString());

                Customer c = new Customer(id, uId);

                c.FirstName = (DBNull.Value == record["FName"]) ?
                    string.Empty : record["FName"].ToString();
                c.MiddaleName = (DBNull.Value == record["MName"]) ?
                    string.Empty : record["MName"].ToString();
                c.LastName = (DBNull.Value == record["LName"]) ?
                    string.Empty : record["LName"].ToString();
                c.Age = (DBNull.Value == record["Age"]) ?
                    0 : int.Parse(record["Age"].ToString());
                c.Gender = (DBNull.Value == record["Gender"]) ?
                    (GenderType)0 : (GenderType)int.Parse(record["Gender"].ToString());
                c.PhoneNumber = (DBNull.Value == record["PhoneNumber"]) ?
                    string.Empty : record["PhoneNumber"].ToString();
                c.Email = (DBNull.Value == record["Email"]) ?
                    string.Empty : record["Email"].ToString();
                c.CSIs = CustomerSelectedItemsReader.Reader.GetByQuery("CustomerID='" + id + "'");

                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}