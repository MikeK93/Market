// --------------------------------------------------------------------------
// <copyright file="AddMerchandise.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Market.Data;
using Market.Data.Entities;
using Market.Data.Mappers;

namespace Market.UI.SalespersonForms
{
    /// <summary>
    /// Class represents a form for adding merchandise to salesperosn.
    /// </summary>
    public partial class AddMerchandise : Form
    {
        private Salesperson _salesperson = null; // Current salesperson

        private List<DM> _allDMs = DMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("DM", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));// DealerMerchandise

        private List<SDM> _selectedSDM = new List<SDM>();

        private List<SDM> _sdmsToDelete = new List<SDM>();

        private int _commaIndex;

        /// <summary>
        /// Constructor for initializing a new instance of AddMerchandise class.
        /// </summary>
        /// <param name="s">Instance of Salesperson class.</param>
        public AddMerchandise(Salesperson s)
        {
            InitializeComponent();

            if (s != null)
            {
                _salesperson = s;
                this.Text = "Управление товарами для " + s.FirstName + " " + s.LastName;
                MessageBox.Show(string.Format("Добро пожаловать, {0}!\nЗдесь Вы можете добавлять или удалять товары которые готовы продавать.", s.FirstName), "Добро пожаловать!", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error!");
                Close();
            }
        }

        private void AddMerchandise_Load(object sender, EventArgs e)
        {
            var dmss = _allDMs.GroupBy(dm => dm.Merchandise.ID).Select(g => g.First()).ToList();
            foreach (DM dm in dmss)
            {
                TreeNode root = new TreeNode();
                root.Text = dm.Merchandise.Name;
                root.Tag = dm;
                root.Nodes.Add(string.Empty);
                treeViewAllMerchandise.Nodes.Add(root);
                root.ImageIndex = 1;
            }

            AddItems(_salesperson.SDMs);
        }

        private void treeViewAllMerchandise_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var dealers = from dm in _allDMs.AsEnumerable()
                          where dm.Merchandise.ID == (e.Node.Tag as DM).Merchandise.ID
                          select dm;
            e.Node.Nodes.Clear();
            foreach (DM d in dealers)
            {
                TreeNode child = new TreeNode();
                child.Text = d.Dealer + " $" + d.Cost;
                child.Tag = d;
                child.ImageIndex = d.Dealer.Gender == GenderType.Male ? 2 : 3;
                e.Node.Nodes.Add(child);
            }
        }

        private void treeViewAllMerchandise_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var dm = e.Node.Tag as DM;
            if (e.Node.Nodes.Count > 0)
                SetData(string.Empty, 0, dm.Merchandise.Name, string.Empty, string.Empty);
            else
                SetData(dm.Dealer.ToString(), dm.Cost, dm.Merchandise.Name, dm.Dealer.PhoneNumber, dm.Dealer.Email);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewAllMerchandise.SelectedNode;
            if (selectedNode != null)
            {
                if (selectedNode.Nodes.Count > 0)
                    MessageBox.Show("Выберите поставщика для выбранного товара и за тем нажмите на кнопку \"+\" для добавления.", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    var dm = selectedNode.Tag as DM;
                    var _sdm = _sdmsToDelete.Find(sdm => (sdm.DealerMerchandise.Merchandise.ID == dm.Merchandise.ID && sdm.DealerMerchandise.Dealer.ID == dm.Dealer.ID));
                    if (_salesperson.SDMs.Find(sdm => sdm.DealerMerchandise.ID == dm.ID) == null)
                    {
                        if (_sdm != null)
                        {
                            _sdmsToDelete.Remove(_sdm);
                            AddItems(new List<SDM> { _sdm });
                        }
                        else
                        {
                            string txt = txtYourCost.Text;
                            float cost = float.Parse(txt.Substring(0, txt.IndexOf(',') == -1 ? txt.Length : txt.IndexOf(',') + 3));
                            SDM newSDM = new SDM(_salesperson.ID, dm.ID, cost);
                            AddItems(new List<SDM> { newSDM });
                        }
                    }
                    else
                    {
                        if (_sdm != null)
                        {
                            _sdmsToDelete.Remove(_sdm);
                            AddItems(new List<SDM> { _sdm });
                        }
                        else
                            MessageBox.Show("Вы уже выбрали такой товар.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbSelectedItems.SelectedItem != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить товар?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var sdmToRemove = lbSelectedItems.SelectedItem as SDM;
                    if (_salesperson.SDMs.Contains(sdmToRemove))
                        if (!_sdmsToDelete.Contains(sdmToRemove))
                            _sdmsToDelete.Add(sdmToRemove);
                    _selectedSDM.Remove(sdmToRemove);
                    lbSelectedItems.Items.Remove(sdmToRemove);
                }
            }
            else
                MessageBox.Show("Выберите товар из списка справа и за тем нажмите на кнопку \"-\" для удаления.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (_sdmsToDelete.Count > 0)
                    MarketProxy.Proxy.UpdateList(SDMMapper.Mapper.Pack(_sdmsToDelete), Middleware.UpdateType.Delete);
                _salesperson.SDMs = _selectedSDM;
                _salesperson.Save();
                MessageBox.Show("Изменения успешно сохранены.", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) { }

        private void lbSelectedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = lbSelectedItems.SelectedItem as SDM;
            if (selectedItem != null)
                lblInfo.Text = string.Format("{0} {1} {2} ${3} {4}", selectedItem.Dealer.FirstName, selectedItem.Dealer.MiddleName, selectedItem.Dealer.LastName, selectedItem.Cost, selectedItem.Merchendise.Name);
        }

        private void txtYourCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && !char.IsDigit((char)e.KeyValue) && e.KeyValue != 110)
                e.SuppressKeyPress = true;
            else
            {
                if (txtYourCost.Text.Length == 0 && e.KeyValue == 110)
                    e.SuppressKeyPress = true;
                else
                {
                    if (e.KeyValue != 110)
                        e.SuppressKeyPress = false;
                    else if (e.KeyValue == 110 && txtYourCost.Text.Contains(','))
                        e.SuppressKeyPress = true;
                    else
                    {
                        e.SuppressKeyPress = true;
                        var selectedIndex = txtYourCost.SelectionStart;
                        txtYourCost.Text = txtYourCost.Text.Insert(selectedIndex, ",");
                        txtYourCost.SelectionStart = selectedIndex + 1;
                        _commaIndex = selectedIndex;
                    }
                }
            }
        }

        #region Helping Methods
        private void SetData(string dealer, float dealerCost, string merchandiseName, string phoneNumber, string email)
        {
            txtDealer.Text = dealer;
            txtDealersCost.Text = dealerCost.ToString();
            txtMerchandiseName.Text = merchandiseName;
            txtYourCost.Text = (dealerCost == 0 ? 0 : dealerCost + 10).ToString();
            txtPN.Text = phoneNumber;
            txtEmail.Text = email;
        }

        private void AddItems(List<SDM> list)
        {
            foreach (var item in list)
            {
                lbSelectedItems.Items.Add(item);
                _selectedSDM.Add(item);
            }
        }
        #endregion
    }
}