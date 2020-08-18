using Microsoft.OpenApi.Models;

namespace MuseuApi.Models
{
    public class Info :OpenApiInfo
    {
        public string Version { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TermsOfService { get; set; }
        public string Contact { get; set; }
    }
}