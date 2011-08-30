using System;
using System.Collections.Generic;
using System.Text;
using BlogManager.ObjectModel;
using MetaBlog;

namespace BlogManager.MetaBlogServices.Utils
{
    internal static class CategoryUtils
    {
        internal static Category BuildCategory(CategoryInfo source)
        {
            Category res = new Category();
            res.Id = source.categoryid;
            res.Description = source.description;
            res.HtmlUrl = source.htmlUrl;
            res.RssUrl = source.rssUrl;
            res.Title = source.title;

            return res;
        }

        internal static MtCategory[] GetCategoryInfos(List<Category> categories)
        {
            List<MtCategory> res = new List<MtCategory>();
            foreach (var category in categories)
            {
                MtCategory item = new MtCategory();
                item.categoryId = category.Id;
                item.categoryName = category.Description;
                item.isPrimary = false;

                res.Add(item);
            }

            return res.ToArray();
        }
    }
}
