using CookComputing.XmlRpc;

namespace MetaBlog
{
    public struct Enclosure
    {
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public int length;
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string type;
        /// <summary>
        /// Optional
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string url;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Enclosure"/> class.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="type">The type.</param>
        /// <param name="url">The URL.</param>
        public Enclosure(int length, string type, string url)
        {
            this.length = length;
            this.type = type;
            this.url = url;
        }
    }
}
