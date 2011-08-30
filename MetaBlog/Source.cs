using CookComputing.XmlRpc;

namespace MetaBlog
{
    public struct Source
    {
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string name;
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string url;
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string type;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Source"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="url">The URL.</param>
        public Source(string name, string url)
        {
            this.name = name;
            this.url = url;
            this.type = "";
        }
    }
}
