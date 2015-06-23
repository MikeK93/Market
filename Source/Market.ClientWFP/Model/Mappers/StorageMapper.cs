// --------------------------------------------------------------------------
// <copyright file="StorageMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for storage class.
    /// </summary>
    public class StorageMapper : MapperBase<Storage>
    {
        private static StorageMapper _mapper;

        static StorageMapper() { _mapper = new StorageMapper(); }

        private StorageMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static StorageMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type to pack.</param>
        /// <returns>Packed object.</returns>
        public override PackedObject Pack(Storage objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["ADDRESS"] = objToPack.Address;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override Storage UnPack(PackedObject objectToUnpack)
        {
            var s = new Storage((Guid)objectToUnpack.Values["ID"]);
            s.Address = objectToUnpack.Values["ADDRESS"].ToString();

            return s;
        }
    }
}