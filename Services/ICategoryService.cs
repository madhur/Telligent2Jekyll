using System.Collections.Generic;
using BlogManager.ObjectModel;

namespace BlogManager.Services
{
    public interface ICategoryService
    {
        IList<Category> GetAll();
        IDictionary<string, Category> GetCategoryDictionary();
    }
}
