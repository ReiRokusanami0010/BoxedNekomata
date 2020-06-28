using System;
using System.Threading.Tasks;
using NekomataBot.Util;

namespace NekomataBot {
    public class MainService {
        public static void Main(string[] args) {
            new MainService().AsyncService(args).GetAwaiter().GetResult();
        }

        [STAThread]
        private async Task AsyncService(string[] args) {
            NekomataArgumentParser.Decomposition(args);
            
            Settings.Client.Log += NekomataLogger.ClientTasks.LogAsync;
            await Task.Delay(-1);
        }
    }
}