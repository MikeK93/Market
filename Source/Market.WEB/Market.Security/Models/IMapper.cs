// --------------------------------------------------------------------------
// <copyright file="MapperBase.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Middleware;

namespace Market.Security.Models
{
    /// <summary>
    /// Interface for mapper for specified class.
    /// </summary>
    /// <typeparam name="T">Class that have to be mapped.</typeparam>
    public abstract class MapperBase<T>
    {
        /// <summary>
        /// Method packs item of type T into item of type PackedObject.
        /// </summary>
        /// <param name="objToPack">Item of type T to pack.</param>
        /// <returns>Packed object.</returns>
        public abstract PackedObject Pack(T objToPack);

        /// <summary>
        /// Method packs list of items T into list of items PackedObject.
        /// </summary>
        /// <param name="objectsToPack">List of items to pack.</param>
        /// <returns>List of packed objects.</returns>
        public List<PackedObject> Pack(List<T> objectsToPack)
        {
            var res = new List<PackedObject>();
            foreach (var objToPack in objectsToPack)
                res.Add(Pack(objToPack));

            return res;
        }

        /// <summary>
        /// Method unpacks item of type PackedObject into item of type T.
        /// </summary>
        /// <param name="objectToUnpack">Item to unpack of type PackedObject.</param>
        /// <returns>Unpacked item of type T.</returns>
        public abstract T UnPack(PackedObject objectToUnpack);

        /// <summary>
        /// Method unpacks list of item of type PackedObject into list of items of type T.
        /// </summary>
        /// <param name="objectsToUnpack">List of items to unpack of type PackedObject.</param>
        /// <returns>Unpacked list of items of type T.</returns>
        public List<T> UnPack(List<PackedObject> objectsToUnpack)
        {
            var res = new List<T>();
            foreach (var objToUnpack in objectsToUnpack)
                res.Add(UnPack(objToUnpack));

            return res;
        }
    }
}