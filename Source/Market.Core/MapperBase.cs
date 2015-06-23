// --------------------------------------------------------------------------
// <copyright file="MapperBase.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using Market.Middleware;

namespace Market.Core
{
    /// <summary>
    /// Class represents a mapper for object with type T.
    /// </summary>
    /// <typeparam name="T">Type of object for which a mapper is applied.</typeparam>
    public abstract class MapperBase<T>
        where T : class
    {
        /// <summary>
        /// Method maps a record from database to an object with type T.
        /// </summary>
        /// <param name="record">Record from database.</param>
        /// <returns>Object with type T.</returns>
        public abstract T Map(DataRow record);

        /// <summary>
        /// Method unmaps an object with type T.
        /// </summary>
        /// <param name="item">Object from which to unmap a data.</param>
        /// <param name="record">Schema for creating new row.</param>
        /// <returns>Unmaped DataRow.</returns>
        public abstract DataRow UnMap(T item, DataRow record);

        /// <summary>
        /// Method generates a new row and adds to a cache table.
        /// </summary>
        /// <param name="record">Data from database.</param>
        /// <param name="schema">Table schema.</param>
        /// <returns>A new data row with data.</returns>
        public abstract DataRow GenerateRow(IDataRecord record, DataRow schema);

        #region For Client-Server

        /// <summary>
        /// Method packs all data of list with objects of type T into a list of PackedObject.
        /// </summary>
        /// <param name="objectsToPack">List of objects to pack.</param>
        /// <returns>List of packed objects.</returns>
        public abstract List<PackedObject> Pack(List<T> objectsToPack);

        /// <summary>
        /// Method unpacks object to type T.
        /// </summary>
        /// <param name="objectToUnpack">Object to unpack.</param>
        /// <returns>Unpaked object of type T.</returns>
        public abstract T UnPack(PackedObject objectToUnpack);

        /// <summary>
        /// Method unpacks data from list of PackedObjects.
        /// </summary>
        /// <param name="objectsToUnpack">List of objects to unpack.</param>
        /// <returns>List of objects of type T.</returns>
        public List<T> UnPack(List<PackedObject> objectsToUnpack)
        {
            var res = new List<T>();
            foreach (var item in objectsToUnpack)
                res.Add(UnPack(item));

            return res;
        }

        #endregion

        /// <summary>
        /// Method maps a group of records from database to a list of object of type T.
        /// </summary>
        /// <param name="reader">Reader with data.</param>
        /// <returns>List of objects of type T.</returns>
        public List<T> MapAll(IDataReader reader)
        {
            List<T> res = new List<T>();

            while (reader.Read())
            {
                try
                {
                    res.Add(Map(reader));
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return res;
        }

        /// <summary>
        /// Method maps a group of records from database to a list of object of type T.
        /// </summary>
        /// <param name="rows">An array of DataRow with data.</param>
        /// <returns>List of objects of type T.</returns>
        public List<T> MapAll(DataRow[] rows)
        {
            List<T> res = new List<T>();

            try
            {
                foreach (DataRow r in rows)
                    res.Add(Map(r));
            }
            catch (Exception e)
            {
                throw e;
            }

            return res;
        }

        /// <summary>
        /// Method unmaps a list of object of type T to a list of dataRows.
        /// </summary>
        /// <param name="items">List of objects of type T.</param>
        /// <param name="record">Schema for creating new row.</param>
        /// <returns>Unmaped list of DataRows.</returns></returns>
        public List<DataRow> UnMapAll(List<T> items, DataRow record)
        {
            var res = new List<DataRow>();

            try
            {
                foreach (T item in items)
                    res.Add(UnMap(item, record));
            }
            catch (Exception e)
            {
                throw e;
            }

            return res;
        }

        /// <summary>
        /// Method maps a record from database to an object with type T.
        /// </summary>
        /// <param name="record">Record from database.</param>
        /// <returns>Object with type T.</returns>
        protected abstract T Map(IDataRecord record);
    }
}