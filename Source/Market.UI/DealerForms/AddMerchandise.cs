// --------------------------------------------------------------------------
// <copyright file="AddMerchandise.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Market.Data;
using Market.Data.Entities;
using Market.Data.Mappers;

namespace Market.UI.DealerForms
{
    /// <summary>
    /// Class represents a form for adding merchanidse for dealer.
    /// </summary>
    public partial class AddMerchandise : Form
    {
        private Dealer _dealer = null;

        private List<DM> _dms = new List<DM>();

        private List<DM> _dmsToDelete = new List<DM>();

        private List<Merchandise> _allMerchandise = MerchandiseMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Merchandise", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));

        private List<SDM> _allSDMs = SDMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("SDM", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));

        private int _commaIndex;

        /// <summary>
        /// Constructor for initializating a new instance of AddMerhcanidse class.
        /// </summary>
        /// <param name="d">Instance of a Dealer class.</param>
        public AddMerchandise(Dealer d)
        {
            InitializeComponent();

            if (d != null)
            {
                _dealer = d;
                this.Text += " для " + d.FirstName + " " + d.LastName;
            }
            else
            {
                MessageBox.Show("Only dealers have rights to visit this form!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void AddMerchandise_Load(object sender, EventArgs e)
        {
            lvAllMerchandise.Items.Clear();
            lbMyMerchandise.Items.Clear();
            foreach (Merchandise m in _allMerchandise)
            {
                ListViewItem i = new ListViewItem();
                i.Text = m.Name;
                i.Tag = m;
                i.ImageIndex = 0;
                lvAllMerchandise.Items.Add(i);
            }

            AddItems(_dealer.AllMerchandise);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvAllMerchandise.SelectedItems.Count > 0)
            {
                var m = lvAllMerchandise.SelectedItems[0].Tag as Merchandise;
                var _dm = _dmsToDelete.Find(dm => dm.Merchandise.ID == m.ID);

                if (_dealer.DMs.Find(dm => dm.MerchandiseID == m.ID) == null)
                {
                    if (_dm != null)
                    {
                        _dmsToDelete.Remove(_dm);
                        AddItems(new List<Merchandise> { _dm.Merchandise });
                    }
                    else
                    {
                        string txt = txtYourCost.Text + (txtYourCost.Text.Length - txtYourCost.Text.IndexOf(',') >= 3 ? "" : "0");
                        float cost = float.Parse(txt.Substring(0, txt.IndexOf(',') == 0 ? txt.Length : (txt.IndexOf(',') + 3)));
                        DM newDM = new DM(_dealer.ID, m.ID);
                        newDM.Cost = cost;
                        _dms.Add(newDM);
                        AddItems(new List<Merchandise> { newDM.Merchandise });
                    }
                }
                else
                {
                    if (_dm != null)
                    {
                        _dmsToDelete.Remove(_dm);
                        AddItems(new List<Merchandise> { _dm.Merchandise });
                    }
                    else MessageBox.Show("Вы уже выбрали такой товар!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else MessageBox.Show("Выберите товар в правом списке и нажмите на кнопку \"+\" для того, что бы добавить.", "Ощибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbMyMerchandise.SelectedItem != null)
            {
                var m = lbMyMerchandise.SelectedItem as Merchandise;
                var dmToRemove = _dealer.DMs.Find(dm => dm.Merchandise.ID == m.ID);

                if (_dealer.DMs.Contains(dmToRemove))
                    if (!_dmsToDelete.Contains(dmToRemove))
                        _dmsToDelete.Add(dmToRemove);
                _dms.Remove(dmToRemove);
                lbMyMerchandise.Items.Remove(dmToRemove.Merchandise);
            }
            else MessageBox.Show("Select item from the left list and then click '-' button to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes ==
                MessageBox.Show("Вы уверенны, что хотите сохранить изменения?" + Environment.NewLine + "Товар, который Вы могли удалить мог использоваться каким-нибудь продавцом, удостовересь в том, что все продавцы знают о том, что вы делаете.",
                "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                try
                {
                    var sdmsToDelete = new List<SDM>();
                    foreach (SDM sdm in _allSDMs)
                        if (_dmsToDelete.Find(dm => dm.Merchandise.ID == sdm.Merchendise.ID && dm.Dealer.ID == sdm.Dealer.ID) != null)
                            sdmsToDelete.Add(sdm);
                    if (sdmsToDelete.Count != 0)
                        MarketProxy.Proxy.UpdateList(SDMMapper.Mapper.Pack(sdmsToDelete), Middleware.UpdateType.Delete);
                    if (_dmsToDelete.Count != 0)
                        MarketProxy.Proxy.UpdateList(DMMapper.Mapper.Pack(_dmsToDelete), Middleware.UpdateType.Delete);
                    if (_dms.Count != 0)
                        MarketProxy.Proxy.UpdateList(DMMapper.Mapper.Pack(_dms), Middleware.UpdateType.Save);

                    MessageBox.Show("Успешно сохранено!", "Созранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Ошибка при удалении!\n Удостовертесь в том, что вы не распрастраняете товар и за тем удалите.\nСообщение ошибки: {0}", ex.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSaveCost_Click(object sender, EventArgs e)
        {
            var m = lbMyMerchandise.SelectedItem as Merchandise;
            if (DialogResult.Yes == MessageBox.Show("Вы уверенны, что хотите сохранить новую цену?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                var _dm = _dms.Find(dm => dm.Merchandise.ID == m.ID);
                if (_dealer.AllMerchandise.Contains(m))
                {
                    var dmToChange = _dealer.DMs.Find(dm => dm.Merchandise.ID == m.ID);
                    dmToChange.Cost = float.Parse(txtYourCost.Text.Substring(0, txtYourCost.Text.IndexOf(',') == -1 ? txtYourCost.Text.Length : txtYourCost.Text.IndexOf(',') + 3));
                    dmToChange.Save();
                }
                else if (_dm != null)
                {
                    _dm.Cost = float.Parse(txtYourCost.Text.Substring(0, txtYourCost.Text.IndexOf(',') + 3));
                    _dm.Save();
                }
            }

            btnSaveCost.Enabled = false;
        }

        private void lvAllMerchandise_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSaveCost.Enabled = false;
            if (lvAllMerchandise.SelectedItems.Count > 0)
            {
                var m = lvAllMerchandise.SelectedItems[0].Tag as Merchandise;
                SetData(m.Name, m.Cost, m.Cost + 10, m.Categories);
            }
            else
                SetData("-", 0, 0, null);
        }

        private void lvAllMerchandise_Click(object sender, EventArgs e) { }

        private void lbMyMerchandise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMyMerchandise.SelectedItem != null)
            {
                btnSaveCost.Enabled = true;
                var m = lbMyMerchandise.SelectedItem as Merchandise;
                var myCost = DMMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("DM", Middleware.MethodType.GetByQuery, "MerchandiseID='" + m.ID + "' AND DealerID='" + _dealer.ID + "'", Guid.Empty))[0];
                SetData(m.Name, m.Cost, myCost.Cost, m.Categories);
            }
        }

        private void txtYourCost_TextChanged(object sender, EventArgs e) { }

        private void txtYourCost_MouseDown(object sender, MouseEventArgs e) { }

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
        private void SetData(string name, float cost, float myCost, List<Category> tags)
        {
            txtName.Text = name;
            txtCost.Text = cost.ToString();
            txtYourCost.Text = myCost.ToString();
            lbTags.Text = "Категории:";
            if (tags != null)
                foreach (Category c in tags)
                    lbTags.Text += " #" + c.Name;
        }

        private void AddItems(List<Merchandise> list)
        {
            foreach (var item in list)
                lbMyMerchandise.Items.Add(item);
        }
        #endregion
    }
}