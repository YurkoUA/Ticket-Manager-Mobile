using System;
using Newtonsoft.Json;

namespace TicketApi.Models
{
    public class AccessToken
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }

        [JsonProperty("expires_in")]
        public int SecondsToExpire { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime ExpireTime => CreationTime.AddSeconds(SecondsToExpire);

        public bool IsActive => DateTime.Now < ExpireTime;

        public override string ToString() => Token;
    }
}
