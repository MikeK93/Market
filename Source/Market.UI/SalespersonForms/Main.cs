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

namespace Market.UI.SalespersonForms
{
    /// <summary>
    /// Class represents a main form for salesperons.
    /// </summary>
    public partial class Main : Form
    {
        private Salesperson _salesperson = null;

        private float _oldCost = float.MinValue;

        private int _commaIndexTxtMerchandiseCost;

        private int _commaIndexTxtMerchCost;

        /// <summary>
        /// Constructor for initializnig a new instance of Main class.
        /// </summary>
        /// <param name="s">Instance of Salesperson class.</param>
        public Main(Salesperson s, WaitWindow ww)
        {
            InitializeComponent();

            if (s != null)
            {
                _salesperson = s;
                this.Text = s.FirstName + " " + s.LastName;
                ww.Close();
            }
            else
            {
                MessageBox.Show("Error while loging in! You are not salesperson!");
                Close();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtFName.Text = _salesperson.FirstName;
            txtLName.Text = _salesperson.LastName;
            txtMName.Text = _salesperson.MiddleName;
            txtPN.Text = _salesperson.PhoneNumber;
            txtEmail.Text = _salesperson.Email;

            cbGender.Items.Add(GenderType.Female);
            cbGender.Items.Add(GenderType.Male);
            cbGender.SelectedItem = _salesperson.Gender;

            panelShowInfo.BringToFront();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверенны, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                ReadInfo();
                _salesperson.Save();
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        { panelShowInfo.BringToFront(); }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) { Close(); }

        private void dealersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_salesperson.Dealers.Count > 0)
            {
                List<Dealer> dealers = _salesperson.Dealers.GroupBy(d => d.ID).Select(g => g.First()).ToList();
                lvMyDealers.Items.Clear();
                foreach (Dealer d in dealers)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = d.ToString();
                    lvi.Tag = d;
                    Application.DoEvents();
                    lvi.ImageIndex = d.Gender == GenderType.Female ? 1 : 2;
                    lvMyDealers.Items.Add(lvi);
                }
            }

            panelDealers.BringToFront();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateClients();
            panelClients.BringToFront();
        }

        private void merchandiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_salesperson.SellingMerchandise.Count > 0)
            {
                lvMerchandise.Items.Clear();
                List<Merchandise> allMerchandise = _salesperson.SellingMerchandise.GroupBy(m => m.ID).Select(g => g.First()).ToList();
                foreach (Merchandise m in allMerchandise)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = m.Name;
                    lvi.Tag = m;
                    Application.DoEvents();
                    lvi.ImageIndex = 0;
                    lvMerchandise.Items.Add(lvi);
                }
            }

            panelMerchandise.BringToFront();
        }

        private void banksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanksUpdate();
            panelBanks.BringToFront();
        }

        private void spotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpotsUpdate();
            panelSpots.BringToFront();
        }

        private void btnAddDealer_Click(object sender, EventArgs e)
        {
            Hide();
            new AddMerchandise(_salesperson).ShowDialog();
            dealersToolStripMenuItem_Click(sender, e);
            Show();
        }

        private void btnSpotManage_Click(object sender, EventArgs e)
        {
            Hide();
            btnSpotMerchandise.Enabled = false;
            new SpotManager(_salesperson).ShowDialog();
            SpotsUpdate();
            Show();
        }

        private void btnAddBank_Click(object sender, EventArgs e)
        {
            Hide();
            new AddBank(_salesperson).ShowDialog();
            BanksUpdate();
            Show();
        }

        private void btnSaveCost_Click(object sender, EventArgs e)
        {
            var newCost = float.Parse(txtMerchCost.Text.Substring(0, txtMerchCost.Text.IndexOf(',') == -1 ? txtMerchCost.Text.Length : txtMerchCost.Text.IndexOf(',') + 3));
            var selectedMerch = lbMyDealersMerchandise.SelectedItem as MerchandiseToDealer;
            SaveCost(selectedMerch, newCost, _oldCost);
        }

        private void btnSaveCost2_Click(object sender, EventArgs e)
        {
            var newCost = float.Parse(txtMerchandiseCost.Text.Substring(0, txtMerchandiseCost.Text.IndexOf(',') == -1 ? txtMerchandiseCost.Text.Length : txtMerchandiseCost.Text.IndexOf(',') + 3));
            var selectedMerch = lbDealers.SelectedItem as MerchandiseToDealer;
            SaveCost(selectedMerch, newCost, _oldCost);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверенны, что хотите сохранить?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                try
                {
                    ReadInfo();
                    _salesperson.Save();
                    MessageBox.Show("Сохранено.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении." + Environment.NewLine + "Сообщение ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemoveDealer_Click(object sender, EventArgs e)
        {
            var merch = lbMyDealersMerchandise.SelectedItem as MerchandiseToDealer;
            if (MessageBox.Show(string.Format("Вы уверенны, что хотите удалить \"{0}\" с Вашего прайслиста?", merch.Merchandise.Name), "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                DialogResult.Yes)
            {
                var sdmToDelete = _salesperson.SDMs.Find(sdm => sdm.Merchendise.ID == merch.Merchandise.ID && sdm.Dealer.ID == merch.Dealer.ID);
                MarketProxy.Proxy.UpdateOne(SDMMapper.Mapper.Pack(sdmToDelete), Middleware.UpdateType.Delete);
            }
        }

        private void btnSpotMerchandise_Click(object sender, EventArgs e)
        {
            var s = lvSpots.SelectedItems[0].Tag as Spot;
            new ManageMerchandiseInSpot(_salesperson, s).ShowDialog();
            btnSpotMerchandise.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        { UpdateClients(); }

        private void btnAcceptOrder_Click(object sender, EventArgs e)
        {
            if (tvClients.SelectedNode.Nodes.Count == 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Вы уверенны, что хотите принять этот заказ?", "Заказ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try
                    {
                        var csi = tvClients.SelectedNode.Tag as CustomerSelectedItems;
                        csi.Delete();
                        tvClients.Nodes.Remove(tvClients.SelectedNode);
                        MessageBox.Show("Заказ был принят.", "Заказ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!" + Environment.NewLine + "Сообщение ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Select order and then click 'Accept' button.", "Accept", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void lbMyDealersMerchandise_SelectedIndexChanged(object sender, EventArgs e)
        {
            var m = lbMyDealersMerchandise.SelectedItem as MerchandiseToDealer;
            if (m != null)
            {
                lbDealers.SelectedItems.Clear();
                var costBySalesperson = (from mm in _salesperson.SDMs.AsEnumerable()
                                         where mm.Merchendise.ID == m.Merchandise.ID &&
                                                    mm.Dealer.ID == m.Dealer.ID
                                         select mm.Cost).ToList().FirstOrDefault();
                Application.DoEvents();
                txtMerchCost.Text = costBySalesperson.ToString();
                _oldCost = costBySalesperson;
                btnSaveCost.Enabled = true;
                btnSaveCost2.Enabled = false;
            }
        }

        private void lbDealers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var d = lbDealers.SelectedItem as MerchandiseToDealer;
            if (d != null)
            {
                lbMyDealersMerchandise.SelectedItems.Clear();
                var costBySalesperson = (from m in _salesperson.SDMs.AsEnumerable()
                                         where m.Merchendise.ID == d.Merchandise.ID &&
                                                    m.Dealer.ID == d.Dealer.ID
                                         select m.Cost).ToList().FirstOrDefault();
                Application.DoEvents();
                txtMerchandiseCost.Text = costBySalesperson.ToString();
                _oldCost = costBySalesperson;
                btnSaveCost2.Enabled = true;
                btnSaveCost.Enabled = false;
            }
        }

        private void lbSelectedSpots_DoubleClick(object sender, EventArgs e)
        {
            if (lbSelectedSpots.SelectedItem != null)
            {
                if (lbSelectedSpots.SelectedItem.ToString() == "Управление")
                {
                    Application.DoEvents();
                    var m = lvMerchandise.SelectedItems[0].Tag as Merchandise;
                    var d = (lbDealers.SelectedItem as MerchandiseToDealer).Dealer;
                    var sdm = _salesperson.SDMs.Find(_sdm => _sdm.Merchendise.ID == m.ID && _sdm.Dealer.ID == d.ID);
                    new AddSpotToMerchandise(sdm, _salesperson).ShowDialog();
                }
            }
        }

        private void lvMyDealers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                var selectedDealer = e.Item.Tag as Dealer;
                var res = from sdm in _salesperson.SDMs.AsEnumerable()
                          where (sdm.DealerMerchandise.Dealer.ID == selectedDealer.ID)
                          select new MerchandiseToDealer { Cost = sdm.DealerMerchandise.Cost, Merchandise = sdm.Merchendise, Dealer = sdm.Dealer };

                Application.DoEvents();
                lbMyDealersMerchandise.DataSource = res.ToList();
                txtDEmail.Text = selectedDealer.Email;
                txtDPN.Text = selectedDealer.PhoneNumber;
                btnSaveCost.Enabled = true;
            }
            else
            {
                lbMyDealersMerchandise.DataSource = null;
                txtDPN.Text = txtDEmail.Text = txtMerchCost.Text = string.Empty;
                btnSaveCost.Enabled = false;
            }
        }

        private void lvMerchandise_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var selectedMerchandise = e.Item.Tag as Merchandise;
            var dealers = from sdm in _salesperson.SDMs.AsEnumerable()
                          where (sdm.DealerMerchandise.Merchandise.ID == selectedMerchandise.ID)
                          select new MerchandiseToDealer { Cost = sdm.DealerMerchandise.Cost, Merchandise = sdm.Merchendise, Dealer = sdm.Dealer, ForDealer = false };
            txtName.Text = selectedMerchandise.Name;
            Application.DoEvents();
            lbDealers.DataSource = dealers.ToList();
            var selectedSDM = _salesperson.SDMs.Find(sdm => sdm.Merchendise.ID == selectedMerchandise.ID);
            UpdateSelectedSpots(selectedSDM.Spots, true);
        }

        private void lvMerchandise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMerchandise.SelectedItems.Count == 0)
                UpdateSelectedSpots(null, true, true);
        }

        private void lvMerchandise_TabIndexChanged(object sender, EventArgs e) { }

        private void lvBanks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var b = e.Item.Tag as Bank;
            if (b != null)
                txtBankAddress.Text = b.Address;
        }

        private void lvBanks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBanks.SelectedItems.Count > 0)
            {
                var b = lvBanks.SelectedItems[0].Tag as Bank;
                txtBankAddress.Text = b.Address;
            }
        }

        private void lvSpots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSpots.SelectedItems.Count > 0)
            {
                var s = lvSpots.SelectedItems[0].Tag as Spot;
                SetSpotData(s);
            }
            else
                SetSpotData(null);
        }

        private void tvClients_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var csis = (from _csi in _salesperson.Clients.AsEnumerable()
                        where _csi.Customer.ID == (e.Node.Tag as Customer).ID
                        select _csi).ToList();
            e.Node.Nodes.Clear();
            foreach (var csi in csis)
            {
                TreeNode n = new TreeNode();
                n.Text = csi.SDM.Merchendise.Name;
                n.Tag = csi;
                n.ImageIndex = 0;
                e.Node.Nodes.Add(n);
            }
        }

        private void tvClients_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var csi = e.Node.Tag as CustomerSelectedItems;
            if (csi != null)
                SetClientInfo(csi);
            else
                SetClientInfo(null);
        }

        private void txtMerchCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && !char.IsDigit((char)e.KeyValue) && e.KeyValue != 110)
                e.SuppressKeyPress = true;
            else
            {
                if (txtMerchCost.Text.Length == 0 && e.KeyValue == 110)
                    e.SuppressKeyPress = true;
                else
                {
                    if (e.KeyValue != 110)
                        e.SuppressKeyPress = false;
                    else if (e.KeyValue == 110 && txtMerchCost.Text.Contains(','))
                        e.SuppressKeyPress = true;
                    else
                    {
                        e.SuppressKeyPress = true;
                        var selectedIndex = txtMerchCost.SelectionStart;
                        txtMerchCost.Text = txtMerchCost.Text.Insert(selectedIndex, ",");
                        txtMerchCost.SelectionStart = selectedIndex + 1;
                        _commaIndexTxtMerchCost = selectedIndex;
                    }
                }
            }
        }

        private void txtMerchandiseCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && !char.IsDigit((char)e.KeyValue) && e.KeyValue != 110)
                e.SuppressKeyPress = true;
            else
            {
                if (txtMerchandiseCost.Text.Length == 0 && e.KeyValue == 110)
                    e.SuppressKeyPress = true;
                else
                {
                    if (e.KeyValue != 110)
                        e.SuppressKeyPress = false;
                    else if (e.KeyValue == 110 && txtMerchandiseCost.Text.Contains(','))
                        e.SuppressKeyPress = true;
                    else
                    {
                        e.SuppressKeyPress = true;
                        var selectedIndex = txtMerchandiseCost.SelectionStart;
                        txtMerchandiseCost.Text = txtMerchandiseCost.Text.Insert(selectedIndex, ",");
                        txtMerchandiseCost.SelectionStart = selectedIndex + 1;
                        _commaIndexTxtMerchandiseCost = selectedIndex;
                    }
                }
            }
        }

        #region Helping Methods

        private void UpdateSelectedSpots(List<Spot> spots, bool isCrear, bool isCleanUp = false)
        {
            if (!isCleanUp)
            {
                if (isCrear)
                    lbSelectedSpots.Items.Clear();
                foreach (Spot s in spots)
                {
                    Application.DoEvents();
                    lbSelectedSpots.Items.Add(s);
                }

                lbSelectedSpots.Items.Add("Управление");
            }
            else
            {
                lbSelectedSpots.Items.Clear();
                lbDealers.DataSource = new List<object>();
                btnSaveCost2.Enabled = false;
                txtName.Text = txtMerchandiseCost.Text = "-";
            }
        }

        private void UpdateClients()
        {
            if (_salesperson.Clients.Count != 0)
            {
                tvClients.Nodes.Clear();
                var clientNames = new List<Customer>();

                foreach (var c in _salesperson.Clients)
                    clientNames.Add(c.Customer);

                clientNames = clientNames.GroupBy(c => c.ID).Select(g => g.First()).ToList();

                Application.DoEvents();
                foreach (var c in clientNames)
                {
                    TreeNode n = new TreeNode();
                    n.Text = c.FirstName + " " + c.MiddaleName + " " + c.LastName;
                    n.Tag = c;
                    n.ImageIndex = c.Gender == GenderType.Female ? 1 : 2;
                    n.Nodes.Add(string.Empty);
                    tvClients.Nodes.Add(n);
                }
            }
        }

        private void SetSpotData(Spot s)
        {
            if (s != null)
            {
                txtSpotNumber.Text = s.Number.ToString();
                txtSpotSTName.Text = s.SecurityType.Name;
                txtSpotSTCost.Text = s.SecurityType.Cost.ToString();
                txtSpotSTGuards.Text = s.SecurityType.Guards.ToString();
                txtSpotMCAddress.Text = s.MakerCompany.City + ", " + s.MakerCompany.Country + (s.MakerCompany.Address.Length == 0 ? string.Empty : ", " + s.MakerCompany.Address);
                txtSpotMCName.Text = s.MakerCompany.Name;
                txtAddress.Text = s.Address;
                dtpSpotDateStart.Value = s.DateStart;
                btnSpotMerchandise.Enabled = true;
            }
            else
            {
                txtSpotNumber.Text = txtSpotSTName.Text = txtSpotSTCost.Text = txtSpotSTGuards.Text = txtSpotMCAddress.Text = txtSpotMCName.Text = "-";
                btnSpotMerchandise.Enabled = false;
            }
        }

        private void SetClientInfo(CustomerSelectedItems csi)
        {
            if (csi != null)
            {
                txtCAge.Text = csi.Customer.Age.ToString();
                txtCEmail.Text = csi.Customer.Email;
                txtCPN.Text = csi.Customer.PhoneNumber;
                txtCFN.Text = csi.Customer.FirstName;
                txtCMN.Text = csi.Customer.MiddaleName;
                txtCLN.Text = csi.Customer.LastName;
                txtCMName.Text = csi.SDM.Merchendise.Name;
            }
            else
                txtCAge.Text = txtCEmail.Text = txtCPN.Text = txtCFN.Text = txtCMN.Text = txtCLN.Text = txtCMName.Text = string.Empty;
        }

        private void BanksUpdate()
        {
            lvBanks.Items.Clear();
            foreach (Bank b in _salesperson.Banks)
            {
                Application.DoEvents();
                ListViewItem lvi = new ListViewItem();
                lvi.Text = b.Name;
                lvi.Tag = b;
                lvi.ImageIndex = 3;
                lvBanks.Items.Add(lvi);
            }
        }

        private void SpotsUpdate()
        {
            lvSpots.Items.Clear();
            if (_salesperson.Spots != null)
            {
                foreach (Spot s in _salesperson.Spots)
                {
                    Application.DoEvents();
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = s.Number.ToString();
                    lvi.Tag = s;
                    lvi.ImageIndex = 4;
                    lvSpots.Items.Add(lvi);
                }
            }
        }

        private void ReadInfo()
        {
            _salesperson.LastName = txtLName.Text;
            _salesperson.MiddleName = txtMName.Text;
            _salesperson.FirstName = txtFName.Text;
            _salesperson.Email = txtEmail.Text;
            _salesperson.PhoneNumber = txtPN.Text;
            _salesperson.Gender = (GenderType)cbGender.SelectedItem;
        }

        private void SaveCost(MerchandiseToDealer selectedMerch, float newCost, float oldCost)
        {
            if (selectedMerch != null)
            {
                if (DialogResult.Yes ==
                    MessageBox.Show(string.Format("Вы уверенны,что хотите изменить цену с '${0}' на '${1}' для '{2}'?", oldCost, newCost, selectedMerch.Merchandise.Name), "Сохранени новой цены", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    var sdm = (from _sdm in _salesperson.SDMs.AsEnumerable()
                               where (_sdm.Merchendise.ID == selectedMerch.Merchandise.ID &&
                                           _sdm.Dealer.ID == selectedMerch.Dealer.ID)
                               select _sdm).ToList().First();
                    _salesperson.SDMs.Remove(sdm);
                    sdm.Cost = newCost;
                    _salesperson.SDMs.Add(sdm);
                    _salesperson.Save();
                }
            }
        }
        #endregion
    }
}