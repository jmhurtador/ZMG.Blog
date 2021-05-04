using System.Diagnostics.CodeAnalysis;

namespace ZMG.Blog.Core.Models.Configurations
{
    [ExcludeFromCodeCoverage]
    public class JwtConfiguration
    {
        /// <summary>
        /// Gets or sets the JWT Secret
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets the JWT Issuer
        /// </summary>
        public string Issuer { get; set; }
    }
}
