// --------------------------------------------------------------------------
// <copyright file="CustomerMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a Customer class.
    /// </summary>
    public class CustomerMapper : MapperBase<Customer>
    {
        private static CustomerMapper _mapper;

        static CustomerMapper() { _mapper = new CustomerMapper(); }

        private CustomerMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static CustomerMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs list of items T into list of items PackedObject.
        /// </summary>
        /// <param name="objToPack">List of items to pack.</param>
        /// <returns>List of packed objects.</returns>
        public override PackedObject Pack(Customer objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["USERID"] = objToPack.UserID;
            res.Values["FN"] = objToPack.FirstName;
            res.Values["MN"] = objToPack.MiddaleName;
            res.Values["LN"] = objToPack.LastName;
            res.Values["AGE"] = objToPack.Age;
            res.Values["GENDER"] = (int)objToPack.Gender;
            res.Values["EMAIL"] = objToPack.Email;
            res.Values["PNUM"] = objToPack.PhoneNumber;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override Customer UnPack(PackedObject objectToUnpack)
        {
            var c = new Customer((Guid)objectToUnpack.Values["ID"],
                                 (Guid)objectToUnpack.Values["USERID"]);
            c.FirstName = objectToUnpack.Values["FN"].ToString();
            c.MiddaleName = objectToUnpack.Values["MN"].ToString();
            c.LastName = objectToUnpack.Values["LN"].ToString();
            c.Age = (int)objectToUnpack.Values["AGE"];
            c.Gender = (GenderType)objectToUnpack.Values["GENDER"];
            c.Email = objectToUnpack.Values["EMAIL"].ToString();
            c.PhoneNumber = objectToUnpack.Values["PNUM"].ToString();

            return c;
        }
    }
}