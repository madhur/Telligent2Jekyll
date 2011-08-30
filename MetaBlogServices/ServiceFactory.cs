using System;
using System.Collections.Generic;
using System.Text;
using BlogManager.Services;
using BlogManager.Configuration;

namespace BlogManager.MetaBlogServices
{
    internal class ServiceFactory: IServiceFactory
    {
        private void initializeService(ServiceBase res)
        {
            res.BlogId = Settings.Default.BlogId;
            res.Url = Settings.Default.BlogUrl;
            res.Username = Settings.Default.Username;
            res.Password = Settings.Default.Password;
        }

        #region IServiceFactory Members

        public ICategoryService GetCategoryService()
        {
            CategoryService res = new CategoryService();
            initializeService(res);

            return res;
        }

        public IPostService GetPostService()
        {
            PostService res = new PostService();
            initializeService(res);

            return res;
        }

        #endregion
    }
}
