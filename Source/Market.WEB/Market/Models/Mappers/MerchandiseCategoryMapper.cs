// --------------------------------------------------------------------------
// <copyright file="MerchandiseCategoryMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a relation Merchandise-Category class.
    /// </summary>
    public class MerchandiseCategoryMapper : MapperBase<MerchandiseCategory>
    {
        private static MerchandiseCategoryMapper _mapper;

        static MerchandiseCategoryMapper() { _mapper = new MerchandiseCategoryMapper(); }

        private MerchandiseCategoryMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static MerchandiseCategoryMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type to pack.</param>
        /// <returns>Packed item.</returns>
        public override PackedObject Pack(MerchandiseCategory objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["MERCHANDISEID"] = objToPack.MerchandiseID;
            res.Values["CATEGORYID"] = objToPack.CategoryID;
            res.IsNew = objToPack.IsNew;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override MerchandiseCategory UnPack(PackedObject objectToUnpack)
        {
            var mc = new MerchandiseCategory((Guid)objectToUnpack.Values["ID"],
                                             (Guid)objectToUnpack.Values["MERCHANDISEID"],
                                             (Guid)objectToUnpack.Values["CATEGORYID"]);
            return mc;
        }
    }
}