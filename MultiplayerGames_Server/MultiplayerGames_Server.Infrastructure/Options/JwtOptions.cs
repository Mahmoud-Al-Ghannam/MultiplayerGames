using System;
using System.Collections.Generic;
using System.Text;

namespace MultiplayerGames_Server.Infrastructure.Options
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int LifeTimeMin { get; set; }
        public string Key { get; set; } = string.Empty;
    }
}
