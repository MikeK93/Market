// --------------------------------------------------------------------------
// <copyright file="User.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using Market.Mappers;
using Market.Readers;

namespace Market.Entities
{
    /// <summary>
    /// Enum indicates a role for a user.
    /// </summary>
    [DataContract]
    public enum Role
    {
        /// <summary>
        /// Customer role.
        /// </summary>
        [DataMember]
        Customer,

        /// <summary>
        /// Salesperson role.
        /// </summary>
        [DataMember]
        Salesperson,

        /// <summary>
        /// Dealer role.
        /// </summary>
        [DataMember]
        Dealer
    }

    /// <summary>
    /// Class represents a user.
    /// </summary>
    [DataContract(Namespace = "Market.Entities", Name = "User")]
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
        [DataMember]
        public Guid ID { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the User is new.
        /// </summary>
        [DataMember]
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        /// <summary>
        /// Gets or sets login.
        /// </summary>
        [DataMember]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets role for user.
        /// </summary>
        [DataMember]
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
                return UserReader.Reader.GetByQuery("PWord='" + pwr + "' AND Login='" + login + "'").ToList<User>().First();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Method saves user instance to a database.
        /// </summary>
        public void Save()
        { UserReader.Reader.Save(this, _isNew); }

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