// --------------------------------------------------------------------------
// <copyright file="MakerCompanyMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a MakerCompany class.
    /// </summary>
    public class MakerCompanyMapper : MapperBase<MakerCompany>
    {
        private static MakerCompanyMapper _mapper;

        static MakerCompanyMapper() { _mapper = new MakerCompanyMapper(); }

        private MakerCompanyMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static MakerCompanyMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type to pack.</param>
        /// <returns>Packed item.</returns>
        public override PackedObject Pack(MakerCompany objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["NAME"] = objToPack.Name;
            res.Values["ADDRESS"] = objToPack.Address;
            res.Values["CITY"] = objToPack.City;
            res.Values["COUNTRY"] = objToPack.Country;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override MakerCompany UnPack(PackedObject objectToUnpack)
        {
            var mc = new MakerCompany((Guid)objectToUnpack.Values["ID"]);

            mc.Name = objectToUnpack.Values["NAME"].ToString();
            mc.Address = objectToUnpack.Values["ADDRESS"].ToString();
            mc.City = objectToUnpack.Values["CITY"].ToString();
            mc.Country = objectToUnpack.Values["COUNTRY"].ToString();

            return mc;
        }
    }
}