// --------------------------------------------------------------------------
// <copyright file="SpotSDMMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a relation Spot-[Salesperson-[Dealer-Merchandise]] class.
    /// </summary>
    public class SpotSDMMapper : MapperBase<SpotSDM>
    {
        private static SpotSDMMapper _mapper;

        static SpotSDMMapper() { _mapper = new SpotSDMMapper(); }

        private SpotSDMMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static SpotSDMMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type T to pack.</param>
        /// <returns>Packed object.</returns>
        public override PackedObject Pack(SpotSDM objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["SPOTID"] = objToPack.SpotID;
            res.Values["SDMID"] = objToPack.SDMID;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override SpotSDM UnPack(PackedObject objectToUnpack)
        {
            var ssdm = new SpotSDM((Guid)objectToUnpack.Values["ID"],
                                   (Guid)objectToUnpack.Values["SPOTID"],
                                   (Guid)objectToUnpack.Values["SDMID"]);

            return ssdm;
        }
    }
}