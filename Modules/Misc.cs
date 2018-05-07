using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading;
using System.Net.Mail;






namespace SharpBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {


         [Command("email")]
        public async Task EmailCommand(string message1 , string message2,[Remainder] string message3)
        {
            string emailUser = "realbruceleebot@gmail.com";
            string passUser = "hyunseol11";


            string serverType = "gmail";
            
            try{

            
            SmtpClient SmtpServer = new SmtpClient("smtp." + serverType + ".com");
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(emailUser, passUser);
                    SmtpServer.EnableSsl = true;

                    MailMessage mail = new MailMessage();   
                    mail.From = new MailAddress(emailUser);    
                    mail.To.Add(message1);
         
                    var subjectSend = Context.Message.Content;
                    
                    if(message2 != null && (message3 != null))
                    {
                    
                    mail.Subject = message2;

                    var messageSend = Context.Message.Content;
                                        
                    mail.Body = message3;
                    SmtpServer.Send(mail);

                    await Context.Channel.SendMessageAsync("```" +"\nEmail From: " + emailUser + "\nEmail Sent to: " + message1 + 
                        "\nSubject: " + message2 + "\nMessage: " + message3  + "```");
                                        
                    }else{
                    await Context.Channel.SendMessageAsync("Please Try Again");
                    return;
                    }

                }catch (Exception ex)
            {
                await Context.Channel.SendMessageAsync("Please enter a VALID email address");
                
            }


        }
        

        //////////////////////////////////
        [Command("shutdown")]
        public async Task CloseBot()
        {
            var tomgxID = (Context.Guild.GetUser(225756974602649600));
            if(Context.User == tomgxID){

            var embed = new EmbedBuilder();
            embed.WithTitle("Shutdown");    
            embed.WithColor(new Color(255, 0, 0));
            embed.WithDescription("```BOT offline```");
            await Context.Channel.SendMessageAsync("", false, embed);
              
                Environment.Exit(0);

            }else{
            var embed = new EmbedBuilder();
            embed.WithTitle("Shutdown");    
            embed.WithColor(new Color(255, 0, 0));
            embed.WithDescription("```Insufficient Permissions```");
            await Context.Channel.SendMessageAsync("", false, embed);
            }


            }

        ///////////////////////////////

      public int convertToMill;
        //////////////////////
        public IGuildUser userG;
         
        //////////////////////
        [Command("timeout")]
        public async Task TimeOut(string message, IGuildUser userG)
        {

           //daniel id
            var me = (Context.Guild.GetUser(200699282989383682));
            //wetdog id
            var me2 = (Context.Guild.GetUser(288880391925006336));
            //ben id
            var me3 = (Context.Guild.GetUser(224959604570849280));

            if(Context.User == me || (Context.User == me2 || (Context.User == me3))) {
              await Context.Channel.SendMessageAsync(Context.User.Mention+" no no no. No perms for you");
                return;
            }


            if(message.Equals("end")){
                 // var user = Context.User;
            //var getSocketUser = (Context.Guild.GetUser(226052407711236096));
            var addRole = Context.Guild.Roles.FirstOrDefault(x => x.Name == "timeout");
            //var getRole1 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "test1");
            //var getRole2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "test2");
            var getRole1 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "the boyz");
            var getRole2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Round");

            await (userG).AddRoleAsync(getRole1);
            await (userG).AddRoleAsync(getRole2);
            await (userG).RemoveRoleAsync(addRole);

            var embed = new EmbedBuilder();
            embed.WithTitle("Timeout Cancelled");    
            embed.WithColor(new Color(255, 255, 0));
            embed.WithDescription("Timeout has been canceled");
            await Context.Channel.SendMessageAsync("", false, embed);
               return;
        }
   
       

            string numTime1 = ("1");
            string numTime2 = ("2");
            string numTime3 = ("3");
            string numTime4 = ("4");
            string numTime5 = ("5");

        
            if(message == numTime1 || (message == numTime2) || (message == numTime3)
                || (message == numTime4) || (message == numTime5))
            {
               
              
           
            var addRole = Context.Guild.Roles.FirstOrDefault(x => x.Name == "timeout");
             if (addRole == null){
                Console.WriteLine("Role: 'timeout' Not Found");
                await Context.Channel.SendMessageAsync("```Role: 'timeout' Not Found```");

         } 
                
            var getRole1 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "the boyz");
            var getRole2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Round");
           
          

            await(userG).AddRoleAsync(addRole);
            await(userG).RemoveRoleAsync(getRole1);
            await(userG).RemoveRoleAsync(getRole2);
                   
            
          int messageToInt = Int32.Parse(message);
            
          convertToMill = messageToInt * 60000;

            var embed = new EmbedBuilder();
            embed.WithTitle("Timeout");    
            embed.WithColor(new Color(112, 239, 159));
            embed.WithDescription("Timeout Duration: " + message + " minute(s)");
            await Context.Channel.SendMessageAsync("", false, embed);

            await Task.Delay(convertToMill);
            

            await (userG).AddRoleAsync(getRole1);
            await (userG).AddRoleAsync(getRole2);
            await (userG).RemoveRoleAsync(addRole);

            
            embed.WithTitle("Timeout");    
            embed.WithColor(new Color(112, 239, 159));
            embed.WithDescription("Timeout has ended");
            await Context.Channel.SendMessageAsync("", false, embed);
            
           // EndTimeOut();

            

            }else{
                
            var embed = new EmbedBuilder();
            embed.WithTitle("Timeout");    
            embed.WithColor(new Color(255, 0, 0));
            embed.WithDescription("Choose from 1 to 5 minutes");
            await Context.Channel.SendMessageAsync("", false, embed);
            
          }
        
        }

        //////////////////////////////

         
          //public async Task EndTimeOut()
        //{
         //   await Task.Delay(convertToMill);
            
        //    var addRole = Context.Guild.Roles.FirstOrDefault(x => x.Name == "timeout");

        //    var getRole1 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "the boyz");
         //   var getRole2 = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Round");

           // await (userG).AddRoleAsync(getRole1);
           // await (userG).AddRoleAsync(getRole2);
         //   await (userG).RemoveRoleAsync(addRole);
        
          //  var embed = new EmbedBuilder();
          //  embed.WithTitle("Timeout");    
          //  embed.WithColor(new Color(112, 239, 159));
           // embed.WithDescription("Timeout has ended");
           // await Context.Channel.SendMessageAsync("", false, embed);
            
       // }
      

        //////////////////////////

        ////////////////////

        /////////////////
       /* [Command("echo")]
        public async Task Echo([Remainder]string message)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Echo");
            embed.WithDescription(message);
            embed.WithColor(new Color(242, 189, 219));

            await Context.Channel.SendMessageAsync("", false, embed);

        }*/

        /////////////////
        
   

            
        /////////////////
        [Command("choose")]
        public async Task ChooseOne([Remainder]string message)
        {
           

            string[] options = message.Split(new string[] { "or" }, StringSplitOptions.RemoveEmptyEntries);


            Random r = new Random();
            string selection = options[r.Next(0, options.Length)];

            var embed = new EmbedBuilder();
            embed.WithTitle(Context.User.Username + " I have Chosen");
            embed.WithDescription(selection);
            embed.WithColor(new Color(222, 129, 239));
            embed.WithThumbnailUrl("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSbNzxTrMckbC_vNKHbJIBtLbFA5VRpN56MR2_vSF1z2gAPX6D0bw");

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        /////////////////

        /////////////////
        [Command("help")]
        public async Task Commands()
        {

            string commands = (Utilities.GetAlert("commandsHelp"));
            var embed = new EmbedBuilder();
            embed.WithTitle("Commands");
            embed.WithDescription(commands);
            embed.WithColor(new Color(242, 189, 219));

            await Context.Channel.SendMessageAsync("", false, embed);
        }
        /////////////////

           

        /////////////////
      [Command("delete", RunMode = RunMode.Async)]
        public async Task Stop(int amount)
        {
            


             if(Context.User.Id ==  200699282989383682)
        await ReplyAsync("No Permissions!");

                else{

                    //SocketUser target = null;
                   // var mentionedUser = Context.Message.MentionedUsers.FirstOrDefault();
                    //target = mentionedUser ?? Context.User;
                    //var account = UserAccounts.GetAccount(target);

                    var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten();

                    await Context.Channel.DeleteMessagesAsync(messages);

                    var embed = new EmbedBuilder();
                    string amountToString = amount.ToString();
                     embed.WithTitle("Deleted Messages");
                     embed.WithDescription(amountToString);
                     embed.WithColor(new Color(242, 189, 219));

                    await Context.Channel.SendMessageAsync("", false, embed);
}
                 

               
           

        }
        /* 
            [Command("signon")]
        public async Task Bet()
        {

            if (Context.User.Id == 225756974602649600)
            {
                int workCount = 0;
                 var timer = new System.Timers.Timer(1800000); 
                timer.AutoReset = true;

                 timer.Elapsed += (src, e) =>
                 {
                  Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));

                      if(++workCount == 48)
                      {
                        timer.Stop();
                   }
                      };

    timer.Start();

              
              //  var t = new Timer(x => Bet(), null, 0, 1500);

            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithTitle("Permissions");
                embed.WithDescription("Insufficient Permissions");
                embed.WithColor(new Color(255, 0, 0));
                await Context.Channel.SendMessageAsync("", false);
            }

            async void Bet()
            {
                await Context.Channel.SendMessageAsync(".signon", false);

            }
        }
   
        */ 
         
}

        

       
}
    
      
   // 


        /////////////////

   


//}
