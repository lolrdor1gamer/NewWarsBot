using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWorldWars.Commands
{
    class ServerCommands : BaseCommandModule
    {

        [Command("rmw")]
        [Description("Registrating guild to list")]
        public async Task RegistrateGuild(CommandContext ctx)
        {
            if (ctx.Member.Permissions.GetHashCode() >> 3 == -8)
            {
                await ctx.Channel.SendMessageAsync(File.ReadAllText("roles.txt")).ConfigureAwait(false);
                ///DiscordRole role = new DiscordRole();
                //ctx.Message.Content.Contains();
            }
            else
            {
                await ctx.Channel.SendMessageAsync("You haven't got rules").ConfigureAwait(false);
            }
        }

        [Command("rmw")]
        [Description("Registrating guild to list")]
        public async Task RegistrateGuild(CommandContext ctx, DiscordRole dr)
        {
            if (ctx.Member.Permissions.GetHashCode() >> 3 == -8)
            {
                File.WriteAllText("roles.txt", File.ReadAllText("roles.txt") + $"{dr.Id}:");
                await ctx.Channel.SendMessageAsync("+").ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("You haven't got rules").ConfigureAwait(false);
            }
        }
        [Command("war")]
        [Description("Registrating new war")]
        public async Task RegistrateGuild(CommandContext ctx, string location)
        {
            if(CheckRoles(ctx.Member))
            {
                File.Create($"{location}.txt");
            }
            else 
            {
                await ctx.Channel.SendMessageAsync("You haven't got rules").ConfigureAwait(false);
            }
        }


        bool CheckRoles(DiscordMember dm)
        {
            foreach (var r in dm.Roles)
            {
                if (File.ReadAllText("roles.txt").Contains(r.Id.ToString()))
                    return true;
            }
            return false;
        }

        async string JsonSettings()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("warconfig.json"))
                using(var sr = new StreamReader(fs, new UTF8Encoding(false)))
            {
                json = await sr.ReadToEndAsync().ConfigureAwait(false);
            }

            var warConfigJson = JsonConvert.DeserializeObject<WarConfigJson>(json);
        }
    }
        
}
