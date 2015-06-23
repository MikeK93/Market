// --------------------------------------------------------------------------
// <copyright file="SalespersonMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a Salesperson class.
    /// </summary>
    public class SalespersonMapper : MapperBase<Salesperson>
    {
        private static SalespersonMapper _mapper;

        static SalespersonMapper() { _mapper = new SalespersonMapper(); }

        private SalespersonMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static SalespersonMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Items of type T to pack.</param>
        /// <returns>Packed object.</returns>
        public override PackedObject Pack(Salesperson objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["FN"] = objToPack.FirstName;
            res.Values["MN"] = objToPack.MiddleName;
            res.Values["LN"] = objToPack.LastName;
            res.Values["EMAIL"] = objToPack.Email;
            res.Values["PNUM"] = objToPack.PhoneNumber;
            res.Values["USERID"] = objToPack.UserID;
            res.Values["GENDER"] = (int)objToPack.Gender;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override Salesperson UnPack(PackedObject objectToUnpack)
        {
            var s = new Salesperson((Guid)objectToUnpack.Values["ID"],
                                    (Guid)objectToUnpack.Values["USERID"]);
            s.FirstName = objectToUnpack.Values["FN"].ToString();
            s.MiddleName = objectToUnpack.Values["MN"].ToString();
            s.LastName = objectToUnpack.Values["LN"].ToString();
            s.Email = objectToUnpack.Values["EMAIL"].ToString();
            s.PhoneNumber = objectToUnpack.Values["PNUM"].ToString();
            s.Gender = (GenderType)objectToUnpack.Values["GENDER"];

            return s;
        }
    }
}