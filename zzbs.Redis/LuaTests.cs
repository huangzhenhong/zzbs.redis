using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace zzbs.Redis
{
    public class LuaTests
    {
        public static void Run(string host, int port)
        {
            using (RedisClient client = new RedisClient(host, port))
            {
                Console.WriteLine("Redis connected!");

                //删除当前数据库中的所有Key  默认删除的是select 0
                client.FlushDb();
                //删除所有数据库中的key 
                client.FlushAll();

                client.ExecLuaAsString(@"redis.call('set', 'name', 'daniel')");
                Console.WriteLine(client.ExecLuaAsString(@"return redis.call('get', 'name')"));

                var lua = @"local count = redis.call('get',KEYS[1])
				                        if(tonumber(count)>=0)
				                        then
				                            redis.call('INCR',ARGV[1])
				                            return redis.call('DECR',KEYS[1])
				                        else
				                            return -1
				                        end";

                Console.WriteLine(client.ExecLuaAsString(lua, keys: new[] { "number" }, args: new[] { "ordercount" }));

            }
        }
    }
}
