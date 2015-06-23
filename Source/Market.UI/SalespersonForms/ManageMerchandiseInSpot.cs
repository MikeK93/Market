// --------------------------------------------------------------------------
// <copyright file="ManageMerchandiseInSpot.cs" company="MK inc.">
//      Copyright © MK inc. 2014-2015. All rights reserved.
// </copyright>
// <author>Kozlov M.M.</author>
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Market.Data;
using Market.Data.Entities;
using Market.Data.Mappers;

namespace Market.UI.SalespersonForms
{
    /// <summary>
    /// Class represents a form for managing merchanidse in spot.
    /// </summary>
    public partial class ManageMerchandiseInSpot : Form
    {
        private Spot _currentSpot = null;

        private Salesperson _currentSalesperson = null;

        private List<SpotSDM> _spotSDMsToDel = new List<SpotSDM>();

        private List<SpotSDM> _spotSDMsToAdd = new List<SpotSDM>();

        /// <summary>
        /// Constructor for initializing a new instance of ManageMerchandiseInSpot class.
        /// </summary>
        /// <param name="sp">Instance of Salesperson.</param>
        /// <param name="s">Instance of Spot.</param>
        public ManageMerchandiseInSpot(Salesperson sp, Spot s)
        {
            InitializeComponent();

            if (s != null && sp != null)
            {
                _currentSpot = s;
                _currentSalesperson = sp;
                InitForm();
            }
            else
            {
                MessageBox.Show("Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void lvAllMerchandise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAllMerchandise.SelectedItems.Count > 0)
            {
                var sdm = lvAllMerchandise.SelectedItems[0].Tag as SDM;
                SetInfo(sdm);
            }
            else
                SetInfo(null);
        }

        private void lvSelectedMerchandise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSelectedMerchandise.SelectedItems.Count > 0)
            {
                var sdm = lvSelectedMerchandise.SelectedItems[0].Tag as SDM;
                SetInfo(sdm);
            }
            else
                SetInfo(null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvAllMerchandise.SelectedItems.Count > 0)
            {
                var sdm = lvAllMerchandise.SelectedItems[0].Tag as SDM;
                var ssdm = _spotSDMsToDel.Find(_ssdm => (_ssdm.SDM.ID == sdm.ID && _ssdm.Spot.ID == _currentSpot.ID));

                if (_currentSpot.SDMs.Find(_sdm => _sdm.ID == sdm.ID) == null)
                {
                    if (ssdm != null)
                    {
                        _spotSDMsToDel.Remove(ssdm);
                        _spotSDMsToAdd.Add(ssdm);
                        UpdateSelectedMerchanise(new List<SDM> { ssdm.SDM }, false);
                    }
                    else
                    {
                        SpotSDM newSSDM = new SpotSDM(_currentSpot.ID, sdm.ID);
                        _spotSDMsToAdd.Add(newSSDM);
                        UpdateSelectedMerchanise(new List<SDM> { newSSDM.SDM }, false);
                    }
                }
                else
                {
                    if (ssdm != null)
                    {
                        _spotSDMsToDel.Remove(ssdm);
                        _spotSDMsToAdd.Add(ssdm);
                        UpdateSelectedMerchanise(new List<SDM> { ssdm.SDM }, false);
                    }
                    else MessageBox.Show("Вы уже выбрали такой товар.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Выберите товар и за тем нажмите на кнопку \"Добавить\".", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvSelectedMerchandise.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить выбраный товар?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var sdm = lvSelectedMerchandise.SelectedItems[0].Tag as SDM;
                    var ssdmToRemove = _currentSpot.SpotSDMs.Find(_ssdm => _ssdm.SDM.ID == sdm.ID);
                    if (_currentSpot.SDMs.Contains(sdm))
                    {
                        if (!_spotSDMsToDel.Contains(ssdmToRemove))
                            _spotSDMsToDel.Add(ssdmToRemove);
                    }
                    else
                        ssdmToRemove = _spotSDMsToAdd.Find(_ssdm => _ssdm.SDM.ID == sdm.ID);
                    _spotSDMsToAdd.Remove(ssdmToRemove);
                    lvSelectedMerchandise.Items.Remove(lvSelectedMerchandise.SelectedItems[0]);
                }
            }
            else
                MessageBox.Show("Выберите сначало товар из списка справа и за тем нажмите на кнопку \"Удалить\".", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверенны, что хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (_spotSDMsToDel.Count != 0)
                    {
                        MarketProxy.Proxy.UpdateList(SpotSDMMapper.Mapper.Pack(_spotSDMsToDel), Middleware.UpdateType.Delete);
                        _spotSDMsToDel.Clear();
                    }

                    if (_spotSDMsToAdd.Count != 0)
                    {
                        MarketProxy.Proxy.UpdateList(SpotSDMMapper.Mapper.Pack(_spotSDMsToAdd), Middleware.UpdateType.Save);
                        _spotSDMsToAdd.Clear();
                    }

                    MessageBox.Show("Изменения успешно сохранены!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #region Helping Methods

        private void SetInfo(SDM sdm)
        {
            if (sdm != null)
            {
                txtDFN.Text = sdm.Dealer.FirstName;
                txtDLN.Text = sdm.Dealer.LastName;
                txtDMN.Text = sdm.Dealer.MiddleName;
                txtMCost.Text = sdm.Cost.ToString();
                txtMName.Text = sdm.Merchendise.Name;
            }
            else txtDFN.Text = txtDLN.Text = txtDMN.Text = txtMCost.Text = txtMName.Text = "-";
        }

        private void InitForm()
        {
            UpdateAllMerchandise(_currentSalesperson.SDMs, true);
            UpdateSelectedMerchanise(_currentSpot.SDMs, true);
            this.Text += " в точке №" + _currentSpot.Number;
        }

        private void UpdateAllMerchandise(List<SDM> list, bool isClear)
        {
            if (isClear)
                lvAllMerchandise.Items.Clear();
            foreach (SDM sdm in list)
            {
                ListViewItem i = new ListViewItem();
                i.Text = sdm.Merchendise.Name;
                i.Tag = sdm;
                i.ImageIndex = 0;
                lvAllMerchandise.Items.Add(i);
            }
        }

        private void UpdateSelectedMerchanise(List<SDM> list, bool isClear)
        {
            if (isClear)
                lvSelectedMerchandise.Items.Clear();
            foreach (SDM sdm in list)
            {
                ListViewItem i = new ListViewItem();
                i.Text = sdm.Merchendise.Name;
                i.Tag = sdm;
                i.ImageIndex = 1;
                lvSelectedMerchandise.Items.Add(i);
            }
        }

        #endregion
    }
}