using System.Text.Json.Serialization;

namespace BloodBankManager.Application.Dto_s
{
    public class ZipCodeDto
    {
        [JsonPropertyName("cep")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("neighborhood")]
        public string? Location { get; set; }

        [JsonPropertyName("street")]
        public string? Street { get; set; }

        [JsonPropertyName("service")]
        [JsonIgnore]
        public string? Service { get; set; }
    }
}
