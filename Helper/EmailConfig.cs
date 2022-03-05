using System.Text.Json.Serialization;

namespace Library.Helper;

public class EmailConfig
{
    [JsonPropertyName("email")] public string Email { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("password")] public string Password { get; set; }
    [JsonPropertyName("host")] public string Host { get; set; }
    [JsonPropertyName("port")] public int Port { get; set; }
}