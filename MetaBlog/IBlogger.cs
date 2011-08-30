using System;
using System.Collections.Generic;
using System.Text;
using CookComputing.XmlRpc;

namespace MetaBlog
{
    [XmlRpcUrl("http://blogs.msdn.com/metablog.ashx")]
    public interface IBlogger : IXmlRpcProxy
    {
        /// <summary>
        /// Deletes a post.
        /// </summary>
        /// <param name="appKey">The app key.</param>
        /// <param name="postid">The postid.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="publish">Where applicable, this specifies whether the blog should be republished after the post has been deleted.</param>
        /// <returns>Always returns true.</returns>
        [XmlRpcMethod("blogger.deletePost")]
        bool deletePost(string appKey, string postid, string username, string password, bool publish);

        /// <summary>
        /// Returns information on all the blogs a given user is a member.
        /// </summary>
        /// <param name="appKey">The app key.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        [XmlRpcMethod("blogger.getUsersBlogs")]
        BlogInfo[] getUsersBlogs(string appKey, string username, string password);

        /// <summary>
        /// Updates and existing post to a designated blog using the metaWeblog API. Returns true if completed.
        /// </summary>
        /// <param name="and"></param>
        /// <returns></returns>
        [XmlRpcMethod("metaWeblog.editPost")]
        bool editPost(string postid, string username, string password, PostInfo post, bool publish);

        /// <summary>
        /// Retrieves a list of valid categories for a post using the metaWeblog API. Returns the metaWeblog categories struct collection.
        /// </summary>
        /// <param name="blogid">The blogid.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Array of struct CategoryInfo</returns>
        [XmlRpcMethod("metaWeblog.getCategories")]
        CategoryInfo[] getCategories(string blogid, string username, string password);

        /// <summary>
        /// Retrieves an existing post using the metaWeblog API. Returns the metaWeblog struct
        /// </summary>
        /// <param name="postid">The postid.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Post struct</returns>
        [XmlRpcMethod("metaWeblog.getPost")]
        PostInfo getPost(string postid, string username, string password);

        /// <summary>
        /// Retrieves a list of the most recent existing post using the metaWeblog API. Returns the metaWeblog struct collection.
        /// </summary>
        /// <param name="blogid">The blogid.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="numberOfPosts">The number of posts.</param>
        /// <returns>Array of Post instances</returns>
        [XmlRpcMethod("metaWeblog.getRecentPosts")]
        PostInfo[] getRecentPosts(string blogid, string username, string password, int numberOfPosts);

        /// <summary>
        /// Makes a new post to a designated blog using the metaWeblog API. Returns postid as a string.
        /// </summary>
        /// <param name="blogid">The blogid.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="post">The post.</param>
        /// <param name="publish">if set to <c>true</c> [publish].</param>
        /// <returns>String as Post ID</returns>
        [XmlRpcMethod("metaWeblog.newPost")]
        string newPost(string blogid, string username, string password, PostInfo post, Boolean publish);

        [XmlRpcMethod("mt.setPostCategories")]
        bool setPostCategories(string postid, string username, string password, MtCategory[] categories);
    }
}
