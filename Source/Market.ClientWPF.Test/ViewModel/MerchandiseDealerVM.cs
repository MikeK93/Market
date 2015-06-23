using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Command.ViewModel.Base;
using Market.ViewModel.DataVM;

namespace Market.ClientWPF.Test.ViewModel
{
    internal class MerchandiseDealerVM : BaseVM
    {
        private DealerVM _dealerVM;
        private MerchandiseVM _newMerchandiseVM;

        private ObservableCollection<MerchandiseVM> _allMerchandise;
        private DMVM _selectedDM;
        private MerchandiseVM _selectedMerchandise;

        // *begin* for creating new merchandise
        private string _mName;
        private float _mCost;
        private ObservableCollection<CategoryVM> _categories;
        private List<CategoryVM> _allCategories;
        private CategoryVM _selectedCategory;
        private CategoryVM _selectedMyCategory;
        // *end* for creating new merchandise

        /// <summary>
        /// Ctor for creating new instance of MerchandiseDealerVM class.
        /// </summary>
        /// <param name="dealer">Instance of DealerVM class.</param>
        public MerchandiseDealerVM(DealerVM dealer)
        {
            _dealerVM = dealer;
            _allMerchandise = MerchandiseVM.GetAll;
            _allCategories = CategoryVM.GetAll;
            _categories = new ObservableCollection<CategoryVM>();
        }

        /// <summary>
        /// Gets all available merchandise.
        /// </summary>
        public ObservableCollection<MerchandiseVM> AllMerchandise
        { get { return _allMerchandise; } }

        /// <summary>
        /// Gets selected items of current dealer.
        /// </summary>
        public ObservableCollection<DMVM> DMs
        { get { return new ObservableCollection<DMVM>(_dealerVM.DMs); } }

        public List<CategoryVM> AllCategories
        { get { return _allCategories; } }

        /// <summary>
        /// Gets categories of a new merchandise added by user.
        /// </summary>
        public ObservableCollection<CategoryVM> SelectedCategories
        { get { return _categories; } }

        /// <summary>
        /// Gets or sets name of a new merchandise added by a user.
        /// </summary>
        public string MName
        {
            get { return _mName; }
            set
            {
                if (value == null)
                    return;

                _mName = value;
                OnPropertyChanged("MName");
            }
        }

        /// <summary>
        /// Gets or sets cost of a new merchandise added by a user.
        /// </summary>
        public float MCost
        {
            get { return _mCost; }
            set
            {
                if (value == null)
                    return;

                _mCost = value;
                OnPropertyChanged("MCost");
            }
        }

        /// <summary>
        /// Gets or sets seleced dm.
        /// </summary>
        public DMVM SelectedDM
        {
            get { return _selectedDM; }
            set
            {
                if (value == null)
                    return;

                _selectedDM = value;
                OnPropertyChanged("SelectedDM");
            }
        }

        /// <summary>
        /// Gets or sets selected merchandise.
        /// </summary>
        public MerchandiseVM SelectedMerchandise
        {
            get { return _selectedMerchandise; }
            set
            {
                if (value == null)
                    return;

                _selectedMerchandise = value;
                OnPropertyChanged("SelectedMerchandise");
            }
        }

        /// <summary>
        /// Gets or sets selected category.
        /// </summary>
        public CategoryVM SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (value == null)
                    return;

                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        /// <summary>
        /// Gets or sets selected my category.
        /// </summary>
        public CategoryVM SelectedMyCategory
        {
            get { return _selectedMyCategory; }
            set
            {
                if (value == null)
                    return;

                _selectedMyCategory = value;
                OnPropertyChanged("SelectedMyCategory");
            }
        }

        #region ICommands

        public ICommand AddMerchandiseCommand
        { get { return Commands.GetOrCreateCommand(() => AddMerchandiseCommand, ExecuteAddMerchandiseCommand, CanExecuteAddMerchandiseCommand); } }

        public ICommand RemoveMerchandiseCommand
        { get { return Commands.GetOrCreateCommand(() => RemoveMerchandiseCommand, ExecuteRemoveMerchandiseCommand, CanExecuteRemoveMerchandiseCommand); } }

        public ICommand AddMyOwnCommand
        { get { return Commands.GetOrCreateCommand(() => AddMyOwnCommand, ExecuteAddMyOwnCommand, CanExecuteAddMyOwnCommand); } }

        public ICommand AddCategory
        { get { return Commands.GetOrCreateCommand(() => AddCategory, ExecuteAddCategory, CanExecuteAddCategory); } }

        public ICommand RemoveCategory
        { get { return Commands.GetOrCreateCommand(() => RemoveCategory, ExecuteRemoveCategory, CanExecuteRemoveCategory); } }

        // RemoveCategory
        private void ExecuteRemoveCategory()
        {
            SelectedCategories.Remove(SelectedMyCategory);
            OnPropertyChanged("Categories");
        }

        private bool CanExecuteRemoveCategory() { return SelectedMyCategory != null; }

        // AddCategory
        private bool CanExecuteAddCategory() { return _selectedCategory != null; }

        // AddCategory
        private void ExecuteAddCategory()
        {
            if (SelectedCategories.Contains(SelectedCategory))
            {
                MessageBox.Show("Вы уже выбрали такой елемент!", "Добавление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SelectedCategories.Add(SelectedCategory);
            OnPropertyChanged("Categories");
        }

        // AddMyOwnCommand
        private bool CanExecuteAddMyOwnCommand()
        {
            if (SelectedCategories == null)
                return false;
            return (!string.IsNullOrEmpty(MName) && MCost != 0 && SelectedCategories.Count != 0);
        }

        // AddMyOwnCommand
        private void ExecuteAddMyOwnCommand()
        {
            _newMerchandiseVM = new MerchandiseVM() { Name = MName, Cost = MCost };
            _newMerchandiseVM.Save();

            // Save MerchandiseCategories relation
            foreach (var c in SelectedCategories)
            {
                var mc = new MerchandiseCategoryVM(_newMerchandiseVM.ID, c.ID);
                mc.Save();
            }

            // Save new DealerMerchandise relation
            var newDM = new DMVM(_dealerVM.ID, _newMerchandiseVM.ID);
            newDM.Cost = MCost;
            newDM.Save();

            // Clean entered data
            SelectedCategories.Clear();
            MName = string.Empty;
            MCost = 0;

            OnPropertyChanged("AllCategories");
            OnPropertyChanged("DMs");
            MessageBox.Show("Успешно добавлено!", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // RemoveCommand
        private bool CanExecuteRemoveMerchandiseCommand() { return SelectedDM != null; }

        // RemoveCommand
        private void ExecuteRemoveMerchandiseCommand()
        {
            if (MessageBox.Show("Вы уверены что хотите удалить " + SelectedDM.MerchandiseName + "?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question)
                != MessageBoxResult.Cancel)
            {
                SelectedDM.Delete();
                OnPropertyChanged("DMs");
            }
        }

        // AddCommand
        private bool CanExecuteAddMerchandiseCommand() { return SelectedMerchandise != null; }

        // AddCommand
        private void ExecuteAddMerchandiseCommand()
        {
            var canAdd = _dealerVM.AllMerchandise.ToList().Contains(SelectedMerchandise);
            if (!canAdd)
            {
                MessageBox.Show("Вы уже выбрали такой товар!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newDM = new DMVM(_dealerVM.ID, SelectedMerchandise.ID);
            newDM.Cost = SelectedMerchandise.Cost;
            newDM.Save();
            OnPropertyChanged("DMs");
        }

        #endregion
    }
}