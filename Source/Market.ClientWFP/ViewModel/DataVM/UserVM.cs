// --------------------------------------------------------------------------
// <copyright file="User.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using Command.ViewModel.Base;
using Market.Middleware;
using Market.Model;
using Market.Model.Entities;
using Market.Model.Mappers;

namespace Market.ViewModel.DataVM
{
    /// <summary>
    /// Class represents a user.
    /// </summary>
    public class UserVM : BaseVM
    {
        private User _user;

        /// <summary>
        /// Initialize a new instance of a <see cref="User"/> class.
        /// </summary>
        public UserVM()
        {
            _user = new User();
        }

        /// <summary>
        /// Ctor for creating new instance of UserVM by instance of User.
        /// </summary>
        /// <param name="user">Instance of User.</param>
        public UserVM(User user)
        {
            _user = user;
        }

        /// <summary>
        /// Initialize a new instance of a <see cref="User"/> class.
        /// </summary>
        /// <param name="id">ID of a user in database.</param>
        public UserVM(Guid id)
        {
            _user = new User(id);
        }

        /// <summary>
        /// Gets ID of current user.
        /// </summary>
        public Guid ID { get { return _user.ID; } }

        /// <summary>
        /// Gets or sets a value indicating whether the User is new.
        /// </summary>
        public bool IsNew
        {
            get { return _user.IsNew; }
            set { _user.IsNew = value; }
        }

        /// <summary>
        /// Gets or sets login.
        /// </summary>
        public string Login
        {
            get { return _user.Login; }
            set
            {
                if (value == _user.Login)
                    return;

                _user.Login = value;
                OnPropertyChanged("Login");
            }
        }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        public string Password
        {
            get { return _user.Password; }
            set
            {
                if (value == _user.Password)
                    return;

                _user.Password = value;
                OnPropertyChanged("Password");
            }
        }

        /// <summary>
        /// Gets or sets role for user.
        /// </summary>
        public Role Role
        {
            get { return _user.Role; }
            set { _user.Role = value; }
        }

        /// <summary>
        /// Method gets user by its password and login from database.
        /// </summary>
        /// <param name="login">User's login.</param>
        /// <param name="pwr">User's password.</param>
        /// <returns>User instance if such user exists unless null.</returns>
        public static UserVM GetByLoginPassword(string login, string pwr)
        {
            try
            {
                var allUsers = MarketProxy.Proxy.GetData("User", Middleware.MethodType.GetByQuery, "PWord='" + pwr + "' AND Login='" + login + "'", Guid.Empty);
                var res = UserMapper.Mapper.UnPack(allUsers[0]);
                return new UserVM(res);
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
        { MarketProxy.Proxy.UpdateOne(UserMapper.Mapper.Pack(this._user), Middleware.UpdateType.Save); }

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