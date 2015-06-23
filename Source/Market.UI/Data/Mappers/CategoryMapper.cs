// --------------------------------------------------------------------------
// <copyright file="CategoryMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a Category class.
    /// </summary>
    public class CategoryMapper : MapperBase<Category>
    {
        private static CategoryMapper _mapper;

        static CategoryMapper() { _mapper = new CategoryMapper(); }

        private CategoryMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static CategoryMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type T to pack.</param>
        /// <returns>Packed item.</returns>
        public override PackedObject Pack(Category objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["NAME"] = objToPack.Name;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override Category UnPack(PackedObject objectToUnpack)
        {
            var c = new Category((Guid)objectToUnpack.Values["ID"],
                                  objectToUnpack.Values["NAME"].ToString());

            return c;
        }
    }
}