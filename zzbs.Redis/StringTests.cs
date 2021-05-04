using Newtonsoft.Json;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace zzbs.Redis
{
    //统计网站访问数量、当前在线人数、微博数、粉丝数等，全局递增ID等
    public class StringTests
    {
        public static void Run(string host, int port) {

            using (RedisClient client = new RedisClient(host, port))
            {
                Console.WriteLine("Redis connected!");

                //删除当前数据库中的所有Key  默认删除的是select 0
                client.FlushDb();
                //删除所有数据库中的key 
                client.FlushAll();

                #region 设置单个string类型数据

                //client.Set<string>("name", "daniel huang");
                //Console.WriteLine("错误输出");
                //Console.WriteLine(client.GetValue("name"));
                //Console.WriteLine("正确输出");
                //// 代码的底层，也是做了反序列化，只是我们看不到 
                //Console.WriteLine(client.Get<string>("name"));
                //Console.WriteLine(JsonConvert.DeserializeObject<string>(client.GetValue("name")));

                #endregion

                #region 批量操作

                ////批量的写入redis key
                //client.SetAll(new Dictionary<string, string> { { "id", "001" }, { "name", "daniel" }, { "age", "30" } });
                ////批量读取内存中多个key的结果 如果我们获取的key不存在，程序会返回一个空的字符串
                //var keyValues = client.GetAll<string>(new string[] { "id", "name", "age", "number" });
                //foreach (var item in keyValues)
                //{
                //    Console.WriteLine(item);
                //}

                #endregion

                #region  设置key的value并设置过期时间

                //client.Set<string>("name", "daniel", TimeSpan.FromSeconds(1));
                //Console.Write("当前name的值： ");
                //Console.WriteLine(client.Get<string>("name"));
                //Console.Write("1秒之后name的值： ");
                //Task.Delay(1 * 1000).Wait();
                //Console.WriteLine("name: " + client.Get<string>("name"));

                #endregion

                #region 获取旧值赋上新值

                //client.Set("name", "daniel");
                ////获取当前key的之前的值，然后把新的结果替换进入
                //var value = client.GetAndSetValue("name", "dragon warrior");
                //Console.WriteLine("原先的值" + value);
                //Console.WriteLine("新值" + client.GetValue("name"));

                #endregion

                #region 自增1，返回自增后的值

                ////给key为sid的键自增1 ，返回了自增之后的结果
                //Console.WriteLine("自增： " + client.Incr("number"));
                //Console.WriteLine("自增： " + client.Incr("number"));
                //Console.WriteLine("自增： " + client.Incr("number"));
                //Console.WriteLine("打印结果： " + client.GetValue("number"));

                ////每次通过传递的count累计，count就是累加的值
                //client.IncrBy("sid", 2);
                //Console.WriteLine(client.Get<string>("sid"));
                //client.IncrBy("sid", 100);
                //Console.WriteLine("最后的结果***" + client.GetValue("sid"));

                #endregion

                #region 自减1，返回自减后的值

                //client.SetValue("sid", "100");
                //Console.WriteLine("自减1： " + client.Decr("sid"));
                //Console.WriteLine("自减1： " + client.Decr("sid"));
                //Console.WriteLine("自减1： " + client.Decr("sid"));
                //Console.WriteLine("最后的结果" + client.GetValue("sid"));
                ////通过传入的count去做减肥 之前的结果-count
                //Console.WriteLine("自减2： " + client.DecrBy("sid", 2));
                //Console.WriteLine("最终的结果" + client.GetValue("sid"));

                #endregion

                #region add 和set 的区别？

                // add 只能做新增，如果已经有了key则返回失败
                // set 如果有key就替换，如果没有就写入
                // 当使用add 方法去操作redis的时候，如果key存在的话，则不会再次进行操作 返回false 如果操作成功返回true
                Console.WriteLine(client.Add("name", "daniel"));
                //用add的时候帮你去判断如果有则不进行操作，如果没有则写，它只能写新值，不能修改
                Console.WriteLine(client.Add("name", "dragon warrior"));
                Console.WriteLine(client.Get<string>("name"));

                //使用set去操作 redis的时候，如果key不存在则写入当前值，并且返回true，通过存在，则对之前的值进行了一个替换 返回操作的结果
                Console.WriteLine(client.Set("name", "daniel"));
                Console.WriteLine(client.Set("name", "dragon warrior"));
                Console.WriteLine(client.Get<string>("name"));
                #endregion
            }
        }
    }
}
