using System;
using VkNet;
using VkNet.Enums.Filters;

namespace VKBOT
{
    class Program
    {
        public static VkApi api = new VkApi();
        private readonly static string login = "380932144377";
        static void Main(string[] args)
        {
            Console.WriteLine("TEST");
            var password = Security.ReadPassword();
            api.Authorize(new ApiAuthParams() { Login = login, Password = password, ApplicationId = 5578797, Settings = Settings.All });
            Console.WriteLine("Started.");
        }
    }
}
