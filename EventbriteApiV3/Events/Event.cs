using EventbriteApiV3.Model;
using Newtonsoft.Json;

namespace EventbriteApiV3.Events
{
    public class Event
    {
        [JsonProperty("name")]
        public TextHtmlString Name { get; set; }

        [JsonProperty("description")]
        public TextHtmlString Description { get; set; }

        [JsonProperty("long_description")]
        public TextHtmlString LongDescription { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("start")]
        public MultipartDate Start { get; set; }

        [JsonProperty("end")]
        public MultipartDate End { get; set; }

        [JsonProperty("is_free")]
        public string IsFree { get; set; }

        /* "logo": {
                "crop_mask": {
                    "top_left": {
                        "x": 0,
                        "y": 0
                    },
                    "width": 2160,
                    "height": 1080
                },
                "original": {
                    "url": "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F116084511%2F211848954240%2F1%2Foriginal.20201028-102816?auto=format%2Ccompress&q=75&sharp=10&s=7301201eefad3670b3128dfad2ecd15a",
                    "width": 2160,
                    "height": 1080
                },
                "id": "116084511",
                "url": "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F116084511%2F211848954240%2F1%2Foriginal.20201028-102816?h=200&w=450&auto=format%2Ccompress&q=75&sharp=10&rect=0%2C0%2C2160%2C1080&s=38a11a9cbaa830b6e933fbf5331ddedb",
                "aspect_ratio": "2",
                "edge_color": "#aeb4ab",
                "edge_color_set": true
            }*/
        [JsonProperty("logo")]
        public Logo Logo { get; set; }
    }
}