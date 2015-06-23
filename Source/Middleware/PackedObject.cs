// --------------------------------------------------------------------------
// <copyright file="PackedObject.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Market.Middleware
{
    /// <summary>
    /// Class represents a packed object.
    /// </summary>
    [DataContract]
    [KnownType(typeof(Guid))]
    [KnownType(typeof(Dictionary<string, object>))]
    public class PackedObject
    {
        private Dictionary<string, object> _values = new Dictionary<string, object>();

        /// <summary>
        /// Gets or sets values of packed object.
        /// </summary>
        [DataMember]
        public Dictionary<string, object> Values
        {
            get { return _values; }
            set { _values = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the object is new.
        /// </summary>
        [DataMember]
        public bool IsNew { get; set; }

        /// <summary>
        /// Gets or sets a type of packed object.
        /// </summary>
        [DataMember]
        public string POTypeName { get; set; }
    }
}