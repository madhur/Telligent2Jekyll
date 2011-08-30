using System.Collections.Generic;
using BlogManager.MetaBlogServices.Utils;
using BlogManager.ObjectModel;
using BlogManager.Services;
using MetaBlog;
using CookComputing.XmlRpc;

namespace BlogManager.MetaBlogServices
{
    internal class CategoryService: ServiceBase, ICategoryService
    {
        #region ICategoryService Members

        public IList<Category> GetAll()
        {
            try
            {
                IBlogger blogger = this.GetBlogger();
                CategoryInfo[] categories = blogger.getCategories(this.BlogId, this.Username, this.Password);

                List<Category> res = new List<Category>();
                foreach (var categoryInfo in categories)
                {
                    res.Add(CategoryUtils.BuildCategory(categoryInfo));
                }
                return res;
            }
            catch (XmlRpcFaultException ex)
            {
                throw new ConnectionException(ex);
            }
        }

        public IDictionary<string, Category> GetCategoryDictionary()
        {
            Dictionary<string, Category> res = new Dictionary<string, Category>();
            IList<Category> categories = this.GetAll();

            foreach (var category in categories)
            {
                res.Add(category.Description, category);
            }

            return res;
        }

        #endregion
    }
}
