using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace SharpBot
{
    class Program
    {
        DiscordSocketClient client;
        CommandHandler handler;


        static void Main(string[] args)
            => new Program().StartAsync().GetAwaiter().GetResult();

             public async Task StartAsync()
        {
            //
            string name = "Real Bruce Lee"; ;
            string botName = "BOT";      
            string message = Utilities.GetFormattedAlert("LoadInMsg", name, botName);
            Console.WriteLine(message);
            
            Console.WriteLine("BOT TOKEN: " + Config.bot.token);
            Console.WriteLine("BOT cmd_PREFIX: " + Config.bot.cmdPrefix);
            //
            Console.WriteLine();
            //
            if (Config.bot.token == "" || Config.bot.token == null) return;
            this.client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            this.client.Log += Log;
            await this.client.LoginAsync(TokenType.Bot, Config.bot.token);
            await this.client.StartAsync();
            this.handler = new CommandHandler();
            this.handler.InitializeAsync(this.client);
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
            return Task.CompletedTask;
        }
    }
}
