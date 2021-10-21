using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using NewWorldWars.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWorldWars
{
    class Bot
    {
        public List<string> AdminGuilds;
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public async Task RunAsync()
        {
            Client = new DiscordClient(DisConfig());

            Client.Ready += OnclientReady;

            Commands = Client.UseCommandsNext(ComConfig());

            Commands.RegisterCommands<ServerCommands>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task OnclientReady(DiscordClient dc,ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }



        private CommandsNextConfiguration ComConfig()
        {
            string file = File.ReadAllText("config.txt");
            var strings = file.Split('\n');
            CommandsNextConfiguration cc = new CommandsNextConfiguration()
            {
                EnableMentionPrefix = true,
                EnableDms = false,
                DmHelp = true,
            };
            foreach (var s in strings)
            {
                var line = s.Split(':');

                switch (line[0])
                {
                    case "Prefix":
                        cc.StringPrefixes = new string[] { line[1] };
                        Console.WriteLine(line[1]);
                        break;
                    default:
                        break;
                }
            }

            return cc;
        }

        private DiscordConfiguration DisConfig()
        {
            string file = File.ReadAllText("config.txt");
            var strings = file.Split('\n');
            DiscordConfiguration dc = new DiscordConfiguration()
            {
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };
            foreach (var s in strings)
            {
                var line = s.Split(':');

                switch (line[0])
                {
                    case "Token":
                        dc.Token = line[1];
                        break;
                    default:
                        break;
                }
            }
            return dc;
        }
    }
}
