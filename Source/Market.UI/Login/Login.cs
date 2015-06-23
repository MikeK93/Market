// --------------------------------------------------------------------------
// <copyright file="Login.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using Market.Data;
using Market.ClientUI;
using Market.Data.Entities;
using Market.Data.Mappers;

namespace Market.UI
{
    /// <summary>
    /// Class represents a for for loging in.
    /// </summary>
    public partial class Login : Form
    {
        private WaitWindow _winWait = new WaitWindow();

        /// <summary>
        /// Constructor for initializing a new instance of Login class.
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            var login = txtLogin.Text;
            var pwr = txtPwr.Text;
            User user = User.GetByLoginPassword(login, pwr);
            lblErrorMsg.Visible = false;
            if (user != null)
            {
                Salesperson salesperson = null;
                Dealer dealer = null;
                Customer customer = null;
                switch (user.Role)
                {
                    case Role.Customer:
                        {
                            _winWait = new WaitWindow();
                            _winWait.Show();
                            customer = Customer.GetCustomerByUser(user);
                            Hide();
                            new CustomerForms.Main(customer, _winWait).ShowDialog();
                            Show();
                            break;
                        }

                    case Role.Salesperson:
                        {
                            _winWait = new WaitWindow();
                            _winWait.Show();
                            salesperson = Salesperson.GetSalespersonByUser(user);
                            Hide();
                            new SalespersonForms.Main(salesperson, _winWait).ShowDialog();
                            Show();
                            break;
                        }

                    case Role.Dealer:
                        {
                            _winWait = new WaitWindow();
                            _winWait.Show();
                            dealer = Dealer.GetDealerByUser(user);
                            Hide();
                            new DealerForms.Main(dealer, _winWait).ShowDialog();
                            Show();
                            break;
                        }
                }
            }
            else
                lblErrorMsg.Visible = true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var reg = new Register();
            if (DialogResult.OK == reg.ShowDialog())
            {
                txtLogin.Text = reg.Login;
                txtPwr.Text = reg.Password;
                reg.Close();
            }
        }

        private void linkLblForgotPwr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }
    }
}