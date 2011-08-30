using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using BlogManager.MetaBlogServices.Utils;
using BlogManager.ObjectModel;
using BlogManager.Services;
using CookComputing.XmlRpc;
using MetaBlog;


namespace BlogManager.MetaBlogServices
{
    public class PostService: ServiceBase, IPostService
    {
        public IList<Post> GetPosts(int numberOfPosts)
        {
            try
            {
                ICategoryService categoryService = ServiceRepository.Factory.GetCategoryService();
                IDictionary<string, Category> categories = categoryService.GetCategoryDictionary();

                IBlogger blogger = this.GetBlogger();
                PostInfo[] posts = blogger.getRecentPosts(this.BlogId, this.Username, this.Password, numberOfPosts);

                List<Post> res = new List<Post>();
                foreach (var postInfo in posts)
                {
                    res.Add(PostUtils.BuildPost(postInfo, categories));
                }

                return res;
            }
            catch (XmlRpcFaultException ex)
            {
                throw new ConnectionException(ex);
            }
        }

        public void Update(Post post)
        {
            try
            {
                IBlogger blogger = this.GetBlogger();

                blogger.editPost(post.Id, this.Username, this.Password,
                    PostUtils.BuildPostInfo(post), true);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new ConnectionException(ex);
            }
        }

        public void ChangeCategories(Post post)
        {
            try
            {
                IBlogger blogger = this.GetBlogger();

                MtCategory[] categories = CategoryUtils.GetCategoryInfos(post.Categories);
                blogger.setPostCategories(post.Id, this.Username, this.Password, categories);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new ConnectionException(ex);
            }
        }

        public void ChangeTags(Post post)
        {
            PostUtils.UpdateTags(post);

            Update(post);
        }

        public void Backup(IList<Post> posts, string targetFileName)
        {
            XmlSerializer serializer = new XmlSerializer(posts.GetType());

            using (FileStream fileStream = new FileStream(targetFileName, FileMode.Create))
            {
                serializer.Serialize(fileStream, posts);
            }
        }

        public IList<Post> Restore(string sourceFileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Post>));

            List<Post> posts = null;
            using (FileStream fileStream = new FileStream(sourceFileName, FileMode.Open))
            {
               posts = serializer.Deserialize(fileStream) as List<Post>;
            }

            return posts;
        }

        public void BatchUpdate(IList<Post> posts)
        {
            if (posts != null)
            {
                foreach (var post in posts)
                {
                    this.Update(post);
                    this.ChangeCategories(post);
                }
            }
        }

        public void Backup(int numberOfPosts, string targetFileName)
        {
            IList<Post> posts = this.GetPosts(numberOfPosts);
            this.Backup(posts, targetFileName);
        }
    }
}
