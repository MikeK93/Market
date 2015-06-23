// --------------------------------------------------------------------------
// <copyright file="MerchandiseToDealer.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities;

namespace Market.Projections
{
    /// <summary>
    /// Class represents a projection MerchandiseDealer.
    /// </summary>
    public class MerchandiseToDealer
    {
        private bool _forDealer = true;

        /// <summary>
        /// Gets or sets a value indicating whether the string representation should look like for dealer.
        /// </summary>
        public bool ForDealer
        {
            get { return _forDealer; }
            set { _forDealer = value; }
        }

        /// <summary>
        /// Gets or sets merchandise.
        /// </summary>
        public Merchandise Merchandise { get; set; }

        /// <summary>
        /// Gets or sets a dealer.
        /// </summary>
        public Dealer Dealer { get; set; }

        /// <summary>
        /// Gets or sets a cost.
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Shows info depends on bool value of ForDealer.
        /// </summary>
        /// <returns>If ForDealer true - Merchandise name and its cost. If ForDealer false - Dealer's first, middle, last names and his/her cost.</returns>
        public override string ToString()
        {
            string res = string.Empty;
            if (ForDealer)
                res = Merchandise.Name + " ($" + Cost + ")";
            else
                res = string.Format("{0} {1} {2} ${3}", Dealer.FirstName, Dealer.MiddleName, Dealer.LastName, Cost);
            return res;
        }
    }
}