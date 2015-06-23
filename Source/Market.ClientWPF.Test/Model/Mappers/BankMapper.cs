// --------------------------------------------------------------------------
// <copyright file="BankMapper.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using Market.Model;
using Market.Model.Entities;
using Market.Middleware;

namespace Market.Model.Mappers
{
    /// <summary>
    /// Class represents a mapper for Bank class.
    /// </summary>
    public class BankMapper : MapperBase<Bank>
    {
        private static BankMapper _mapper;

        static BankMapper() { _mapper = new BankMapper(); }

        private BankMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static BankMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type T to pack.</param>
        /// <returns>Packed item.</returns>
        public override PackedObject Pack(Bank objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["ADDRESS"] = objToPack.Address;
            res.Values["NAME"] = objToPack.Name;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override Bank UnPack(PackedObject objectToUnpack)
        {
            Bank b = new Bank((Guid)objectToUnpack.Values["ID"]);
            b.Address = objectToUnpack.Values["ADDRESS"].ToString();
            b.Name = objectToUnpack.Values["NAME"].ToString();

            return b;
        }
    }
}