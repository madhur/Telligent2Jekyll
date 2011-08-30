using System;
using System.Collections.Generic;
using System.Text;

namespace MetaBlog
{
    public struct BlogInfo
    {
        string blogid;
        string url;
        string blogName;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BlogInfo"/> class.
        /// </summary>
        /// <param name="blogid">The blogid.</param>
        /// <param name="url">The URL.</param>
        /// <param name="blogName">Name of the blog.</param>
        public BlogInfo(string blogid, string url, string blogName)
        {
            this.blogid = blogid;
            this.url = url;
            this.blogName = blogName;
        }
    }
}
