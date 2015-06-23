// --------------------------------------------------------------------------
// <copyright file="DealerMapper.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Linq;
using Market.Data;
using Market.Data.Entities;
using Market.Middleware;

namespace Market.Data.Mappers
{
    /// <summary>
    /// Class represents a mapper for a Dealer class.
    /// </summary>
    public class DealerMapper : MapperBase<Dealer>
    {
        private static DealerMapper _mapper;

        static DealerMapper() { _mapper = new DealerMapper(); }

        private DealerMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static DealerMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type T to pack.</param>
        /// <returns>Packed item.</returns>
        public override PackedObject Pack(Dealer objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["USERID"] = objToPack.UserID;
            res.Values["FN"] = objToPack.FirstName;
            res.Values["MN"] = objToPack.MiddleName;
            res.Values["LN"] = objToPack.LastName;
            res.Values["EMAIL"] = objToPack.Email;
            res.Values["PNUM"] = objToPack.PhoneNumber;
            res.Values["GENDER"] = (int)objToPack.Gender;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override Dealer UnPack(PackedObject objectToUnpack)
        {
            var d = new Dealer((Guid)objectToUnpack.Values["ID"],
                               (Guid)objectToUnpack.Values["USERID"]);
            d.FirstName = objectToUnpack.Values["FN"].ToString();
            d.MiddleName = objectToUnpack.Values["MN"].ToString();
            d.LastName = objectToUnpack.Values["LN"].ToString();
            d.Email = objectToUnpack.Values["EMAIL"].ToString();
            d.PhoneNumber = objectToUnpack.Values["PNUM"].ToString();
            d.Gender = (GenderType)objectToUnpack.Values["GENDER"];

            return d;
        }
    }
}