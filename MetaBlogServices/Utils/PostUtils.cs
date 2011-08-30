using BlogManager.ObjectModel;
using MetaBlog;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using BlogManager.Configuration;

namespace BlogManager.MetaBlogServices.Utils
{
    internal class PostUtils
    {
        private const string wholeTagPattern = @"<a[^<>]*?rel=""tag""[^<>]*?>.*?<\/a>";
        private const string tagPattern = @"<.*?>";

        internal static Post BuildPost(PostInfo postInfo, IDictionary<string, Category> categories)
        {
            Post res = new Post();
            res.DateCreated = postInfo.dateCreated;
            res.Text = postInfo.description;
            res.PlainText = clearTags(res.Text);
            res.Id = postInfo.postid;
            res.Title = postInfo.title;

            res.Tags.AddRange(extractTags(res.Text));

            if (postInfo.categories != null)
            {
                foreach (string category in postInfo.categories)
                {
                    if (categories.ContainsKey(category))
                    {
                        res.Categories.Add(categories[category]);
                    }
                }
            }

            return res;
        }

        internal static PostInfo BuildPostInfo(Post post)
        {
            PostInfo res = new PostInfo();
            res.dateCreated = post.DateCreated;
            res.description = post.Text;
            res.postid = post.Id;
            res.title = post.Title;
            
            return res;
        }

        private static string clearTags(string text)
        {
            return Regex.Replace(text, tagPattern, string.Empty);
        }

        private static IEnumerable<string> extractTags(string text)
        {
            List<string> res = new List<string>();

            Regex wholeTagRegex = new Regex(wholeTagPattern);
            foreach (Match item in wholeTagRegex.Matches(text))
            {
                string tag = clearTags(item.Value);
                if (!string.IsNullOrEmpty(tag))
                    res.Add(tag);
            }

            return res;
        }

        internal static void UpdateTags(Post post)
        {
            string tags = buildTagLinks(post.Tags);
            string text = setTagsPlaceHolder(post.Text);

            post.Text = string.Format(text, tags);
        }

        private static string setTagsPlaceHolder(string postText)
        {
            Regex wholeTagRegex = new Regex(wholeTagPattern);

            MatchCollection matches = wholeTagRegex.Matches(postText);
            if (matches.Count == 0)
                return buildPlaceHolder(postText);
            else
            {
                Match firstMatch = matches[0];
                Match lastMatch = matches[matches.Count - 1];

                // sostituisco a tutti i match il placeholder {0}
                return postText.Substring(0, firstMatch.Index) + "{0}" +
                    postText.Substring(lastMatch.Index + lastMatch.Length);
            }
        }

        private static string buildPlaceHolder(string postText)
        {
            return postText +
                Settings.Default.TagsPlaceholder;
        }

        private static string buildTagLinks(List<string> tags)
        {
            StringBuilder res = new StringBuilder();

            bool first = true;
            foreach (var tag in tags)
            {
                if (!first)
                    res.Append(", ");

                res.AppendFormat("<a rel=\"tag\" href=\"http://technorati.com/tags/{1}\">{0}</a>",
                    tag, HttpUtility.UrlPathEncode(tag));
                first = false;
            }

            return res.ToString();
        }
    }
}
