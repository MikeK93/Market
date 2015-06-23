// --------------------------------------------------------------------------
// <copyright file="ServiceManager.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;
using System.Reflection;
using Market.Middleware;

namespace Market.ServiceCore
{
    /// <summary>
    /// Class represents service manager.
    /// </summary>
    public class ServiceManager : IMarket
    {
        ///
        /// private Assembly DAL = Assembly.LoadFile(@"D:\Files\Studying\Лабораторки\EXAMPLES\EpamClasses\Market\Market\Source\Market.DAL\bin\Debug\Market.DAL.dll");
        ///

        private IMarketCallback _callback;

        /// <summary>
        /// Ctor for creating new instance of a class.
        /// </summary>
        public ServiceManager()
        {
            _callback = OperationContext.Current.GetCallbackChannel<IMarketCallback>();
        }

        /// <summary>
        /// Gets data from a table by the type of an entity.
        /// </summary>
        /// <param name="dataType">Type of items to get.</param>
        /// <param name="mType">Type of a method to be executed.</param>
        /// <param name="query">Query for getting data from table, if mType = GetByQuery.</param>
        /// <param name="id">Id of an item to look up, if mType = GetById.</param>
        /// <returns>List of objects of type T</returns>
        public List<PackedObject> GetData(string dataType, MethodType mType, string query, Guid id)
        {
            try
            {
                var Reader = Type.GetType("Market.Readers." + dataType + "Reader, Market.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=90abf379a1faca66");
                var propertyReader = Reader.GetProperty("Reader", BindingFlags.Static | BindingFlags.Public);
                var res = (List<PackedObject>)propertyReader.PropertyType
                    .GetMethod("GetData")
                    .Invoke(propertyReader.GetValue(Reader, null), new object[] { dataType, mType, query, id });

                return res;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in type: " + GetType() + Environment.NewLine + "Error msg:" + e.Message);
                return null;
            }
        }
        
        /// <summary>
        /// Updates a data in table by an entity.
        /// </summary>
        /// <param name="packedObject">Object to update.</param>
        /// <param name="uType">Update type.</param>
        public void UpdateOne(PackedObject packedObject, UpdateType uType)
        {
            try
            {
                var Reader = Type.GetType("Market.Readers." + packedObject.POTypeName + "Reader, Market.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=90abf379a1faca66");
                var propertyReader = Reader.GetProperty("Reader", BindingFlags.Static | BindingFlags.Public);
                propertyReader.PropertyType
                    .GetMethod("UpdateOne")
                    .Invoke(propertyReader.GetValue(Reader, null), new object[] { packedObject, uType });
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in type: " + GetType() + Environment.NewLine + "Error msg:" + e.Message);
            }
        }

        /// <summary>
        /// Updates a data in table by a list of entities.
        /// </summary>
        /// <param name="packedObjects">Objects to update.</param>
        /// <param name="uType">Update type.</param>
        /// <rereturns>Number of updated items.</rereturns>
        public int UpdateList(List<PackedObject> packedObjects, UpdateType uType)
        {
            try
            {
                var Reader = Type.GetType("Market.Readers." + packedObjects[0].POTypeName + "Reader, Market.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=90abf379a1faca66");
                var propertyReader = Reader.GetProperty("Reader", BindingFlags.Static | BindingFlags.Public);
                var res = propertyReader.PropertyType
                   .GetMethod("UpdateList")
                   .Invoke(propertyReader.GetValue(Reader, null), new object[] { packedObjects, uType });

                return (int)res;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in type: " + GetType() + Environment.NewLine + "Error msg:" + e.Message);
                return 0;
            }
        }
    }
}