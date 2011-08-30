using System;
using System.Collections.Generic;
using System.Text;

namespace MetaBlog
{
    public struct CategoryInfo
    {
        public string description;
        public string htmlUrl;
        public string rssUrl;
        public string title;
        public string categoryid;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CategoryInfo"/> class.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="htmlUrl">The HTML URL.</param>
        /// <param name="rssUrl">The RSS URL.</param>
        /// <param name="title">The title.</param>
        /// <param name="categoryid">The categoryid.</param>
        public CategoryInfo(string description, string htmlUrl, string rssUrl, string title, string categoryid)
        {
            this.description = description;
            this.htmlUrl = htmlUrl;
            this.rssUrl = rssUrl;
            this.title = title;
            this.categoryid = categoryid;
        }
    }
}
