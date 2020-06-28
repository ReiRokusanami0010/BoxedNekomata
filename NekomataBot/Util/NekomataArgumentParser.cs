using System;

namespace NekomataBot.Util {
    public class NekomataArgumentParser {
        public static void Decomposition(string[] targetArgs) {
            try {
                for (int i = 0; i < targetArgs.Length; i++) {
                    switch (targetArgs[i]) {
                        case "--token":
                            Settings.Token = targetArgs[++i];
                            break;
                    }
                }
            } catch (IndexOutOfRangeException) {
                NekomataLogger.ClientTasks.PrintErr(
                    "Arguments is incorrect.");
            }
        }
    }
}