using Discord;
using Discord.WebSocket;

namespace NekomataBot {
    public class Settings {
        private static readonly DiscordSocketConfig SocketConfig = new DiscordSocketConfig {
            MessageCacheSize = 100, LogLevel = LogSeverity.Verbose, AlwaysDownloadUsers = false,
        };
        
        public static readonly DiscordSocketClient Client = new DiscordSocketClient(SocketConfig);
        
        public static string Token { get; set; }
    }
}