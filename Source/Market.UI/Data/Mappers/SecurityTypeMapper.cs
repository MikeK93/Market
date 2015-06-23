// --------------------------------------------------------------------------
// <copyright file="SecurityTypeMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a SecurityType class.
    /// </summary>
    public class SecurityTypeMapper : MapperBase<SecurityType>
    {
        private static SecurityTypeMapper _mapper;

        static SecurityTypeMapper() { _mapper = new SecurityTypeMapper(); }

        private SecurityTypeMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static SecurityTypeMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type to pack.</param>
        /// <returns>Packed object.</returns>
        public override PackedObject Pack(SecurityType objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["NAME"] = objToPack.Name;
            res.Values["GUARDS"] = objToPack.Guards;
            res.Values["COST"] = objToPack.Cost;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override SecurityType UnPack(PackedObject objectToUnpack)
        {
            var st = new SecurityType((Guid)objectToUnpack.Values["ID"],
                objectToUnpack.Values["NAME"].ToString(),
                (int)objectToUnpack.Values["GUARDS"],
                (float)objectToUnpack.Values["COST"]);

            return st;
        }
    }
}