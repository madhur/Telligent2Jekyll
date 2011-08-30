using System;
using System.Collections.Generic;
using System.Text;
using MetaBlog;
using BlogManager.Configuration;

namespace BlogManager.MetaBlogServices
{
    public class ServiceBase
    {
        private string blogId;

        public string BlogId
        {
            get { return blogId; }
            set { blogId = value; }
        }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        protected IBlogger GetBlogger()
        {
            IBlogger res = MetaBlogAPIFactory.Create();
            res.Url = Settings.Default.BlogUrl;

            return res;
        }
    }
}
