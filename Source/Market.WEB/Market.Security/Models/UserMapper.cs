// --------------------------------------------------------------------------
// <copyright file="UserMapper.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Market.Middleware;

namespace Market.Security.Models
{
    /// <summary>
    /// Class represents a mapper for user.
    /// </summary>
    public class UserMapper : MapperBase<User>
    {
        private static UserMapper _mapper;

        static UserMapper() { _mapper = new UserMapper(); }

        private UserMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static UserMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToUnpack">Item of type T to pack.</param>
        /// <returns>Packed object.</returns>
        public override PackedObject Pack(User objToUnpack)
        {
            var res = new PackedObject();
            res.POTypeName = objToUnpack.GetType().Name;
            res.Values["ID"] = objToUnpack.ID;
            res.Values["LOGIN"] = objToUnpack.Login;
            res.Values["PWD"] = objToUnpack.Password;
            res.Values["ROLE"] = (int)objToUnpack.Role;
            res.IsNew = objToUnpack.IsNew;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override User UnPack(PackedObject objectToUnpack)
        {
            var u = new User((Guid)objectToUnpack.Values["ID"]);
            u.Login = objectToUnpack.Values["LOGIN"].ToString();
            u.Password = objectToUnpack.Values["PWD"].ToString();
            u.Role = (Role)objectToUnpack.Values["ROLE"];
            u.IsNew = objectToUnpack.IsNew;

            return u;
        }
    }
}