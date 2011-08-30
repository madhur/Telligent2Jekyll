using System;
using System.Collections.Generic;
using System.Text;

namespace BlogManager.ObjectModel
{
    public class Category
    {
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string htmlUrl;

        public string HtmlUrl
        {
            get { return htmlUrl; }
            set { htmlUrl = value; }
        }
        private string rssUrl;

        public string RssUrl
        {
            get { return rssUrl; }
            set { rssUrl = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}
