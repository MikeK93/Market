// --------------------------------------------------------------------------
// <copyright file="AddBank.cs" company="MK inc.">
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

namespace Market.UI
{
    /// <summary>
    /// Class represents a form for adding banks.
    /// </summary>
    public partial class AddBank : Form
    {
        private Dealer _dealer = null;

        private Salesperson _salesperson = null;

        private bool _isDealer = false;

        private List<BankDealer> _bds = new List<BankDealer>();

        private List<BankDealer> _bdsToRemove = new List<BankDealer>();

        private List<BankSalesperson> _bss = new List<BankSalesperson>();

        private List<BankSalesperson> _bssToRemove = new List<BankSalesperson>();

        /// <summary>
        /// Constructor for initializating a new instance of AddBank.
        /// </summary>
        /// <param name="obj">Object that point out what kind of appereance the form will take. (instance of Dealer or Salesperson classes)</param>
        public AddBank(object obj)
        {
            InitializeComponent();

            if (obj is Dealer)
            {
                _dealer = obj as Dealer;
                _isDealer = true;
            }
            else if (obj is Salesperson)
            {
                _salesperson = obj as Salesperson;
                _isDealer = false;
            }
            else
            {
                MessageBox.Show("In order to add bank you have to be salesperson or dealer!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void AddBank_Load(object sender, EventArgs e)
        {
            var allBanks =
                BankMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("Bank", Middleware.MethodType.GetAllItems, string.Empty, Guid.Empty));

            foreach (Bank b in allBanks)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = b.Name;
                lvi.Tag = b;
                lvi.ImageIndex = 0;
                lvAllBanks.Items.Add(lvi);
            }

            if (_isDealer)
                AddItems(_dealer.Banks);
            else
                AddItems(_salesperson.Banks);
        }

        private void lvAllBanks_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var b = e.Item.Tag as Bank;
            if (b != null)
                txtAddress.Text = b.Address;
        }

        private void btnAddBank_Click(object sender, EventArgs e)
        {
            if (lvAllBanks.SelectedItems.Count > 0)
            {
                var myBanks = lbYourBanks.Items.Cast<Bank>();
                var bankToAdd = lvAllBanks.SelectedItems[0].Tag as Bank;
                var copies = (from b in myBanks.ToList().AsEnumerable()
                              where b.Name == bankToAdd.Name && b.Address == bankToAdd.Address
                              select b).ToList();
                if (copies.Count != 0)
                    MessageBox.Show("Вы уже выбрали такой банк '" + bankToAdd.Name + "'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (_isDealer)
                    {
                        BankDealer bd = new BankDealer(bankToAdd.ID, _dealer.ID);
                        _bds.Add(bd);
                        AddItems(new List<Bank> { bankToAdd });
                    }
                    else
                    {
                        BankSalesperson bs = new BankSalesperson(bankToAdd.ID, _salesperson.ID);
                        _bss.Add(bs);
                        AddItems(new List<Bank> { bankToAdd });
                    }
                }
            }
            else
                MessageBox.Show("Выберите банк и затем нажмите на кномку \"+\".", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRemoveBank_Click(object sender, EventArgs e)
        {
            if (lbYourBanks.SelectedItem != null)
            {
                var bankToRemove = lbYourBanks.SelectedItem as Bank;

                if (_isDealer)
                {
                    if (_dealer.Banks.Contains(bankToRemove))
                        _bdsToRemove.Add(BankDealerMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("BankDealer", Middleware.MethodType.GetByQuery, "BankID='" + bankToRemove.ID + "' AND DealerID='" + _dealer.ID + "'", Guid.Empty)[0]));

                    _bds.Remove(_bds.Find(bd => bd.Bank.ID == bankToRemove.ID));
                    lbYourBanks.Items.Remove(bankToRemove);
                }
                else
                {
                    if (_salesperson.Banks.Contains(bankToRemove))
                        _bssToRemove.Add(BankSalespersonMapper.Mapper.UnPack(MarketProxy.Proxy.GetData("BankSalesperson", Middleware.MethodType.GetByQuery, "BankID='" + bankToRemove.ID + "' AND SalespersonID='" + _salesperson.ID + "'", Guid.Empty)[0]));

                    _bss.Remove(_bss.Find(bs => bs.Bank.ID == bankToRemove.ID));
                    lbYourBanks.Items.Remove(bankToRemove);
                }
            }
            else
                MessageBox.Show("Выберите банк и затем нажмите на кномку \"-\".", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Вы уверенны, что хотите сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (_isDealer)
                {
                    foreach (BankDealer bd in _bdsToRemove)
                        bd.Delete();
                    foreach (BankDealer bd in _bds)
                        bd.Save();
                }
                else
                {
                    foreach (BankSalesperson bs in _bssToRemove)
                        bs.Delete();
                    foreach (BankSalesperson bs in _bss)
                        bs.Save();
                }

                Close();
            }
        }

        private void AddItems(List<Bank> banks)
        {
            foreach (var item in banks)
                lbYourBanks.Items.Add(item);
        }

        private void btnCancel_Click(object sender, EventArgs e) { }
    }
}