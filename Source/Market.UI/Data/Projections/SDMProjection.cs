// --------------------------------------------------------------------------
// <copyright file="SDMProjection.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Data;
using Market.Data.Entities;
using Market.Data.Mappers;

namespace Market.Data.Projections
{
    /// <summary>
    /// Class represents a projection from salesperon-dealer-merchandise.
    /// </summary>
    public class SDMProjection
    {
        private Guid _dmId;

        private Guid _sId;

        /// <summary>
        /// Initializes a new instance of a SDMProjection class.
        /// </summary>
        /// <param name="sId">Salesperson Id.</param>
        /// <param name="dmId">Dealer-Merchandise Id.</param>
        public SDMProjection(Guid sId, Guid dmId)
        {
            ID = Guid.NewGuid();
            _dmId = dmId;
            _sId = sId;
            Cost = DM.Cost;
        }

        /// <summary>
        /// Gets ID of an object.
        /// </summary>
        public Guid ID { get; private set; }

        /// <summary>
        /// Gets a Dealer-Merchandise object.
        /// </summary>
        public DM DM
        {
            get
            {
                return DMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("DM", Middleware.MethodType.GetById, string.Empty, _dmId)[0]);
            }
        }

        /// <summary>
        /// Gets a Salesperson object.
        /// </summary>
        public Salesperson Salesperson
        {
            get
            {
                return SalespersonMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Salesperson", Middleware.MethodType.GetById, string.Empty, _sId)[0]);
            }
        }

        /// <summary>
        /// Gets or sets a cost by salesperson.
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Shows text representation of a class.
        /// </summary>
        /// <returns>Merchandise' name and its cost.</returns>
        public override string ToString()
        { return DM.Merchandise + " ($" + Cost + ")"; }
    }
}