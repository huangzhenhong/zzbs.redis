using System;

namespace zzbs.StackExchange.Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RedisHelper redis = new RedisHelper("127.0.0.1:6379");
            redis.StringSet("yyy", "666");
            Console.WriteLine(redis.StringGet("yyy"));

            Console.ReadLine();
        }
    }
}
