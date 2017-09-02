using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Redis;

public class RedisHelp
{
    static RedisClient Redis = new RedisClient("127.0.0.1", 6379);//redis服务IP和端口

    public static void addlist(string name,string vlaue) 
    {
        Redis.AddItemToList(name,vlaue);
    }

}
