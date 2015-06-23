// --------------------------------------------------------------------------
// <copyright file="MerchandiseMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for Merchandise class.
    /// </summary>
    public class MerchandiseMapper : MapperBase<Merchandise>
    {
        private static MerchandiseMapper _mapper;

        static MerchandiseMapper() { _mapper = new MerchandiseMapper(); }

        private MerchandiseMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static MerchandiseMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Items of type to pack.</param>
        /// <returns>Packed item.</returns>
        public override PackedObject Pack(Merchandise objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["STORAGEID"] = objToPack.StorageID;
            res.Values["NAME"] = objToPack.Name;
            res.Values["COST"] = objToPack.Cost;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override Merchandise UnPack(PackedObject objectToUnpack)
        {
            var m = new Merchandise((Guid)objectToUnpack.Values["ID"],
                                    (Guid)objectToUnpack.Values["STORAGEID"]);
            m.Name = objectToUnpack.Values["NAME"].ToString();
            m.Cost = (float)objectToUnpack.Values["COST"];

            return m;
        }
    }
}