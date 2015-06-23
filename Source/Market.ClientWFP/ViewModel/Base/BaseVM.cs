using System.ComponentModel;

namespace Command.ViewModel.Base
{
    public class BaseVM : INotifyPropertyChanged, IDataErrorInfo
    {
        private CommandHolder _commands;
        public CommandHolder Commands
        {
            get { return _commands ?? (_commands = new CommandHolder()); }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region IDataErrorInfo Members

        public virtual string Error
        {
            get { return string.Empty; }
        }

        public virtual string this[string columnName]
        {
            get { return string.Empty; }
        }

        #endregion
    }
}