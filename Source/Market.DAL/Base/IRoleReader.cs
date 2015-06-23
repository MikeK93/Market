// --------------------------------------------------------------------------
// <copyright file="IRoleReader.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using Market.Entities;

namespace Market.Core
{
    /// <summary>
    /// Interface for initializing roles for users.
    /// </summary>
    /// <typeparam name="T">Type of a role.</typeparam>
    /// <example>T: Customer, Dealer, Salesperson etc.</example>
    public interface IRoleReader<T>
    {
        /// <summary>
        /// Initialize role.
        /// </summary>
        /// <param name="user">User to initialize role from.</param>
        /// <returns>Class that represents a role.</returns>
        T InitializeRole(User user);
    }
}