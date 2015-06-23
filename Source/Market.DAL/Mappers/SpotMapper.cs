// --------------------------------------------------------------------------
// <copyright file="SpotMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a Spot class.
    /// </summary>
    public class SpotMapper : MapperBase<Spot>
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
                schema["MakerID"] = record["MakerID"];
                schema["SecurityTypeID"] = record["SecurityTypeID"];
                schema["SalespersonID"] = (record["SalespersonID"] == DBNull.Value) ? Guid.Empty.ToString() : record["SalespersonID"];
                schema["DateStart"] = record["DateStart"];
                schema["Number"] = record["Number"];
                schema["Address"] = record["Address"];

                return schema;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method maps a record from database to a Spot object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Spot object.</returns>
        public override Spot Map(DataRow record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid mcId = (DBNull.Value == record["MakerID"]) ?
                    Guid.Empty : Guid.Parse(record["MakerID"].ToString());
                Guid stId = (DBNull.Value == record["SecurityTypeID"]) ?
                    Guid.Empty : Guid.Parse(record["SecurityTypeID"].ToString());
                Guid sId = (DBNull.Value == record["SalespersonID"]) ?
                    Guid.Empty : Guid.Parse(record["SalespersonID"].ToString());
                DateTime start = (DBNull.Value == record["DateStart"]) ?
                    DateTime.MinValue : DateTime.Parse(record["DateStart"].ToString());
                int numba = (DBNull.Value == record["Number"]) ?
                    0 : int.Parse(record["Number"].ToString());

                Spot s = new Spot(id, start, mcId, stId, sId);
                s.Number = numba;
                s.Address = record["Address"].ToString();

                return s;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method unmaps storaje object to record in database.
        /// </summary>
        /// <param name="s">Spot class instance.</param>
        /// <param name="record">Record in table.</param>
        /// <returns>DataRow object.</returns>
        public override DataRow UnMap(Spot s, DataRow record)
        {
            try
            {
                record["ID"] = s.ID.ToString();
                record["MakerID"] = s.MakerCompanyID.ToString();
                record["SecurityTypeID"] = s.SecurityTypeID.ToString();
                record["SalespersonID"] = s.SalespersonID == Guid.Empty ? (object)DBNull.Value : s.SalespersonID.ToString();
                record["DateStart"] = s.DateStart.ToString();
                record["Number"] = s.Number;
                record["Address"] = s.Address;

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
        public override List<PackedObject> Pack(List<Spot> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var s in objectsToPack)
            {
                var po = new PackedObject();
                po.POTypeName = s.GetType().Name;
                po.Values["ID"] = s.ID;
                po.Values["NUMBER"] = s.Number;
                po.Values["SALESPERSONID"] = s.SalespersonID;
                po.Values["SECURITYTYPEID"] = s.SecurityTypeID;
                po.Values["DATESTART"] = s.DateStart.ToString();
                po.Values["MAKERCOMPANYID"] = s.MakerCompanyID;
                po.Values["ADDRESS"] = s.Address;
                po.IsNew = s.IsNew;
                res.Add(po);
            }

            return res;
        }

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public override Spot UnPack(PackedObject objectToUnpack)
        {
            var s = new Spot((Guid)objectToUnpack.Values["ID"],
                             (DateTime)objectToUnpack.Values["DATESTART"],
                             (Guid)objectToUnpack.Values["MAKERCOMPANYID"],
                             (Guid)objectToUnpack.Values["SECURITYTYPEID"],
                             (Guid)objectToUnpack.Values["SALESPERSONID"]);
            s.Number = (int)objectToUnpack.Values["NUMBER"];
            s.Address = objectToUnpack.Values["ADDRESS"].ToString();
            s.IsNew = objectToUnpack.IsNew;

            return s;
        }

        /// <summary>
        /// Method maps a record from database to a Spot object.
        /// </summary>
        /// <param name="record">Record form a database.</param>
        /// <returns>Spot object.</returns>
        protected override Spot Map(System.Data.IDataRecord record)
        {
            try
            {
                Guid id = (DBNull.Value == record["ID"]) ?
                    Guid.Empty : Guid.Parse(record["ID"].ToString());
                Guid mcId = (DBNull.Value == record["MakerID"]) ?
                    Guid.Empty : Guid.Parse(record["MakerID"].ToString());
                Guid stId = (DBNull.Value == record["SecurityTypeID"]) ?
                    Guid.Empty : Guid.Parse(record["SecurityTypeID"].ToString());
                Guid sId = (DBNull.Value == record["SalespersonID"]) ?
                    Guid.Empty : Guid.Parse(record["SalespersonID"].ToString());
                DateTime start = (DBNull.Value == record["DateStart"]) ?
                    DateTime.MinValue : DateTime.Parse(record["DateStart"].ToString());
                int numba = (DBNull.Value == record["Number"]) ?
                    0 : int.Parse(record["Number"].ToString());

                Spot s = new Spot(id, start, mcId, stId, sId);
                s.Number = numba;
                s.Address = record["Address"].ToString();

                return s;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}