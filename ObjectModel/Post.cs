using System;
using System.Collections.Generic;
using System.Text;

namespace BlogManager.ObjectModel
{
    [Serializable]
    public class Post
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime dateCreated;

        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private List<Category> categories = new List<Category>();

        public List<Category> Categories
        {
            get { return categories; }
        }

        public bool ContainsCategory(string id)
        {
            return (this.GetCategoryById(id) != null);
        }

        public Category GetCategoryById(string id)
        {
            foreach (var category in categories)
            {
                if (category.Id == id)
                    return category;
            }
            return null;
        }

        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private string plainText;
        public string PlainText
        {
            get { return plainText; }
            set { plainText = value; }
        }

        private List<string> tags = new List<string>();
        public List<string> Tags
        {
            get { return tags; }
        }
    }
}
