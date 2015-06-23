// --------------------------------------------------------------------------
// <copyright file="BankSalespersonMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a relation Bank-Salesperson class.
    /// </summary>
    public class BankSalespersonMapper : MapperBase<BankSalesperson>
    {
        private static BankSalespersonMapper _mapper;

        static BankSalespersonMapper() { _mapper = new BankSalespersonMapper(); }

        private BankSalespersonMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static BankSalespersonMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type T to pack.</param>
        /// <returns>Packed item.</returns>
        public override PackedObject Pack(BankSalesperson objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["BANKID"] = objToPack.BankID;
            res.Values["SALESPERSONID"] = objToPack.SalespersonID;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override BankSalesperson UnPack(PackedObject objectToUnpack)
        {
            var bs = new BankSalesperson((Guid)objectToUnpack.Values["ID"],
                                         (Guid)objectToUnpack.Values["BANKID"],
                                         (Guid)objectToUnpack.Values["SALESPERSONID"]);

            return bs;
        }
    }
}