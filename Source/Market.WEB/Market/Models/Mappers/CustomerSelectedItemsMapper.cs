// --------------------------------------------------------------------------
// <copyright file="CustomerSelectedItemsMapper.cs" company="MK inc.">
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
    /// Class represents a mapper for a relation Customer-SelectedItems class.
    /// </summary>
    public class CustomerSelectedItemsMapper : MapperBase<CustomerSelectedItems>
    {
        private static CustomerSelectedItemsMapper _mapper;

        static CustomerSelectedItemsMapper() { _mapper = new CustomerSelectedItemsMapper(); }

        private CustomerSelectedItemsMapper() { }

        /// <summary>
        /// Gets a instance of a class.
        /// </summary>
        public static CustomerSelectedItemsMapper Mapper { get { return _mapper; } }

        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type T to pack.</param>
        /// <returns>Packed item.</returns>
        public override PackedObject Pack(CustomerSelectedItems objToPack)
        {
            var res = new PackedObject();
            res.POTypeName = objToPack.GetType().Name;
            res.Values["ID"] = objToPack.ID;
            res.Values["CUSTOMERID"] = objToPack.CustomerID;
            res.Values["SDMID"] = objToPack.SDMID;
            res.Values["ISSUBMITED"] = objToPack.IsSubmited;
            res.IsNew = objToPack.IsNew;

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public override CustomerSelectedItems UnPack(PackedObject objectToUnpack)
        {
            var csi = new CustomerSelectedItems((Guid)objectToUnpack.Values["ID"],
                                                (Guid)objectToUnpack.Values["CUSTOMERID"],
                                                (Guid)objectToUnpack.Values["SDMID"]);
            csi.IsSubmited = Convert.ToBoolean(objectToUnpack.Values["ISSUBMITED"]);
            csi.IsNew = objectToUnpack.IsNew;

            return csi;
        }
    }
}