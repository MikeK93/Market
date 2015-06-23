// --------------------------------------------------------------------------
// <copyright file="User.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using Market.Middleware;

namespace Market.Security.Models
{
    /// <summary>
    /// Enum indicates a role for a user.
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// Customer role.
        /// </summary>
        Customer,

        /// <summary>
        /// Salesperson role.
        /// </summary>
        Salesperson,

        /// <summary>
        /// Dealer role.
        /// </summary>
        Dealer
    }

    /// <summary>
    /// Class represents a user.
    /// </summary>
    public class User
    {
        private bool _isNew = false;

        /// <summary>
        /// Initialize a new instance of a <see cref="User"/> class.
        /// </summary>
        public User()
        {
            _isNew = true;
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// Initialize a new instance of a <see cref="User"/> class.
        /// </summary>
        /// <param name="id">ID of a user in database.</param>
        public User(Guid id)
        {
            ID = id;
            _isNew = false;
        }

        /// <summary>
        /// Gets ID of current user.
        /// </summary>
        public Guid ID { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the User is new.
        /// </summary>
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        /// <summary>
        /// Gets or sets login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets role for user.
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Method gets user by its password and login from database.
        /// </summary>
        /// <param name="login">User's login.</param>
        /// <param name="pwr">User's password.</param>
        /// <returns>User instance if such user exists unless null.</returns>
        public static User GetByLoginPassword(string login, string pwr)
        {
            try
            {
                var allUsers = MarketProxy.Proxy.GetData("User", Middleware.MethodType.GetByQuery, "PWord='" + pwr + "' AND Login='" + login + "'", Guid.Empty);
                var res = UserMapper.Mapper.UnPack(allUsers[0]);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Method saves user instance to a database.
        /// </summary>
        public void Save()
        { MarketProxy.Proxy.UpdateOne(UserMapper.Mapper.Pack(this), Middleware.UpdateType.Save); }

        /// <summary>
        /// Method equals two instance of a bank class.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if the parameter is equal to a current bank object.</returns>
        public override bool Equals(object obj)
        {
            User u = obj as User;
            if (u == null) return false;
            if (u.ID == ID &&
                u.Login == Login &&
                u.Password == Password &&
                u.Role == Role) return true;
            return false;
        }

        /// <summary>
        /// Gets a hash code of an object.
        /// </summary>
        /// <returns>Hash code of an object.</returns>
        public override int GetHashCode()
        { return base.GetHashCode(); }

        /// <summary>
        /// Shows text representation of a class.
        /// </summary>
        /// <returns>Login of a current user.</returns>
        public override string ToString()
        { return Login; }
    }
}