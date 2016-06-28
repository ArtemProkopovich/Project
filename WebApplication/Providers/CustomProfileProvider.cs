using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Profile;
using NLog;
using Service.Interfacies;

namespace WebApplication.Providers
{
    public class CustomProfileProvider : ProfileProvider
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        public IUserService userService = DependencyResolver.Current.GetService<IUserService>();
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            try
            {
                var result = new SettingsPropertyValueCollection();

                if (collection.Count < 1)
                {
                    return result;
                }

                // получаем из контекста имя пользователя - логин в системе
                var username = (string) context["UserName"];
                if (string.IsNullOrEmpty(username))
                {
                    result.Add(new SettingsPropertyValue(collection["ID"]) {PropertyValue = 0});
                    return result;
                }
                var user = userService.GetUserByEmail(username) ?? userService.GetUserByLogin(username);
                int id = user?.ID ?? 0;
                result.Add(new SettingsPropertyValue(collection["ID"]) {PropertyValue = id});
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return new SettingsPropertyValueCollection();
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            
        }

        #region Not implemented methods
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override int DeleteProfiles(string[] usernames)
        {
            throw new NotImplementedException();
        }

        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }
#endregion
    }
}