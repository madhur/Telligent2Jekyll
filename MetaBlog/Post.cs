using System;
using CookComputing.XmlRpc;

namespace MetaBlog
{
    public struct PostInfo
    {
        /// <summary>
        /// Required when posting.
        /// </summary>
        public DateTime dateCreated;
        /// <summary>
        /// Required when posting.
        /// </summary>
        public string description;
        /// <summary>
        /// Required when posting.
        /// </summary>
        public string title;
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string[] categories;
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public Enclosure enclosure;
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string link;
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string permalink;
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string postid;
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public Source source;
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string userid;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Post"/> class.
        /// </summary>
        /// <param name="dateCreated">The date created.</param>
        /// <param name="description">The description.</param>
        /// <param name="title">The title.</param>
        /// <param name="categories">The categories.</param>
        /// <param name="enclosure">The enclosure.</param>
        /// <param name="link">The link.</param>
        /// <param name="permalink">The permalink.</param>
        /// <param name="postid">The postid.</param>
        /// <param name="source">The source.</param>
        /// <param name="userid">The userid.</param>
        public PostInfo(DateTime dateCreated, string description, string title,
            string[] categories, Enclosure enclosure, string link,
            string permalink, string postid, Source source, string userid)
        {
            this.dateCreated = dateCreated;
            this.description = description;
            this.title = title;
            this.categories = categories;
            this.enclosure = enclosure;
            this.link = link;
            this.permalink = permalink;
            this.postid = postid;
            this.source = source;
            this.userid = userid;
        }
    }
}
