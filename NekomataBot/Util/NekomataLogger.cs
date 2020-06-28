using System.Threading.Tasks;
using Discord;
using Log5RLibs.Services;

namespace NekomataBot.Util {
    public class NekomataLogger {
        private static readonly string InfoMsg     =   $"{"Information",-16}";
        private static readonly string CautMsg     =       $"{"Caution",-16}";
        private static readonly string WarnMsg     =       $"{"Warning",-16}";
        private static readonly string ErrMsg      =         $"{"Error",-16}";
        private static readonly string CritMsg     =      $"{"Critical",-16}";
        private static readonly string DebugMsg    =       $"{"Verbose",-16}";
        private static readonly string ClientMsg   =        $"{"Client",-16}";
        private static readonly string DataBaseMsg =      $"{"DataBase",-16}";
        
        private static class ClientSide {
            public static readonly AlCConfigScheme Information = new AlCConfigScheme(0, InfoMsg, ClientMsg);
            public static readonly AlCConfigScheme Caution     = new AlCConfigScheme(1, CautMsg, ClientMsg);
            public static readonly AlCConfigScheme Warning     = new AlCConfigScheme(2, WarnMsg, ClientMsg);
            public static readonly AlCConfigScheme Error       = new AlCConfigScheme(3,  ErrMsg, ClientMsg);
            public static readonly AlCConfigScheme Critical    = new AlCConfigScheme(2, CritMsg, ClientMsg);
            public static readonly AlCConfigScheme Verbose     = new AlCConfigScheme(2,DebugMsg, ClientMsg);
        }
        private static class ServerSide {
            public static readonly AlCConfigScheme Information = new AlCConfigScheme(0, InfoMsg, DataBaseMsg);
            public static readonly AlCConfigScheme Caution     = new AlCConfigScheme(1, CautMsg, DataBaseMsg);
            public static readonly AlCConfigScheme Warning     = new AlCConfigScheme(2, WarnMsg, DataBaseMsg);
            public static readonly AlCConfigScheme Error       = new AlCConfigScheme(3,  ErrMsg, DataBaseMsg);
        }
        
        public class ClientTasks {
            public static void PrintInfo(string msg) {
                AlConsole.WriteLine(ClientSide.Information, msg);
            }

            public static void PrintCaut(string msg) {
                AlConsole.WriteLine(ClientSide.Caution, msg);
            }

            public static void PrintWarn(string msg) {
                AlConsole.WriteLine(ClientSide.Warning, msg);
            }

            public static void PrintErr(string msg) {
                AlConsole.WriteLine(ClientSide.Error, msg);
            }

            public static void PrintCrit(string msg) {
                AlConsole.WriteLine(ClientSide.Critical, msg);
            }

            public static void PrintDebug(string msg) {
                AlConsole.WriteLine(ClientSide.Verbose, msg);
            }

            public static Task LogAsync(LogMessage message) {
                LevelSwitcher(message);
                return Task.CompletedTask;
            } 

            private static void LevelSwitcher(LogMessage level) {
                switch (level.Severity) {
                    default:
                        PrintInfo(level.Message);
                        break;
                    
                    case LogSeverity.Critical:
                        PrintCrit(level.Message);
                        break;
                    
                    case LogSeverity.Warning:
                        PrintWarn(level.Message);
                        break;
                    
                    case LogSeverity.Error:
                        PrintErr(level.Message);
                        break;
                    
                    case LogSeverity.Debug:
                    case LogSeverity.Verbose:
                        PrintDebug(level.Message);
                        break;
                }
                
            }
            
        }
        
        public class ServerTasks {
            public static void PrintInfo(string msg) {
                AlConsole.WriteLine(ServerSide.Information, msg);
            }

            public static void PrintCaut(string msg) {
                AlConsole.WriteLine(ServerSide.Caution, msg);
            }

            public static void PrintWarn(string msg) {
                AlConsole.WriteLine(ServerSide.Warning, msg);
            }

            public static void PrintErr(string msg) {
                AlConsole.WriteLine(ServerSide.Error, msg);
            }
            
        }
        
    }
    
}