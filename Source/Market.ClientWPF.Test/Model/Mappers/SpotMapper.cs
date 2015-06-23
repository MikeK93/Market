// --------------------------------------------------------------------------
// <copyright file="SpotMapper.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Market.Model;
using Market.Model.Entities;
using Market.Middleware;

namespace Market.Model.Mappers
{
    /// <summary>
    /// Class represents a mapper for a Spot class.
    /// </summary>
    public class SpotMapper : MapperBase<Spot>
    {
        private static SpotMapper _mapper;

        static SpotMapper() { _mapper = new SpotMapper(); }

        private SpotMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static SpotMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type to pack.</param>
        /// <returns>Packed object.</returns>
        public override PackedObject Pack(Spot objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["DATESTART"] = objToPack.DateStart;
            res.Values["MAKERCOMPANYID"] = objToPack.MakerCompanyID;
            res.Values["SECURITYTYPEID"] = objToPack.SecurityTypeID;
            res.Values["SALESPERSONID"] = objToPack.SalespersonID;
            res.Values["NUMBER"] = objToPack.Number;
            res.Values["ADDRESS"] = objToPack.Address;
            res.IsNew = objToPack.IsNew;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override Spot UnPack(PackedObject objectToUnpack)
        {
            var s = new Spot((Guid)objectToUnpack.Values["ID"],
                DateTime.Parse(objectToUnpack.Values["DATESTART"].ToString()),
                (Guid)objectToUnpack.Values["MAKERCOMPANYID"],
                (Guid)objectToUnpack.Values["SECURITYTYPEID"],
                (Guid)objectToUnpack.Values["SALESPERSONID"]);
            s.Number = (int)objectToUnpack.Values["NUMBER"];
            s.Address = objectToUnpack.Values["ADDRESS"].ToString();


            return s;
        }
    }
}