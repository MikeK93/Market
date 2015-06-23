// --------------------------------------------------------------------------
// <copyright file="DMMapper.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Market.Middleware;
using Market.Data.Entities;
using Market.Data;

namespace Market.Data.Mappers
{
    /// <summary>
    /// Class represents a mapper for a relation Dealer-Merchandise class.
    /// </summary>
    public class DMMapper : MapperBase<DM>
    {
        private static DMMapper _mapper;

        static DMMapper() { _mapper = new DMMapper(); }

        private DMMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static DMMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type T to pack.</param>
        /// <returns>Packed item.</returns>
        public override PackedObject Pack(DM objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["DEALERID"] = objToPack.DealerID;
            res.Values["MERCHANDISEID"] = objToPack.MerchandiseID;
            res.Values["COST"] = objToPack.Cost;
            res.IsNew = objToPack.IsNew;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override DM UnPack(PackedObject objectToUnpack)
        {
            var dm = new DM((Guid)objectToUnpack.Values["ID"],
                            (Guid)objectToUnpack.Values["DEALERID"],
                            (Guid)objectToUnpack.Values["MERCHANDISEID"]);
            dm.Cost = (float)objectToUnpack.Values["COST"];
            dm.IsNew = objectToUnpack.IsNew;

            return dm;
        }
    }
}