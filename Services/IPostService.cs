using System;
using System.Collections.Generic;
using System.Text;
using BlogManager.ObjectModel;

namespace BlogManager.Services
{
    public interface IPostService
    {
        IList<Post> GetPosts(int numberOfPosts);
        void ChangeCategories(Post post);
        void ChangeTags(Post post);
        void Backup(int numberOfPosts, string targetFileName);
        void Backup(IList<Post> posts, string targetFileName);
        IList<Post> Restore(string sourceFileName);
        void Update(Post post);
        void BatchUpdate(IList<Post> posts);
    }
}
