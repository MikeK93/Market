// --------------------------------------------------------------------------
// <copyright file="SpotManager.cs" company="MK inc.">
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
    /// Class represents a form for managing spots.
    /// </summary>
    public partial class SpotManager : Form
    {
        private Salesperson _salesperson = null;

        private List<Spot> _spotsToDel = new List<Spot>();

        private List<Spot> _spotsToAdd = new List<Spot>();

        /// <summary>
        /// Constructor for initializing a new instance of SpotManager class.
        /// </summary>
        /// <param name="s">Instance of Salesperson.</param>
        public SpotManager(Salesperson s)
        {
            InitializeComponent();

            if (s != null)
            {
                _salesperson = s;
                UpdateSelection(s.Spots, true);
                InitForm();
            }
            else
            {
                MessageBox.Show("Error! You are not a salesperson!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void SpotManager_Load(object sender, EventArgs e) { }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Вы уверенны, что хотите принять изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (Spot s in _spotsToDel)
                        s.Save();
                    foreach (Spot s in _spotsToAdd)
                        s.Save();
                    InitForm();
                    MessageBox.Show("Изменения сохранены.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _spotsToAdd.Clear();
                    _spotsToDel.Clear();
                    InitForm();
                    UpdateSelection(_salesperson.Spots, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvAllSpots.SelectedItems.Count > 0)
            {
                var s = lvAllSpots.SelectedItems[0].Tag as Spot;
                var sToDel = _spotsToDel.Find(_s => _s == s);

                if (!_salesperson.Spots.Contains(s))
                {
                    if (sToDel != null)
                    {
                        _spotsToDel.Remove(sToDel);
                        _spotsToAdd.Add(sToDel);
                        sToDel.Salesperson = _salesperson;
                        UpdateSelection(new List<Spot> { sToDel }, false);
                    }
                    else
                    {
                        s.Salesperson = _salesperson;
                        _spotsToAdd.Add(s);
                        UpdateSelection(new List<Spot> { s }, false);
                    }
                }
                else
                {
                    if (sToDel != null)
                    {
                        _spotsToDel.Remove(sToDel);
                        _spotsToAdd.Add(sToDel);
                        UpdateSelection(new List<Spot> { sToDel }, false);
                    }
                    else
                        MessageBox.Show("Вы уже выбради это место.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Выберите место и за тем нажмите кнопку \"+\" для добавления.", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверенны, что хотите удалить?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (lvSelectedSpots.SelectedItems.Count > 0)
                {
                    var s = lvSelectedSpots.SelectedItems[0].Tag as Spot;
                    if (!_salesperson.Spots.Contains(s))
                        if (!_spotsToDel.Contains(s))
                        {
                            s.Salesperson = null;
                            _spotsToDel.Add(s);
                        }

                    _spotsToAdd.Remove(s);
                    lvSelectedSpots.Items.Remove(lvSelectedSpots.SelectedItems[0]);
                }
                else MessageBox.Show("Выберите место и за тем нажмите на кнопку \"-\" для удаления.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lvSelectedSpots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSelectedSpots.SelectedItems.Count > 0)
            {
                var s = lvSelectedSpots.SelectedItems[0].Tag as Spot;
                SetData(s);
            }
            else
                SetData(null);
        }

        private void lvAllSpots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAllSpots.SelectedItems.Count > 0)
            {
                var s = lvAllSpots.SelectedItems[0].Tag as Spot;
                SetData(s);
            }
            else
                SetData(null);
        }

        #region Helping Methods

        private void UpdateSelection(List<Spot> spots, bool clear)
        {
            if (clear)
                lvSelectedSpots.Items.Clear();
            if (spots != null)
            {
                foreach (Spot s in spots)
                {
                    ListViewItem i = new ListViewItem();
                    i.Text = s.Number.ToString();
                    i.ImageIndex = 1;
                    i.Tag = s;
                    lvSelectedSpots.Items.Add(i);
                }
            }
        }

        private void InitForm()
        {
            lvAllSpots.Items.Clear();
            var allSpots = SpotMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Spot", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));
            foreach (Spot s in allSpots)
            {
                if (s.Salesperson == null)
                {
                    ListViewItem i = new ListViewItem();
                    i.Text = s.Number.ToString();
                    i.Tag = s;
                    i.ImageIndex = 0;
                    lvAllSpots.Items.Add(i);
                }
            }
        }

        private void SetData(Spot s)
        {
            if (s != null)
            {
                txtSpotMCAddress.Text = s.MakerCompany.FullAddress;
                txtSpotMCName.Text = s.MakerCompany.Name;
                txtSpotNumber.Text = s.Number.ToString();
                txtSpotSTCost.Text = s.SecurityType.Cost.ToString();
                txtSpotSTGuards.Text = s.SecurityType.Guards.ToString();
                txtSpotSTName.Text = s.SecurityType.Name;
                txtAddress.Text = s.Address;
                dtpSpotDateStart.Visible = true;
                dtpSpotDateStart.Value = s.DateStart;
            }
            else
            {
                txtSpotMCAddress.Text = txtAddress.Text = txtSpotMCName.Text = txtSpotNumber.Text = txtSpotSTCost.Text = txtSpotSTGuards.Text = txtSpotSTName.Text = "-";
                dtpSpotDateStart.Visible = false;
            }
        }
        #endregion
    }
}