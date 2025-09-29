using System.Text.Json.Serialization;

namespace RentospectWebApp.DTOs
{
    public record AuthResponseDto(LoggedInUser user, string? ErrorMessage = null)
    {
        [JsonIgnore]
        public bool HasError => ErrorMessage != null;
    }
}
