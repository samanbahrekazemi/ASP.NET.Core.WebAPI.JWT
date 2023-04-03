using Infrastructure.Interfaces;

namespace Presentation.Models
{
    public class WebApiConfig : IWebApiConfig
    {
        public string BaseUrl { get; set; }
    }
}
