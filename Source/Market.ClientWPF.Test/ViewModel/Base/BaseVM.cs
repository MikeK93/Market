using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Command.ViewModel.Base
{
    public class BaseVM : INotifyPropertyChanged, IDataErrorInfo
    {
        static private Dictionary<string, object> _properties = new Dictionary<string, object>();
        private string _currentProperty;

        private CommandHolder _commands;
        public CommandHolder Commands
        {
            get { return _commands ?? (_commands = new CommandHolder()); }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            _currentProperty = propertyName;

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if (!_properties.ContainsKey(propertyName))
                _properties.Add(propertyName, this);
        }

        #endregion

        #region IDataErrorInfo Members

        public virtual string Error
        {
            get
            {
                throw new NotSupportedException("IDataErrorInfo.Error is not supported, use IDataErrorInfo.this[propertyName] instead.");
            }
        }

        public virtual string this[string propertyName]
        {
            get { return GetErrorMessage(propertyName); }
        }

        private string GetErrorMessage(string propName)
        {
            if (_properties.ContainsKey(propName))
            {
                string errorMessage = string.Empty;
                var property = _properties[propName].GetType().GetProperty(propName);
                var propertyValue = property.GetValue(_properties[propName]);
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>(1);
                var result = Validator.TryValidateProperty(
                    propertyValue,
                    new ValidationContext(this, null, null)
                    {
                        MemberName = propName
                    },
                    results);

                if (!result)
                {
                    var validationResult = results.First();
                    errorMessage = validationResult.ErrorMessage;
                }
                return errorMessage;
            }

            return string.Empty;
        }

        #endregion
    }
}