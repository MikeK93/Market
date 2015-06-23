// --------------------------------------------------------------------------
// <copyright file="Register.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using Market.Data;
using Market.Data.Entities;
using Market.Data.Mappers;

namespace Market.UI
{
    /// <summary>
    /// Class represents a form for registration.
    /// </summary>
    public partial class Register : Form
    {
        private User _user = null;

        /// <summary>
        /// Constructor for initializating a new instance of Register class.
        /// </summary>
        public Register()
        {
            InitializeComponent();
            _user = new User();
        }

        /// <summary>
        /// Gets a login for created user.
        /// </summary>
        public string Login { get; private set; }

        /// <summary>
        /// Gets a password for created user.
        /// </summary>
        public string Password { get; private set; }

        private void rbDealer_CheckedChanged(object sender, EventArgs e)
        {
            OnSelection();
            _user.Role = Role.Dealer;
        }

        private void rcCustomer_CheckedChanged(object sender, EventArgs e)
        {
            OnSelection();
            _user.Role = Role.Customer;
        }

        private void rbSalesperson_CheckedChanged(object sender, EventArgs e)
        {
            OnSelection();
            _user.Role = Role.Salesperson;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверенны, что хотите зарегистрироваться?", "Регистрация", MessageBoxButtons.YesNo))
            {
                Login = _user.Login = txtLogin.Text;
                Password = _user.Password = mtxtPwr.Text;
                var userFound = UserMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("User", Middleware.MethodType.GetByQuery, "Login='" + this.Login + "' AND PWord='" + this.Password + "'", Guid.Empty));
                if (userFound.Count == 0)
                {
                    _user.Save();
                    User newUser = User.GetByLoginPassword(_user.Login, _user.Password);
                    switch (newUser.Role)
                    {
                        case Role.Customer:
                            {
                                var c = new Customer(newUser.ID);
                                c.FirstName = txtFName.Text;
                                c.MiddaleName = txtMName.Text;
                                c.LastName = txtLName.Text;
                                c.Gender = (GenderType)cbGender.SelectedItem;
                                c.Save();
                                break;
                            }

                        case Role.Salesperson:
                            {
                                var s = new Salesperson(newUser.ID);
                                s.FirstName = txtFName.Text;
                                s.MiddleName = txtMName.Text;
                                s.LastName = txtLName.Text;
                                s.Gender = (GenderType)cbGender.SelectedItem;
                                s.Save();
                                break;
                            }

                        case Role.Dealer:
                            {
                                var d = new Dealer(newUser.ID);
                                d.FirstName = txtFName.Text;
                                d.MiddleName = txtMName.Text;
                                d.LastName = txtLName.Text;
                                d.Gender = (GenderType)cbGender.SelectedItem;
                                d.Save();
                                break;
                            }
                    }

                    Hide();
                }
                else
                    MessageBox.Show("Пользователь с таким логином и паролем уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSelection()
        {
            txtFName.Enabled = true;
            txtMName.Enabled = true;
            txtLName.Enabled = true;
            txtLogin.Enabled = true;
            mtxtPwr.Enabled = true;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            cbGender.Items.Add(GenderType.Female);
            cbGender.Items.Add(GenderType.Male);
            cbGender.SelectedItem = GenderType.Male;
        }
    }
}