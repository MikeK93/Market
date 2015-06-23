// --------------------------------------------------------------------------
// <copyright file="BankDealerMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for relation Bank-Dealer class.
    /// </summary>
    public class BankDealerMapper : MapperBase<BankDealer>
    {
        private static BankDealerMapper _mapper;

        static BankDealerMapper() { _mapper = new BankDealerMapper(); }

        private BankDealerMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static BankDealerMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objectsToPack">Item to pack.</param>
        /// <returns>Packed objects.</returns>
        public override PackedObject Pack(BankDealer objectsToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objectsToPack.GetType().Name;
            res.Values["ID"] = objectsToPack.ID;
            res.Values["BANKID"] = objectsToPack.BankID;
            res.Values["DEALERID"] = objectsToPack.DealerID;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override BankDealer UnPack(PackedObject objectToUnpack)
        {
            var bd = new BankDealer((Guid)objectToUnpack.Values["ID"],
                                              (Guid)objectToUnpack.Values["BANKID"],
                                              (Guid)objectToUnpack.Values["DEALERID"]);

            return bd;
        }
    }
}