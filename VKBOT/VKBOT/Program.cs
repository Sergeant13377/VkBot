using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VKBOT
{
    class Program
    {
        public static VkApi api = new VkApi();
        static void Main(string[] args)
        {
            Console.Write("Login: ");
            string login = Console.ReadLine();
            Console.Write("Password: ");
            var password = Security.ReadPassword();
            api.Authorize(new ApiAuthParams() { Login = login, Password = password, ApplicationId = 5578797, Settings = Settings.All });
            Console.WriteLine("Started.");
            api.Messages.Send(new MessagesSendParams() { UserId = 372575398, Message = "Bot#" + new Random().Next(0, 256) + "\n" + "I'm use your bot." }); //random pass
            MessageEventHandler eh = new MessageEventHandler(api);
            Console.WriteLine("Message write.");
            Thread.Sleep(3000);
            Environment.Exit(0);
            //while (true)
            //{
            //    try
            //    {
            //        Tuple<Message, bool> receivedMessage = eh.ReadMessage();
            //        if (!receivedMessage.Item2)
            //        {
            //            GetReply(receivedMessage.Item1.UserId.Value, false, receivedMessage.Item1);
            //        }
            //        else
            //        {
            //            GetReply(receivedMessage.Item1.ChatId.Value, true, receivedMessage.Item1);
            //        }
            //    }
            //    catch (Exception err)
            //    {
            //        Console.WriteLine("Main: " + err.Message);
            //        Console.WriteLine("Trying reboot :/");
            //        Thread.Sleep(800);
            //        api.Authorize(new ApiAuthParams() { Login = login, Password = password, ApplicationId = 5578797, Settings = Settings.All });
            //        Console.WriteLine("Rebooted?");
            //    }
            //}
        }
        //private static void GetReply(long id, bool isChat, Message message)
        //{
        //    string[] request = message.Body.Split(' ');
        //    string reply = "";
        //    List<string> _class = request[0].Split('.').ToList<string>();
        //    Console.WriteLine(id + ": " + message.Body);
        //    if (isChat)
        //    {
        //        api.Messages.Send(new MessagesSendParams() { ChatId = id, Message = "Bot#" + new Random().Next(0, 256) + ":\n " + reply });
        //    }
        //    else
        //    {
        //        api.Messages.Send(new MessagesSendParams() { UserId = id, Message = "Bot#" + new Random().Next(0, 256) + ":\n " + reply });
        //    }
        //}
    }

}
