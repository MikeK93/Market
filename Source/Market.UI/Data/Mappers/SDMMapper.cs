// --------------------------------------------------------------------------
// <copyright file="SDMMapper.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Market.Data;
using Market.Data.Entities;
using Market.Middleware;

namespace Market.Data.Mappers
{
    /// <summary>
    /// Class represents a mapper for a relation Salesperson-Dealer-Merchandise class.
    /// </summary>
    public class SDMMapper : MapperBase<SDM>
    {
        private static SDMMapper _mapper;

        static SDMMapper() { _mapper = new SDMMapper(); }

        private SDMMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static SDMMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type T to pack.</param>
        /// <returns>Packed object.</returns>
        public override PackedObject Pack(SDM objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["SALESPERSONID"] = objToPack.SalespersonID;
            res.Values["DMID"] = objToPack.DealerMerchandiseID;
            res.Values["COST"] = objToPack.Cost;
            res.IsNew = objToPack.IsNew;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override SDM UnPack(PackedObject objectToUnpack)
        {
            var sdm = new SDM((Guid)objectToUnpack.Values["ID"],
                              (Guid)objectToUnpack.Values["DMID"],
                              (Guid)objectToUnpack.Values["SALESPERSONID"]);
            sdm.Cost = (float)objectToUnpack.Values["COST"];
            sdm.IsNew = objectToUnpack.IsNew;

            return sdm;
        }
    }
}