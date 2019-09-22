using Newtonsoft.Json;

namespace EventbriteApiV3.Model
{
    public abstract class BaseApiResponse
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}
