using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zzbs.Redis
{
    public class HashTests
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

                string hashid = "user1";

                #region  向hashid集合中添加key/value

                client.SetEntryInHash(hashid, "id", "001");
                Console.WriteLine(client.GetValuesFromHash(hashid, "id").FirstOrDefault());
                client.SetEntryInHash(hashid, "name", "daniel");
                Console.WriteLine(client.GetValuesFromHash(hashid, "name").FirstOrDefault());
                client.SetEntryInHash(hashid, "socre", "100");
                Console.WriteLine(client.GetValuesFromHash(hashid, "socre").FirstOrDefault());

                #endregion

                #region 批量新增key的值

                //Dictionary<string, string> pairs = new Dictionary<string, string>();
                //pairs.Add("id", "001");
                //pairs.Add("name", "daniel");
                //client.SetRangeInHash(hashid, pairs);
                ////获取当前key的值
                //Console.WriteLine(client.GetValueFromHash(hashid, "id"));
                //Console.WriteLine(client.GetValueFromHash(hashid, "name"));

                ////一次性的获取所有想要获取的小key（属性的）值  如果key不存在，则返回空，不抛出异常
                //var list = client.GetValuesFromHash(hashid, "id", "name", "abc");
                //Console.WriteLine("***************************************");
                //foreach (var item in list)
                //{
                //    Console.WriteLine(item);
                //}

                #endregion

                #region 如果hashid集合中存在key/value则不添加返回false，如果不存在在添加key/value,返回true
                //Console.WriteLine(client.SetEntryInHashIfNotExists(hashid, "name", "daniel"));
                //Console.WriteLine(client.SetEntryInHashIfNotExists(hashid, "name", "dragon warrior"));
                //Console.WriteLine(client.GetValuesFromHash(hashid, "name").FirstOrDefault());
                #endregion

                #region 存储对象T t到hash集合中

                ////urn: 类名: id的值 、、如果使用对象操作，一定要有id
                //client.StoreAsHash<UserInfo>(new UserInfo() { Id = 1, Name = "daniel", number = 0 });
                //Console.WriteLine(client.GetFromHash<UserInfo>(1).Name);

                ////如果id存在的话，则覆盖之前相同的id 他帮助我们序列化或者反射了一些事儿
                //client.StoreAsHash<UserInfo>(new UserInfo() { Id = 2, Name = "dragon warrior" });
                //Console.WriteLine(client.GetFromHash<UserInfo>(2).Name);

                ////获取对象T中ID为id的数据。 必须要有属性id，不区分大小写
                //Console.WriteLine(client.GetFromHash<UserInfo>(1).Name);
                //var olduserinfo = client.GetFromHash<UserInfo>(1);
                //olduserinfo.number = 4;

                //client.StoreAsHash<UserInfo>(olduserinfo);
                //Console.WriteLine("最后的结果" + client.GetFromHash<UserInfo>(1).number);
                //client.StoreAsHash<UserInfoTwo>(new UserInfoTwo() { Id = "001", Name = "tom" });
                //Console.WriteLine(client.GetFromHash<UserInfoTwo>("001").Name);
                //client.StoreAsHash<UserInfoTwo>(new UserInfoTwo() { Id = "002", Name = "jerry" });
                //Console.WriteLine(client.GetFromHash<UserInfoTwo>("002").Name);

                //UserInfo lisi = new UserInfo() { Id = 1, Name = "李四", number = 0 };
                //client.StoreAsHash<UserInfo>(lisi);
                //Console.WriteLine(client.GetFromHash<UserInfo>(1).number);
                ////做个自增
                //var oldzhang = client.GetFromHash<UserInfo>(1);
                //oldzhang.number++;
                //client.StoreAsHash<UserInfo>(oldzhang);

                #endregion

                #region 获取所有hashid数据集的key/value数据集合

                //Dictionary<string, string> pairs = new Dictionary<string, string>();
                //pairs.Add("id", "001");
                //pairs.Add("name", "daniel");
                //client.SetRangeInHash(hashid, pairs);
                //Console.WriteLine("所有key/value集合");
                //var dics = client.GetAllEntriesFromHash(hashid);
                //foreach (var item in dics)
                //{
                //    Console.WriteLine(item.Key + ":" + item.Value);
                //}
                ////获取hashid数据集中的数据总数
                //Console.WriteLine("Total: " + client.GetHashCount(hashid));

                //Console.WriteLine("所有keys");
                //var keys = client.GetHashKeys(hashid);
                //foreach (var item in keys)
                //{
                //    Console.WriteLine(item);
                //}
                //Console.WriteLine("所有values");
                //var values = client.GetHashValues(hashid);
                //foreach (var item in values)
                //{
                //    Console.WriteLine(item);
                //}

                #endregion

                #region 判断hashid数据集中是否存在key的数据
                //Dictionary<string, string> pairs = new Dictionary<string, string>();
                //pairs.Add("id", "001");
                //pairs.Add("name", "daniel");
                //client.SetRangeInHash(hashid, pairs);
                //Console.WriteLine(client.HashContainsEntry(hashid, "id")); //T  F
                //Console.WriteLine(client.HashContainsEntry(hashid, "number"));// T F
                #endregion

                #region 给hashid数据集key的value加countby，返回相加后的数据
                //Dictionary<string, string> pairs = new Dictionary<string, string>();
                //pairs.Add("id", "001");
                //pairs.Add("name", "daniel");
                //pairs.Add("number", "2");
                //client.SetRangeInHash(hashid, pairs);
                //Console.WriteLine(client.IncrementValueInHash(hashid, "number", 2));
                ////注意，存的值必须是数字类型，否则抛出异常
                #endregion

                #region 自定义
                //HashTool.StoreAsHash<UserInfoTwo>(new UserInfoTwo() { Id = "10001", Name = "daniel" });
                //var user = HashTool.GetFromHash<UserInfoTwo>("10001");
                //Console.WriteLine("It's the end");
                #endregion
            }
        }
    }
}