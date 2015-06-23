using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Security;
using Market.Security.Models;

namespace Market.Security
{
    public class MarketMembershipProvider : System.Web.Security.MembershipProvider
    {
        #region Fields
        private string _applicationName;
        private bool _enablePasswordReset;
        private bool _enablePasswordRetrieval;
        private int _maxInvalidPasswordAttempts;
        private int _minRequiredNonAlphanumericCharacters;
        private int _minRequiredPasswordLength;
        private int _passwordAttemptWindow;
        private MembershipPasswordFormat _passwordFormat;
        private string _passwordStrengthRegularExpression;
        private bool _requiresQuestionAndAnswer;
        private bool _requiresUniqueEmail;
        private MachineKeySection machineKey;
        private string _connectionString;
        #endregion

        #region Properties
        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }

        public override bool EnablePasswordReset { get { return _enablePasswordReset; } }

        public override bool EnablePasswordRetrieval { get { return _enablePasswordRetrieval; } }

        public override int MaxInvalidPasswordAttempts { get { return _maxInvalidPasswordAttempts; } }

        public override int MinRequiredNonAlphanumericCharacters { get { return _minRequiredNonAlphanumericCharacters; } }

        public override int MinRequiredPasswordLength { get { return _minRequiredPasswordLength; } }

        public override int PasswordAttemptWindow { get { return _passwordAttemptWindow; } }

        public override MembershipPasswordFormat PasswordFormat { get { return _passwordFormat; } }

        public override string PasswordStrengthRegularExpression { get { return _passwordStrengthRegularExpression; } }

        public override bool RequiresQuestionAndAnswer { get { return _requiresQuestionAndAnswer; } }

        public override bool RequiresUniqueEmail { get { return _requiresUniqueEmail; } }
        #endregion

        #region Initialize
        //public override void Initialize(string name, NameValueCollection config)
        //{
        //    if (config == null)
        //        throw new ArgumentNullException("config");

        //    if (string.IsNullOrEmpty(name))
        //        name = "Market";

        //    base.Initialize(name, config);

        //    _applicationName = GetConfigValue(config["applicationName"], "Market");
        //    _maxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
        //    _passwordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
        //    _minRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredAlphaNumericCharacters"], "1"));
        //    _minRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));
        //    _passwordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], String.Empty));
        //    _enablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));
        //    _enablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "true"));
        //    _requiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "false"));
        //    _requiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "true"));

        //    string temp_format = config["passwordFormat"];
        //    if (temp_format == null)
        //    {
        //        temp_format = "Hashed";
        //    }


        //    switch (temp_format)
        //    {
        //        case "Hashed":
        //            _passwordFormat = MembershipPasswordFormat.Hashed;
        //            break;
        //        case "Encrypted":
        //            _passwordFormat = MembershipPasswordFormat.Encrypted;
        //            break;
        //        case "Clear":
        //            _passwordFormat = MembershipPasswordFormat.Clear;
        //            break;
        //        default:
        //            throw new ProviderException("Password format not supported.");
        //    }

        //    ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

        //    if ((ConnectionStringSettings == null) || (ConnectionStringSettings.ConnectionString.Trim() == String.Empty))
        //    {
        //        throw new ProviderException("Connection string cannot be blank.");
        //    }

        //    _connectionString = ConnectionStringSettings.ConnectionString;

        //    //Get encryption and decryption key information from the configuration.
        //    System.Configuration.Configuration cfg = WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
        //    machineKey = cfg.GetSection("system.web/machineKey") as MachineKeySection;

        //    if (machineKey.ValidationKey.Contains("AutoGenerate"))
        //    {
        //        if (PasswordFormat != MembershipPasswordFormat.Clear)
        //        {
        //            throw new ProviderException("Hashed or Encrypted passwords are not supported with auto-generated keys.");
        //        }
        //    }
        //}

        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
            {
                return defaultValue;
            }

            return configValue;
        }

        #endregion
        #region methods
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
        {
            
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var user = new System.Web.Security.MembershipUser("MarketMembershipProvider", username, null, string.Empty, string.Empty, string.Empty, false, false, DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow);
            return user;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            try
            {
                return MarketProxy.Proxy.GetData("User"
                    , Middleware.MethodType.GetByQuery
                    , string.Format("Login='{0}' AND PWord='{1}'", username, password)
                    , Guid.Empty).Count != 0;
            }
            catch { return false; }
        }
        #endregion
    }
}
