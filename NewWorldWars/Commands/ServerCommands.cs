using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using NewWorldWars.DAL;
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
        private readonly BotContext _context;

        public ServerCommands(BotContext context)
        {
            _context = context;
        }

        #region GuildRegistrate
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
        #endregion
        #region WarRegistrating
        [Command("war")]
        [Description("Registrating new war")]
        public async Task RegistrateGuild(CommandContext ctx, string location)
        {
            if(CheckRoles(ctx.Member))
            {
                await _context.WarEvents.AddAsync(new WarEvent
                {
                    Location = location,
                    Date = DateTime.Today.AddHours(20),
                    RequiredLevel = 0
                }).ConfigureAwait(false);
            }
            else 
            {
                await ctx.Channel.SendMessageAsync("You haven't got rules").ConfigureAwait(false);
            }
        }

        [Command("war")]
        [Description("Registrating new war")]
        public async Task RegistrateGuild(CommandContext ctx, DateTime time)
        {
            if (CheckRoles(ctx.Member))
            { 
                await _context.WarEvents.AddAsync(new WarEvent
                {
                    Location = "No Data",
                    Date = time,
                    RequiredLevel = 0
                }).ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("You haven't got rules").ConfigureAwait(false);
            }
        }

        [Command("war")]
        [Description("Registrating new war")]
        public async Task RegistrateGuild(CommandContext ctx, string location, DateTime time)
        {
            if (CheckRoles(ctx.Member))
            {
                await _context.WarEvents.AddAsync(new WarEvent
                {
                    Location = location,
                    Date = time,
                    RequiredLevel = 0
                }).ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("You haven't got rules").ConfigureAwait(false);
            }
        }
        public async Task RegistrateGuild(CommandContext ctx, string location, DateTime time, byte req_level)
        {
            if (CheckRoles(ctx.Member))
            {
                await _context.WarEvents.AddAsync(new WarEvent
                {
                    Location = location,
                    Date = time,
                    RequiredLevel = req_level
                }).ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("You haven't got rules").ConfigureAwait(false);
            }
        }

        #endregion

        bool CheckRoles(DiscordMember dm)
        {
            foreach (var r in dm.Roles)
            {
                if (File.ReadAllText("roles.txt").Contains(r.Id.ToString()))
                    return true;
            }
            return false;
        }
        /*
        async string JsonSettings()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("warconfig.json"))
                using(var sr = new StreamReader(fs, new UTF8Encoding(false)))
            {
                json = await sr.ReadToEndAsync().ConfigureAwait(false);
            }

            var warConfigJson = JsonConvert.DeserializeObject<WarConfigJson>(json);
        }*/
    }
        
}
