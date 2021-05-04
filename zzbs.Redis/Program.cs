using Newtonsoft.Json;
using ServiceStack.Redis;
using System;
using System.Configuration;

namespace zzbs.Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Redis Basic Operations!");

            var redisHost = ConfigurationManager.AppSettings.Get("redis");
            var port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("port").ToString());

            //StringTests.Run(redisHost, port);

            //HashTests.Run(redisHost, port);

            //ListTests.Run(redisHost, port);

            //SetAndZsetTests.Run(redisHost, port);

            //LuaTests.Run(redisHost, port);

            TransactionTests.Run(redisHost, port);

            Console.Read();
        }
    }
}
