// --------------------------------------------------------------------------
// <copyright file="AddSpotToMerchandise.cs" company="MK inc.">
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
    /// Class represents a form for adding spots to merchandise.
    /// </summary>
    public partial class AddSpotToMerchandise : Form
    {
        private SDM _currentSDM = null;

        private Salesperson _salesperson = null;

        private List<SpotSDM> _spotSDMsToAdd = new List<SpotSDM>();

        private List<SpotSDM> _spotSDMsToDel = new List<SpotSDM>();

        /// <summary>
        /// Costructor for initializing a new instance of AddSpotToMerchandise class.
        /// </summary>
        /// <param name="sdm">Instance of SDM.</param>
        /// <param name="s">Instance of Salesperson.</param>
        public AddSpotToMerchandise(SDM sdm, Salesperson s)
        {
            InitializeComponent();

            if (sdm != null && s != null)
            {
                _currentSDM = sdm;
                _salesperson = s;
                InitForm();
            }
            else
            {
                MessageBox.Show("Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvAllSpots.Items.Count > 0)
            {
                var s = lvAllSpots.SelectedItems[0].Tag as Spot;
                var ssdm = _spotSDMsToDel.Find(_ssdm => (_ssdm.SDM.ID == _currentSDM.ID && _ssdm.Spot.ID == s.ID));

                if (_currentSDM.Spots.Find(_s => _s.ID == s.ID) == null)
                {
                    if (ssdm != null)
                    {
                        _spotSDMsToDel.Remove(ssdm);
                        _spotSDMsToAdd.Add(ssdm);
                        UpdateSelectedSpots(new List<Spot> { ssdm.Spot }, false);
                    }
                    else
                    {
                        SpotSDM newSSDM = new SpotSDM(s.ID, _currentSDM.ID);
                        _spotSDMsToAdd.Add(newSSDM);
                        UpdateSelectedSpots(new List<Spot> { newSSDM.Spot }, false);
                    }
                }
                else
                {
                    if (ssdm != null)
                    {
                        _spotSDMsToDel.Remove(ssdm);
                        _spotSDMsToAdd.Add(ssdm);
                        UpdateSelectedSpots(new List<Spot> { ssdm.Spot }, false);
                    }
                    else MessageBox.Show("Товар уже есть в точке №" + s.Number + ".", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Выберите место и за тем нажмите на кнопку \"Добавить\".", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvSelectedSpots.SelectedItems.Count > 0)
            {
                var s = lvSelectedSpots.SelectedItems[0].Tag as Spot;
                if (MessageBox.Show("Вы уверены, что хотите удалить товар из места №" + s.Number + ".", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_currentSDM.Spots.Contains(s))
                    {
                        var ssdmToRemove = _currentSDM.SpotSDMs.Find(_ssdm => _ssdm.Spot.ID == s.ID);
                        if (!_spotSDMsToDel.Contains(ssdmToRemove))
                            _spotSDMsToDel.Add(ssdmToRemove);
                        _spotSDMsToAdd.Remove(ssdmToRemove);
                    }

                    lvSelectedSpots.Items.Remove(lvSelectedSpots.SelectedItems[0]);
                }
            }
            else
                MessageBox.Show("Выберите место из списка справа и за тем нажмите на кнопку \"Удалить\".", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (_spotSDMsToDel.Count != 0)
                        MarketProxy.Proxy.UpdateList(SpotSDMMapper.Mapper.Pack(_spotSDMsToDel), Middleware.UpdateType.Delete);
                    if (_spotSDMsToAdd.Count != 0)
                        MarketProxy.Proxy.UpdateList(SpotSDMMapper.Mapper.Pack(_spotSDMsToAdd), Middleware.UpdateType.Save);
                    MessageBox.Show("Изменения успешно сохранены!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #region Helping Methods

        private void InitForm()
        {
            this.Text = "Управление \"" + _currentSDM.Merchendise.Name + "\" в местах";
            UpdateAllSpots(_salesperson.Spots, true);
            UpdateSelectedSpots(_currentSDM.Spots, true);
        }

        private void UpdateAllSpots(List<Spot> spots, bool isClear)
        {
            if (isClear)
                lvAllSpots.Items.Clear();
            foreach (Spot s in spots)
            {
                ListViewItem i = new ListViewItem();
                i.Text = s.Number.ToString();
                i.Tag = s;
                i.ImageIndex = 0;
                lvAllSpots.Items.Add(i);
            }
        }

        private void UpdateSelectedSpots(List<Spot> spots, bool isClear)
        {
            if (isClear)
                lvSelectedSpots.Items.Clear();
            foreach (Spot s in spots)
            {
                ListViewItem i = new ListViewItem();
                i.Text = s.Number.ToString();
                i.Tag = s;
                i.ImageIndex = 1;
                lvSelectedSpots.Items.Add(i);
            }
        }
        #endregion
    }
}