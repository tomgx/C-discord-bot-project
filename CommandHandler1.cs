using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace SharpBot
{
    class CommandHandler
    {

        DiscordSocketClient client;
        CommandService service;

        public async Task InitializeAsync(DiscordSocketClient client)
        {

            this.client = client;
            this.service = new CommandService();
            await this.service.AddModulesAsync(Assembly.GetEntryAssembly());
            this.client.MessageReceived += HandleCommandAsync;

        }

        private async Task HandleCommandAsync(SocketMessage s)
        {

            var msg = s as SocketUserMessage;
            if (msg == null) return;
            var context = new SocketCommandContext(this.client, msg);
            int argPos = 0;

            if(msg.HasStringPrefix(Config.bot.cmdPrefix, ref argPos)
                || msg.HasMentionPrefix(this.client.CurrentUser, ref argPos))       
            {

                var result = await this.service.ExecuteAsync(context, argPos);
                if(!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                }

            }

        

           


        }
    }
}
