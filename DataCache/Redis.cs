using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;
using System.Collections;

namespace DataCache
{
    public class Redis
    {
         static Dictionary<string, PooledRedisClientManager> CacheServerList = 
             new Dictionary<string, PooledRedisClientManager>();
    public Redis()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
        AddCacheServer("10.1.1.98", "SESSION");
        AddCacheServer("10.1.1.98", "TEMP");
    }
    /// <summary>
    /// 添加redis服务器
    /// </summary>
    /// <param name="serverIP"></param>
    /// <param name="preKey"></param>
    private static void AddCacheServer(string serverIP, string preKey)
    {
        int maxReadPool = 100;
        int maxWritePool = 50;
        AddCacheServer(serverIP, preKey, maxReadPool, maxWritePool);
    }
    private static void AddCacheServer(string serverIP, string preKey, int maxReadPool, int maxWritePool)
    {
        ServiceStack.Redis.RedisClientManagerConfig PoolConfig = new RedisClientManagerConfig();
        PoolConfig.MaxReadPoolSize = maxReadPool;
        PoolConfig.MaxWritePoolSize = maxWritePool;

        PooledRedisClientManager client = new PooledRedisClientManager(new string[] { serverIP }, new string[] { serverIP }, PoolConfig);
        CacheServerList.Add(preKey, client);
    }
    /// <summary>
    /// 从池中获取一客户端
    /// </summary>
    /// <param name="preKey"></param>
    /// <returns></returns>
    private static IRedisClient GetClient(string preKey)
    {
        PooledRedisClientManager clm = CacheServerList[preKey];
        return clm.GetClient();
    }
    /// <summary>
    /// 获取一redis 客户端
    /// </summary>
    /// <param name="preKey"></param>
    /// <returns></returns>
    private static RedisNativeClient GetNativeClient(string preKey)
    {
        PooledRedisClientManager clm = (PooledRedisClientManager)CacheServerList[preKey];
        return (RedisNativeClient)(clm.GetClient());
    }

    #region 公用
    /// <summary>
    /// 设置过期时间
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="key"></param>
    /// <param name="timeSpan"></param>
    /// <returns></returns>
    public static bool ExpireKey(string cacheSpace, string key, TimeSpan timeSpan)
    {
        if (cacheSpace == null || key == null)
            return false;
        string redis_key = cacheSpace + ":" + key;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            client.Expire(redis_key, Convert.ToInt32(timeSpan.TotalSeconds));
        }
        return true;
    }
    /// <summary>
    /// 移除 一key
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool Remove(string cacheSpace, string key)
    {
        if (cacheSpace == null || key == null)
            return false;
        string redis_key = cacheSpace + ":" + key;
        using (IRedisClient client = GetClient(cacheSpace))
        {
            client.Remove(redis_key);
        }
        return true;
    }
    /// <summary>
    /// 判断一key 是否存在
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool Exists(string cacheSpace, string key)
    {
        if (cacheSpace == null || key == null)
            return false;
        string redis_key = cacheSpace + ":" + key;
        using (RedisNativeClient Client = GetNativeClient(cacheSpace))
        {
            return Client.Exists(redis_key) == 1;
        }
    }
    /// <summary>
    /// 增加数值
    /// </summary>
    /// <param name="key_space"></param>
    /// <param name="obj_string"></param>
    /// <returns></returns>
    public static long Increment(string cacheSpace, string key)
    {
        if (key == null || cacheSpace == null)
            return 0;
        string redis_key = cacheSpace + ":" + key;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            return client.Incr(redis_key);
        }
    }
    #endregion

    #region hash
    /// <summary>
    /// 删除fromhash
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="hashID"></param>
    /// <param name="hashKey"></param>
    /// <returns></returns>
    public static bool DeleteEntryFromHash(string cacheSpace, string hashID, string hashKey)
    {
        if (hashID == null || cacheSpace == null || hashKey == null)
            return false;

        string redis_key = cacheSpace + ":" + hashID;
        using (RedisNativeClient clent = GetNativeClient(cacheSpace))
        {
            clent.HDel(redis_key, Encoding.UTF8.GetBytes(hashKey));
            return true;
        }
    }
    /// <summary>
    /// 删除从Hash 多值 
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="hashID"></param>
    /// <param name="hashKeys"></param>
    /// <returns></returns>
    public static bool DeleteEntryFromHash(string cacheSpace, string hashID, string[] hashKeys)
    {
        if (hashID == null || cacheSpace == null || hashKeys == null)
            return false;
        string redis_key = cacheSpace + ":" + hashID;
        using (RedisNativeClient clent = GetNativeClient(cacheSpace))
        {
            for (int i = 0; i < hashKeys.Length; i++)
            {
                clent.HDel(redis_key, Encoding.UTF8.GetBytes(hashKeys[i]));
            }
            return true;
        }
    }
    /// <summary>
    /// 增加如果不存在
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="hashID"></param>
    /// <param name="hashKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool SetEntryInHashNotExists(string cacheSpace, string hashID, string hashKey, object value)
    {
        if (hashID == null || cacheSpace == null || hashKey == null || value == null)
            return false;

        string redis_key = cacheSpace + ":" + hashID;
        using (RedisNativeClient RNC = GetNativeClient(cacheSpace))
        {
            RNC.HSet(redis_key, Encoding.UTF8.GetBytes(hashKey), Serializer.Serialize(value));
            return true;
        }
    }
    /// <summary>
    /// 增加如果不存在
    /// </summary>
    /// <param name="cacheSpace">缓存空间</param>
    /// <param name="hashID">hashid</param>
    /// <param name="hashKey">hash键</param>
    /// <param name="value">hash值</param>
    /// <returns></returns>
    public static bool SetEntryInHashNotExists(string cacheSpace, string hashID, string hashKey, string value)
    {
        if (hashID == null || cacheSpace == null || hashKey == null || value == null)
            return false;
        string redis_key = cacheSpace + ":" + hashID;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            client.HSetNX(redis_key, Encoding.UTF8.GetBytes(hashKey), Encoding.UTF8.GetBytes(value));
            return true;
        }
    }


    public static bool SetEntryInHash(string cacheSpace, string hashID, string hashKey, object value)
    {
        if (hashID == null || cacheSpace == null || hashKey == null || value == null)
            return false;

        string redis_key = cacheSpace + ":" + hashID;
        using (RedisNativeClient RNC = GetNativeClient(cacheSpace))
        {
            RNC.HSet(redis_key, Encoding.UTF8.GetBytes(hashKey), Serializer.Serialize(value));
            return true;
        }
    }
    ///// <summary>
    ///// 存在则修改 不存在则保存
    ///// </summary>
    ///// <param name="cacheSpace"></param>
    ///// <param name="hashID"></param>
    ///// <param name="hashKey"></param>
    ///// <param name="value"></param>
    ///// <returns></returns>
    //public static bool SetEntryInHash(string cacheSpace, string hashID, string hashKey, string value)
    //{
    //    if (hashID == null || cacheSpace == null || hashKey == null || value == null)
    //        return false;

    //    string redis_key = cacheSpace + ":" + hashID;

    //    using (RedisNativeClient client = GetNativeClient(cacheSpace))
    //    {
    //        client.HSet(redis_key, Encoding.UTF8.GetBytes(hashKey), Encoding.UTF8.GetBytes(value));
    //        return true;
    //    }
    //}
    public static int SetRangeInHash(string cacheSpace, string hashID, Hashtable value)
    {
        if (hashID == null || cacheSpace == null)
            return 0;

        int count = 0;
        string redis_key = cacheSpace + ":" + hashID;

        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            foreach (DictionaryEntry de in value)
            {
                string key_string = de.Key.ToString(); //只考虑string类型的key
                object value_obj = de.Value;

                client.HSet(redis_key, Encoding.UTF8.GetBytes(key_string), Serializer.Serialize(value_obj));
                count++;
            }
        }
        return count;
    }
    /// <summary>
    /// 设置hash
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="hashID"></param>
    /// <param name="value"></param>
    /// <param name="timeSpan"></param>
    /// <returns></returns>
    public static int SetRangeInHash(string cacheSpace, string hashID, Hashtable value, TimeSpan timeSpan)
    {
        int count = SetRangeInHash(cacheSpace, hashID, value);
        if (count == 0)
            return count;
        ExpireKey(cacheSpace, hashID, timeSpan);
        return count;
    }
    /// <summary>
    /// 获取一hashKey
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="hashID"></param>
    /// <param name="hashKey"></param>
    /// <returns></returns>
    public static string GetValueFromHash(string cacheSpace, string hashID, string hashKey)
    {
        if (cacheSpace == null || hashID == null || hashKey == null)
            return null;
        string redis_key = cacheSpace + ":" + hashID;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            byte[] hash_value = client.HGet(redis_key, Encoding.UTF8.GetBytes(hashKey));

            if (hash_value == null)
                return null;
            return Encoding.UTF8.GetString(hash_value);
        }
    }
    public static T GetValueFromHash<T>(string cacheSpace, string hashID, string hashKey)
    {
        if (cacheSpace == null || hashID == null || hashKey == null)
            return default(T);
        string redis_key = cacheSpace + ":" + hashID;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            byte[] hash_value = client.HGet(redis_key, Encoding.UTF8.GetBytes(hashKey));

            if (hash_value == null)
                return default(T);
            object value = Serializer.DeSerialize(hash_value);
            if (value is T)
            {
                return (T)value;
            }
            else
            {
                return default(T);
            }
        }
    }
    /// <summary>
    /// 获取所有HashValue
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="hashID"></param>
    /// <returns></returns>
    public static Hashtable GetAllValueFromHash(string cacheSpace, string hashID)
    {
        if (cacheSpace == null || hashID == null)
            return null;
        string redis_key = cacheSpace + ":" + hashID;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            byte[][] hash_result = client.HGetAll(redis_key);
            if (hash_result == null)
                return null;
            Hashtable ht_result = new Hashtable();
            for (int i = 0; i < hash_result.Length; i += 2)
            {
                string this_key = Encoding.UTF8.GetString(hash_result[i]);
                object this_value = Serializer.DeSerialize(hash_result[i + 1]);
                ht_result.Add(this_key, this_value);
            }
            return ht_result;
        }
    }
    /// <summary>
    /// 根据key 获取 value
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="hashID"></param>
    /// <param name="hashkeys"></param>
    /// <returns></returns>
    public static Hashtable GetAllEntriesFromHash(string cacheSpace, string hashID, string[] hashkeys)
    {
        if (cacheSpace == null || hashID == null)
            return null;

        string redis_key = cacheSpace + ":" + hashID;

        byte[][] key_list_bytearray = new byte[hashkeys.Length][];
        for (int i = 0; i < hashkeys.Length; i++)
            key_list_bytearray[i] = Encoding.UTF8.GetBytes(hashkeys[i]);

        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            byte[][] hash_result = client.HMGet(redis_key, key_list_bytearray);
            if (hash_result == null)
                return null;

            Hashtable ht_result = new Hashtable();

            for (int i = 0; i < hash_result.Length; i++)
            {
                if (hash_result[i] == null || i > hashkeys.Length) //这个得考虑木有的情况了 
                    continue;
                object this_value = Serializer.DeSerialize(hash_result[i]);
                ht_result.Add(hashkeys[i], this_value);
            }
            return ht_result;
        }
    }
    #endregion
    #region  列表
    public static void AddRangeToList()
    { }
    public static int  AddItemToList(string cacheSpace, string keyID, object value)
    {
        if (cacheSpace == null || keyID == null)
            return 0;
        string redis_key = cacheSpace + ":" + keyID;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            return client.RPush(redis_key, Serializer.Serialize(value));
        }
    }
    public static int AddItemToList(string cacheSpace, string keyID, string value)
    {
        if (cacheSpace == null || keyID == null)
            return 0;
        string redis_key = cacheSpace + ":" + keyID;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            return client.RPush(redis_key, Encoding.UTF8.GetBytes(value));
        }
    }
    public static int AddItemToList(string cacheSpace, string keyID, byte[] bytes)
    {
        if (cacheSpace == null || keyID == null)
            return 0;
        string redis_key = cacheSpace + ":" + keyID;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            return client.RPush(redis_key, bytes);
        }
    }
    public bool AddItemToSortedSet(string cacheSpace, string setId, string value)
    {
        return false;
    }
    //public static void AddRangeToList(string cacheSpace, string keyID, List<string> value)
    //{
       
    //}
    /// <summary>
    /// 添加列表 带分数
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="setId"></param>
    /// <param name="value"></param>
    /// <param name="score"></param>
    /// <returns></returns>
    public static bool AddItemToSortedSet(string cacheSpace, string setId, string value, double score)
    {
        if (cacheSpace == null || setId == null)
            return false;

        string redis_key = cacheSpace + ":" + setId;


        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            return client.ZAdd(redis_key, score, Encoding.UTF8.GetBytes(value)) > 0;
        }
    }
    /// <summary>
    /// 根据分数移除列表
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="setId"></param>
    /// <param name="minRank"></param>
    /// <param name="maxRank"></param>
    /// <returns></returns>
    public static bool RemoveRangeFromSortedSet(string cacheSpace, string setId, int minRank, int maxRank)
    {
        if (cacheSpace == null || setId == null)
            return false;

        string redis_key = cacheSpace + ":" + setId;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            return client.ZRemRangeByRank(redis_key, minRank, maxRank) > 0;
        }

    }
    /// <summary>
    /// 获取一List
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="listId"></param>
    /// <param name="startingFrom"></param>
    /// <param name="endingAt"></param>
    /// <returns></returns>
    public static List<string> GetRangeFromList(string cacheSpace, string listId, int startingFrom, int endingAt)
    {
        if (cacheSpace == null || listId == null)
            return null;

        string redis_key = cacheSpace + ":" + listId;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            byte[][] ret = client.ZRange(redis_key, startingFrom, endingAt);
            if (ret == null)
                return null;
            List<string> retList = new List<string>();
            for (int i = 0; i < ret.Length; i++)
                retList.Add(Encoding.UTF8.GetString(ret[i]));

            return retList;
        }
    }
    /// <summary>
    /// 获取一list根据分数
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="listId"></param>
    /// <param name="startingFrom"></param>
    /// <param name="endingAt"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public static List<string> GetRangeFromListWithScore(string cacheSpace, string listId, int startingFrom, int endingAt, string direction)
    {
        if (cacheSpace == null || listId == null)
            return null;

        string redis_key = cacheSpace + ":" + listId;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            byte[][] ret = null;
            ret = direction == "ASC" ? client.ZRangeWithScores(redis_key, startingFrom, endingAt) : client.ZRevRangeWithScores(redis_key, startingFrom, endingAt);
            if (ret == null)
                return null;
            List<string> retList = new List<string>();
            for (int i = 0; i < ret.Length; i++)
                retList.Add(Encoding.UTF8.GetString(ret[i]));

            return retList;
        }
    }
    /// <summary>
    /// 获取一list
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="listId"></param>
    /// <param name="startingFrom"></param>
    /// <param name="endingAt"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public static List<string> GetRangeFromList(string cacheSpace, string listId, int startingFrom, int endingAt, string direction)
    {
        if (cacheSpace == null || listId == null)
            return null;

        string redis_key = cacheSpace + ":" + listId;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            byte[][] ret = null;
            ret = direction == "ASC" ? client.ZRange(redis_key, startingFrom, endingAt) : client.ZRevRange(redis_key, startingFrom, endingAt);
            if (ret == null)
                return null;
            List<string> retList = new List<string>();
            for (int i = 0; i < ret.Length; i++)
                retList.Add(Encoding.UTF8.GetString(ret[i]));

            return retList;
        }
    }
    /// <summary>
    /// 获取列表长度
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static int GetListCount(string cacheSpace,string key)
    {
        if (cacheSpace == null || key == null)
            return 0;
        string redis_key = cacheSpace + ":" + key;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            return client.LLen(redis_key);
        }
    }
    /// <summary>
    /// 获取列表长度
    /// </summary>
    /// <param name="cacheSpace"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static int GetSortedSetCount(string cacheSpace, string key)
    {
        if (cacheSpace == null || key == null)
            return 0;
        string redis_key = cacheSpace + ":" + key;
        using (RedisNativeClient client = GetNativeClient(cacheSpace))
        {
            return client.ZCard(redis_key);
        }
    }
    #endregion
    }
}
