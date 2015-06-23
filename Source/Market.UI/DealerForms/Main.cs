// --------------------------------------------------------------------------
// <copyright file="Main.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Market.Data;
using Market.ClientUI;
using Market.Data.Entities;
using Market.Data.Mappers;
using Market.Data.Projections;

namespace Market.UI.DealerForms
{
    /// <summary>
    /// Class represents a main form for Dealer.
    /// </summary>
    public partial class Main : Form
    {
        private Dealer _dealer = null;

        private float _oldCost = float.NaN;

        private int _commaIndex;

        private List<SDM> _allSDMs = SDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SDM", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));

        /// <summary>
        /// Constructor for initializnig a new instance of Main class.
        /// </summary>
        /// <param name="d">Instance of Dealer class.</param>
        public Main(Dealer d, WaitWindow ww)
        {
            InitializeComponent();

            if (d != null)
            {
                _dealer = d;
                InitForm(_dealer);
                ww.Close();
            }
            else
            {
                MessageBox.Show("Error while login in! You are not a dealer!");
                Close();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        { panelInfo.BringToFront(); }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        { Close(); }

        private void myBanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanksUpdate();
            panelBanks.BringToFront();
        }

        private void myMerchandiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMerchandise();
            panelMyMerchandise.BringToFront();
        }

        private void myClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvMyClients.Items.Clear();
            var salespersons = new List<Salesperson>();

            foreach (SDM sdm in _allSDMs)
            {
                if (sdm.Dealer.ID == _dealer.ID && salespersons.Find(s => s.ID == sdm.Salesperson.ID) == null)
                {
                    salespersons.Add(sdm.Salesperson);
                    ListViewItem i = new ListViewItem();
                    i.Text = sdm.Salesperson.ToString();
                    i.Tag = sdm.Salesperson;
                    i.ImageIndex = 1;
                    lvMyClients.Items.Add(i);
                }
            }

            panelMyClients.BringToFront();
        }

        private void Main_Load(object sender, EventArgs e) { }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверенны, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                GetInfo();
                _dealer.Save();
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void lvAllMerchandise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAllMerchandise.SelectedItems.Count > 0)
            {
                var m = lvAllMerchandise.SelectedItems[0].Tag as DM;
                SetData(m);
                btnSaveCost.Enabled = true;
            }
            else
            {
                SetData(null);
                btnSaveCost.Enabled = false;
            }
        }

        private void lvMyClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMyClients.SelectedItems.Count > 0)
            {
                var s = lvMyClients.SelectedItems[0].Tag as Salesperson;
                SetSalespersonData(s);
            }
            else
                SetSalespersonData(null);
        }

        private void lvBanks_ItemChecked(object sender, ItemCheckedEventArgs e) { }

        private void lvBanks_ItemCheck(object sender, ItemCheckEventArgs e) { }

        private void lvBanks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBanks.SelectedItems.Count > 0)
            {
                var b = lvBanks.SelectedItems[0].Tag as Bank;
                if (b != null)
                    txtBankAddress.Text = b.Address;
            }
            else
                txtBankAddress.Text = string.Empty;
        }

        private void btnSaveCost_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(string.Format("Вы уверенны, что хотите изменить цену с '{0}' на '{1}'?", _oldCost, txtCostByDealer.Text), "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (lvAllMerchandise.SelectedItems.Count > 0)
                {
                    var selectedDM = lvAllMerchandise.SelectedItems[0].Tag as DM;
                    var dm = (from _dm in _dealer.DMs.AsEnumerable()
                              where (_dm.Merchandise.ID == selectedDM.Merchandise.ID &&
                                          _dm.Dealer.ID == selectedDM.Dealer.ID)
                              select _dm).ToList().First();
                    dm.Cost = float.Parse(txtCostByDealer.Text.Substring(0, txtCostByDealer.Text.IndexOf(',') == -1 ? txtCostByDealer.Text.Length : txtCostByDealer.Text.IndexOf(',') + 3));
                    dm.Save();
                    UpdateMerchandise();
                }
            }
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            Hide();
            new AddMerchandise(_dealer).ShowDialog();
            UpdateMerchandise();
            Show();
        }

        private void btnBanksManage_Click(object sender, EventArgs e)
        {
            Hide();
            new AddBank(_dealer).ShowDialog();
            BanksUpdate();
            Show();
        }

        private void txtCostByDealer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && !char.IsDigit((char)e.KeyValue) && e.KeyValue != 110)
                e.SuppressKeyPress = true;
            else
            {
                if (txtCostByDealer.Text.Length == 0 && e.KeyValue == 110)
                    e.SuppressKeyPress = true;
                else
                {
                    if (e.KeyValue != 110)
                        e.SuppressKeyPress = false;
                    else if (e.KeyValue == 110 && txtCostByDealer.Text.Contains(','))
                        e.SuppressKeyPress = true;
                    else
                    {
                        e.SuppressKeyPress = true;
                        var selectedIndex = txtCostByDealer.SelectionStart;
                        txtCostByDealer.Text = txtCostByDealer.Text.Insert(selectedIndex, ",");
                        txtCostByDealer.SelectionStart = selectedIndex + 1;
                        _commaIndex = selectedIndex;
                    }
                }
            }
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверенны, что хотите обновить персональную инвормацию?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                try
                {
                    GetInfo();
                    _dealer.Save();
                    MessageBox.Show("Сохранено.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка во время сохранения." + Environment.NewLine + "Сообщение ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Helping Methods

        private void InitForm(Dealer d)
        {
            txtFName.Text = d.FirstName;
            txtMName.Text = d.MiddleName;
            txtLName.Text = d.LastName;
            txtPhoneNumber.Text = d.PhoneNumber;
            txtEmail.Text = d.Email;
            cbGender.Items.Add(GenderType.Female);
            cbGender.Items.Add(GenderType.Male);
            cbGender.SelectedItem = d.Gender;
            panelInfo.BringToFront();
            this.Text = _dealer.FirstName + " " + _dealer.LastName;
        }

        private void BanksUpdate()
        {
            lvBanks.Items.Clear();
            foreach (Bank b in _dealer.Banks)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = b.Name;
                lvi.Tag = b;
                lvi.ImageIndex = 2;
                lvBanks.Items.Add(lvi);
            }
        }

        private void SetSalespersonData(Salesperson s)
        {
            lbSalespersonMerchandise.Items.Clear();
            if (s != null)
            {
                txtSalespersonFN.Text = s.FirstName;
                txtSalespersonLN.Text = s.LastName;
                txtSalespersonMN.Text = s.MiddleName;
                txtCEmail.Text = s.Email;
                txtCPN.Text = s.PhoneNumber;
                foreach (SDM sdm in s.SDMs)
                    if (sdm.Dealer.ID == _dealer.ID)
                        lbSalespersonMerchandise.Items.Add(new SDMProjection(sdm.Salesperson.ID, sdm.DealerMerchandise.ID));
            }
            else
            {
                txtSalespersonFN.Text = txtSalespersonMN.Text = txtSalespersonLN.Text = txtCPN.Text = txtCEmail.Text = "-";
                lbSalespersonMerchandise.Items.Clear();
            }
        }

        private void UpdateMerchandise()
        {
            // Update merchandise corner
            if (_dealer.AllMerchandise.Count > 0)
            {
                lvAllMerchandise.Items.Clear();
                foreach (DM dm in _dealer.DMs)
                {
                    ListViewItem i = new ListViewItem();
                    i.Text = dm.Merchandise.Name;
                    i.Tag = dm;
                    i.ImageIndex = 0;
                    lvAllMerchandise.Items.Add(i);
                }
            }

            // Update salesperson corner
            lvMyClients.Items.Clear();
            lbSalespersonMerchandise.Items.Clear();
            var salespersons = new List<Salesperson>();

            foreach (SDM sdm in _allSDMs)
            {
                if (sdm.Dealer.ID == _dealer.ID && salespersons.Find(s => s.ID == sdm.Salesperson.ID) == null)
                {
                    salespersons.Add(sdm.Salesperson);
                    ListViewItem i = new ListViewItem();
                    i.Text = sdm.Salesperson.ToString();
                    i.Tag = sdm.Salesperson;
                    i.ImageIndex = 1;
                    lvMyClients.Items.Add(i);
                }
            }
        }

        private void SetData(DM dm)
        {
            if (dm != null)
            {
                txtMerchandiseName.Text = dm.Merchandise.Name;
                txtCostByDealer.Text = dm.Cost.ToString();
                txtCost.Text = dm.Merchandise.Cost.ToString();
                _oldCost = float.Parse(txtCostByDealer.Text);
                string categories = string.Empty;
                foreach (Category c in dm.Merchandise.Categories)
                    categories += " #" + c.Name;
                lbCategories.Text = "Категории:" + categories;
                txtStorage.Text = dm.Merchandise.Storage.ToString();
            }
            else
                txtMerchandiseName.Text = txtCostByDealer.Text = txtStorage.Text = txtCost.Text = lbCategories.Text = "-";
        }

        private void GetInfo()
        {
            _dealer.FirstName = txtFName.Text;
            _dealer.MiddleName = txtMName.Text;
            _dealer.LastName = txtLName.Text;
            _dealer.PhoneNumber = txtPhoneNumber.Text;
            _dealer.Email = txtEmail.Text;
            _dealer.Gender = (GenderType)cbGender.SelectedItem;
        }
        #endregion
    }
}