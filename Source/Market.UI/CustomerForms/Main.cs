// --------------------------------------------------------------------------
// <copyright file="Main.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Market.Data;
using Market.ClientUI;
using Market.Data.Entities;
using Market.Data.Mappers;

namespace Market.UI.CustomerForms
{
    /// <summary>
    /// Class represents a main form for customer.
    /// </summary>
    public partial class Main : Form
    {
        private Customer _customer = null;

        private List<Spot> _allSpots = SpotMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Spot", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));

        private List<CustomerSelectedItems> _csisToDel = new List<CustomerSelectedItems>();

        private List<SpotSDM> _allSpotSDMs = SpotSDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SpotSDM", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));

        /// <summary>
        /// List of Merchandise after filters were submited.
        /// </summary>
        private List<SpotSDM> _filteredData = new List<SpotSDM>();

        /// <summary>
        /// Constructor for initializing a new instance of Main class.
        /// </summary>
        /// <param name="c">Instance of Customer class.</param>
        public Main(Customer c, WaitWindow ww)
        {
            InitializeComponent();

            if (c != null)
            {
                Text = c.FirstName + " " + c.LastName;
                _customer = c;
                SetInformation(c);
                InitForm();
                ww.Close();
            }
            else
            {
                MessageBox.Show("Error! Only customers have rights to be here!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void Main_Load(object sender, EventArgs e) { }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                GetData();
                _customer.Save();
                SaveOrders();
            }
            else
                e.Cancel = true;
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e) { this.Text = _customer.FirstName + " " + _customer.LastName + ": " + e.TabPage.Text; }

        private void btnManage_Click(object sender, EventArgs e)
        { tabControl.SelectTab("tabPageMyDeals"); }

        private void btnAddReference_Click(object sender, EventArgs e)
        { tabControl.SelectTab("tabPageMarket"); }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvSpotMerchandise.SelectedItems.Count > 0)
            {
                var sdm = lvSpotMerchandise.SelectedItems[0].Tag as SDM;
                Add(sdm);
            }
            else
                MessageBox.Show("Select item and click 'Add' button.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnAddRef_Click(object sender, EventArgs e)
        {
            if (tvMerchandise.SelectedNode.Nodes.Count == 0)
            {
                var sdm = (tvMerchandise.SelectedNode.Tag as SpotSDM).SDM;
                Add(sdm);
            }
            else
                MessageBox.Show("Выберите товар и затем нажмите на кнопку \"Добавить\".", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvMyMerchandise.SelectedItems.Count > 0)
            {
                var csi = lvMyMerchandise.SelectedItems[0].Tag as CustomerSelectedItems;

                if (DialogResult.Yes == MessageBox.Show("Вы уверенны, что хотите удалить \"" + csi.SDM.Merchendise + "\" за $" + csi.SDM.Cost + "?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (_customer.CSIs.Contains(csi))
                    {
                        var csiToRemove = _customer.CSIs.Find(_csi => _csi.ID == csi.ID);
                        csiToRemove.IsSubmited = false;
                        if (!_csisToDel.Contains(csiToRemove))
                            _csisToDel.Add(csiToRemove);

                        _customer.CSIs.Remove(csiToRemove);
                    }

                    lvMyMerchandise.Items.Remove(lvMyMerchandise.SelectedItems[0]);
                    MessageBox.Show("Удалено!", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Выберите сначало заказ, а потом нажмите кнопку 'Удалить'.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveSelection_Click(object sender, EventArgs e)
        {
            if (_customer.PhoneNumber.Length == 0 || txtPN.Text.Length == 0)
                MessageBox.Show("У Вас должен быть указан номер телефона или email. Введите рабочий номер телефона и нажмите кнопку \"Сохранить\".", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (DialogResult.Yes ==
                    MessageBox.Show("Вы уверенны, что хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try
                    {
                        SaveOrders();
                        MessageBox.Show("Сохранено!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении." + Environment.NewLine + "Сообщение ошибки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text == txtConfirmPwd.Text)
            {
                GetData();
                _customer.Save();
                MessageBox.Show("Сохранено!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Удостовертесь в правильности ввода пароля и логина!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSubmitFilters_Click(object sender, EventArgs e)
        {
            var tag = cbFilterTags.SelectedItem as Category;
            _filteredData = RetrieveData(tag, cbFilterPrice.SelectedIndex);
            SetData(null);
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e)
        {
            if (_customer.PhoneNumber.Length == 0 || txtPN.Text.Length == 0)
                MessageBox.Show("У Вас должен быть указан номер телефона или email. Введите рабочий номер телефона и нажмите кнопку \"Сохранить\".", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (lvMyMerchandise.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem i in lvMyMerchandise.SelectedItems)
                    {
                        Application.DoEvents();
                        var csi = i.Tag as CustomerSelectedItems;
                        i.ImageIndex = 9;
                        _customer.CSIs.Find(_csi => _csi.ID == csi.ID).IsSubmited = true;
                    }

                    MessageBox.Show("Заказ подтверждет!");
                }
                else
                    MessageBox.Show("Для того, что бы подтвердить заказ, нужно выбрать хотя бы один. Выберите и нажмите кнопку \"Подтвердить заказ\" еще раз.", "Подтверждение заказа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lvAllSpots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAllSpots.SelectedItems.Count > 0)
            {
                var s = lvAllSpots.SelectedItems[0].Tag as Spot;
                SetSpotInfo(s);
            }
            else
                SetSpotInfo(null);
        }

        private void lvSpotMerchandise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSpotMerchandise.SelectedItems.Count > 0)
            {
                var m = lvSpotMerchandise.SelectedItems[0].Tag as SDM;
                SetMerchandiseInfo(m);
            }
            else
                SetMerchandiseInfo(null);
        }

        private void lvMyMerchandise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMyMerchandise.SelectedItems.Count > 0)
            {
                var csi = lvMyMerchandise.SelectedItems[0].Tag as CustomerSelectedItems;
                SetSelectedMerchandiseInfo(csi, lvMyMerchandise.SelectedItems[0]);
                btnSubmitOrder.Text = "Подтвердить " + lvMyMerchandise.SelectedItems.Count + " заказ(-а,-ов)";
            }
            else
                SetSelectedMerchandiseInfo(null, null);
        }

        private void cbViewMarket_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbViewMarket.SelectedIndex == 0)
                panelSpots.BringToFront();
            if (cbViewMarket.SelectedIndex == 1)
                panelAllMerchandise.BringToFront();
        }

        private void cbSortMyMerchandise_SelectedIndexChanged(object sender, EventArgs e)
        {
            var res = new List<CustomerSelectedItems>();
            switch (cbSortMyMerchandise.SelectedIndex)
            {
                case 0:
                    res = _customer.CSIs.OrderByDescending(_sci => _sci.SDM.Cost).ToList();
                    break;
                case 1:
                    res = _customer.CSIs.OrderBy(_sci => _sci.SDM.Cost).ToList();
                    break;
                case 2:
                    res = _customer.CSIs.OrderBy(_csi => _csi.SDM.Merchendise.Name).ToList();
                    break;
            }

            UpdateSelectedMerchandise(res.ToList(), true);
        }

        private void tvMerchandise_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var selectedSSDM = e.Node.Tag as SpotSDM;
            var salespersons = _filteredData.FindAll(_ssdm => _ssdm.SDM.Merchendise.ID == selectedSSDM.SDM.Merchendise.ID).ToList();
            e.Node.Nodes.Clear();
            foreach (SpotSDM ssdm in salespersons)
            {
                Application.DoEvents();
                TreeNode child = new TreeNode();
                child.Text = ssdm.SDM.Salesperson + " $" + ssdm.SDM.Cost.ToString();
                child.Tag = ssdm;
                child.ImageIndex = (ssdm.SDM.Salesperson.Gender == GenderType.Male) ? 3 : 2;
                e.Node.Nodes.Add(child);
            }
        }

        private void tvMerchandise_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) { }

        private void tvMerchandise_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                var ssdm = e.Node.Tag as SpotSDM;
                if (ssdm != null)
                    SetData(ssdm);
            }
            else
                SetData(null);
        }

        #region Helping Methods

        private void InitForm()
        {
            this.Text = _customer.FirstName + " " + _customer.LastName + ": " + tabControl.SelectedTab.Text;
            lvAllSpots.Items.Clear();
            foreach (Spot s in _allSpots)
            {
                if (s.SDMs != null && s.SDMs.Count > 0)
                {
                    Application.DoEvents();
                    ListViewItem i = new ListViewItem();
                    i.Text = s.Number.ToString();
                    i.ImageIndex = 0;
                    i.Tag = s;
                    i.ToolTipText = "Click to see what merchanidse available in this spot.";
                    lvAllSpots.Items.Add(i);
                }
            }

            UpdateSelectedMerchandise(_customer.CSIs, true);
            cbViewMarket.SelectedIndex = 0;

            cbFilterTags.DataSource = CategoryMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Category", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));
            cbFilterPrice.SelectedIndex = 0;
            _filteredData = RetrieveData(cbFilterTags.SelectedItem as Category, cbFilterPrice.SelectedIndex);

            cbSortMyMerchandise.SelectedIndex = 0;
        }

        private void Add(SDM sdm)
        {
            var csiDel = _csisToDel.Find(_csi => _csi.SDMID == sdm.ID);

            if (_customer.CSIs.Find(_csi => _csi.SDMID == sdm.ID) == null)
            {
                if (csiDel != null)
                {
                    _csisToDel.Remove(csiDel);
                    _customer.CSIs.Add(csiDel);
                    UpdateSelectedMerchandise(new List<CustomerSelectedItems> { csiDel }, false);
                    MessageBox.Show("\"" + csiDel.SDM.Merchendise + "\" за $" + csiDel.SDM.Cost + " успешно добавлен в корзину!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CustomerSelectedItems newCSI = new CustomerSelectedItems(_customer.ID, sdm.ID);
                    _customer.CSIs.Add(newCSI);
                    UpdateSelectedMerchandise(new List<CustomerSelectedItems> { newCSI }, false);
                    MessageBox.Show("\"" + newCSI.SDM.Merchendise + "\" за $" + newCSI.SDM.Cost + " успешно добавлен в корзину!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (csiDel != null)
                {
                    _csisToDel.Remove(csiDel);
                    _customer.CSIs.Add(csiDel);
                    UpdateSelectedMerchandise(new List<CustomerSelectedItems> { csiDel }, false);
                    MessageBox.Show("\"" + csiDel.SDM.Merchendise + "\" за $" + csiDel.SDM.Cost + " успешно добавлен в корзину!", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Вы уже выбрали даный товар!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetData(SpotSDM ssdm)
        {
            if (ssdm != null)
            {
                txtMCost.Text = ssdm.SDM.Cost.ToString();
                txtMName.Text = ssdm.SDM.Merchendise.Name;
                txtMSNumber.Text = ssdm.Spot.Number.ToString();
                txtMTags.Text = ssdm.SDM.Merchendise.Tags;
                txtMSFN.Text = ssdm.SDM.Salesperson.FirstName;
                txtMSMN.Text = ssdm.SDM.Salesperson.MiddleName;
                txtMSLN.Text = ssdm.SDM.Salesperson.LastName;
                txtMSE.Text = ssdm.SDM.Salesperson.Email;
                txtMSPN.Text = ssdm.SDM.Salesperson.PhoneNumber;
            }
            else
                txtMSE.Text = txtMSPN.Text = txtMCost.Text = txtMName.Text = txtMSNumber.Text = txtMTags.Text = txtMSFN.Text = txtMSMN.Text = txtMSLN.Text = txtMSE.Text = txtMSPN.Text = "-";
        }

        private List<SpotSDM> RetrieveData(Category tag, int orderIndex)
        {
            var res = new List<SpotSDM>();
            tvMerchandise.Nodes.Clear();

            foreach (SpotSDM ssdm in _allSpotSDMs)
                if (ssdm.SDM.Merchendise.Tags.ToLower().Contains(tag.Name.ToLower()))
                {
                    Application.DoEvents();
                    res.Add(ssdm);
                }

            res = (orderIndex == 0) ?
                res.OrderBy(_ssdm => _ssdm.SDM.Cost).ToList() : res.OrderByDescending(_ssdm => _ssdm.SDM.Cost).ToList();

            foreach (SpotSDM ssdm in res)
            {
                if (tvMerchandise.Nodes.Find(ssdm.SDM.Merchendise.Name, false).Count() == 0)
                {
                    Application.DoEvents();
                    TreeNode root = new TreeNode();
                    root.Name = root.Text = ssdm.SDM.Merchendise.Name;
                    root.Tag = ssdm;
                    root.ImageIndex = 1;
                    root.Nodes.Add(string.Empty);
                    tvMerchandise.Nodes.Add(root);
                }
            }

            return res;
        }

        private void UpdateSelectedMerchandise(List<CustomerSelectedItems> list, bool isClear)
        {
            if (isClear)
                lvMyMerchandise.Items.Clear();
            foreach (CustomerSelectedItems csi in list)
            {
                Application.DoEvents();
                ListViewItem i = new ListViewItem();
                i.ToolTipText = "$" + csi.SDM.Cost;
                i.Text = csi.SDM.Merchendise.Name;
                i.ImageIndex = csi.IsSubmited ? 9 : 8;
                i.Tag = csi;
                i.Checked = csi.IsSubmited;
                lvMyMerchandise.Items.Add(i);
            }
        }

        private void SetMerchandiseInfo(SDM sdm)
        {
            if (sdm != null)
            {
                Application.DoEvents();
                txtSpotMerchanidseCost.Text = sdm.Cost.ToString();
                string tags = string.Empty;
                foreach (var c in sdm.Merchendise.Categories)
                    tags += " #" + c;
                txtSpotMerchanidseTags.Text = tags;
            }
            else txtSpotMerchanidseCost.Text = txtSpotMerchanidseTags.Text = "-";
        }

        private void SetSelectedMerchandiseInfo(CustomerSelectedItems csi, ListViewItem lvi)
        {
            if (csi != null)
            {
                Application.DoEvents();
                btnSubmitOrder.Enabled = true;

                txtSelectedMCost.Text = csi.SDM.Cost.ToString();
                txtSelectedMName.Text = csi.SDM.Merchendise.Name;
                txtSelectedMTags.Text = csi.SDM.Merchendise.Tags;
                txtSFN.Text = csi.SDM.Salesperson.FirstName;
                txtSMN.Text = csi.SDM.Salesperson.MiddleName;
                txtSLN.Text = csi.SDM.Salesperson.LastName;
                txtSPN.Text = csi.SDM.Salesperson.PhoneNumber;

                if (csi.IsSubmited)
                {
                    lblIsSubmitMsg.ForeColor = Color.Blue;
                    lblIsSubmitMsg.Text = "* Этот заказ подтвержден. Нажмите кнопку \"Сохранить\" если не сохранили и ждите пока с Вами свяжеться продавец.";
                }
                else
                {
                    lblIsSubmitMsg.ForeColor = Color.Red;
                    lblIsSubmitMsg.Text = "* Этот заказ НЕ подтвержден. Это означает, что продавец не видет этого заказа и не может связаться с Вами. Подтвердите заказ нажав на кнопку \"Подтвердить\".";
                }
            }
            else
            {
                lblIsSubmitMsg.Text = txtSelectedMCost.Text = txtSelectedMName.Text = txtSPN.Text = txtSelectedMTags.Text = txtSFN.Text = txtSMN.Text = txtSLN.Text = string.Empty;
                btnSubmitOrder.Text = "Подтвердить";
                btnSubmitOrder.Enabled = false;
            }
        }

        private void SetSpotInfo(Spot s)
        {
            if (s != null)
            {
                txtSpotNumber.Text = s.Number.ToString();
                txtAddress.Text = s.Address;
                txtSpotSalesperson.Text = s.Salesperson == null ? "Out of service." : s.Salesperson.ToString();
                dtpStart.Visible = true;
                dtpStart.Value = s.DateStart;
                lvSpotMerchandise.Items.Clear();
                foreach (SDM sdm in s.SDMs)
                {
                    ListViewItem i = new ListViewItem();
                    i.Text = sdm.Merchendise.Name;
                    i.Tag = sdm;
                    Application.DoEvents();
                    i.ToolTipText = "$" + sdm.Cost.ToString();
                    i.ImageIndex = 1;
                    lvSpotMerchandise.Items.Add(i);
                }
            }
            else
            {
                txtSpotNumber.Text = txtAddress.Text = txtSpotSalesperson.Text = txtSpotMerchanidseTags.Text = txtSpotMerchanidseCost.Text = "-";
                dtpStart.Visible = false;
                lvSpotMerchandise.Items.Clear();
            }
        }

        private void SetInformation(Customer c)
        {
            txtAge.Text = c.Age.ToString();
            txtFN.Text = c.FirstName;
            txtMN.Text = c.MiddaleName;
            txtLN.Text = c.LastName;
            txtLogin.Text = c.User.Login;
            txtPwd.Text = txtConfirmPwd.Text = c.User.Password;
            txtEmail.Text = c.Email;
            txtPN.Text = c.PhoneNumber;
            cbGender.Items.Add(GenderType.Female);
            cbGender.Items.Add(GenderType.Male);
            cbGender.SelectedItem = c.Gender;
        }

        private void GetData()
        {
            _customer.Age = int.Parse(txtAge.Text);
            _customer.FirstName = txtFN.Text;
            _customer.MiddaleName = txtMN.Text;
            _customer.LastName = txtLN.Text;
            _customer.User.Login = txtLogin.Text;
            _customer.User.Password = txtPwd.Text;
            _customer.Email = txtEmail.Text;
            _customer.PhoneNumber = txtPN.Text;
            _customer.Gender = (GenderType)cbGender.SelectedItem;
        }

        private void SaveOrders()
        {
            if (_csisToDel.Count != 0)
            {
                MarketProxy.Proxy.UpdateList(CustomerSelectedItemsMapper.Mapper.Pack(_csisToDel), Middleware.UpdateType.Delete);
                _csisToDel.Clear();
            }

            //_customer.Save();
        }
        #endregion
    }
}