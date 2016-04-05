using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace robot.Models
{

    /// <summary>
    /// 发送给api的json对应的类
    /// </summary>
    public class ApiJson
    {
        //The natural language text to be processed.The request can have multiple query parameters.
        public List<string> query;//Required unless sound file/stream is submitted.
                                  //The confidence of the corresponding query parameter having been correctly recognized by a speech recognition system. 0 represents no confidence and 1 represents the highest confidence. 
        public List<int> confidence;//Required when multiple query parameters are used.
                                    //Array of additional input context objects.
        public List<Context> contexts;//Optional.
                                      //If true, all current contexts in a session will be reset before the new ones are set.False by default.
        public bool resetContexts;//Optional
        public Location location;
        //Time zone from IANA Time Zone Database.
        public string timezone;//Optional
                               //Language tag, e.g.EN, ES, ... 
        public string lang;//Required.
                           //A string token up to 36 symbols long, used to identify the client and to manage sessions parameters (including contexts) per client.
        public string sessionid; //Required.
                                 //Version of the protocol, e.g.v=20150910
        public string v; //Must be used as a URL parameter.
        
        /// <summary>
        /// 返回成json字符串
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            string result = "{'query':[";
            for (int i = 0; i < query.Count() - 1; i++)
            {
                result += "'" + query[i] + "',";
            }
            result += "'" + query.Last() + "'],";
            if (contexts!=null)
            {
                result += "'contexts':[";
                for (int i = 0; i < contexts.Count()-1; i++)
                {
                    result += contexts[i].ToString()+",";
                }
                result += contexts.Last().ToString()+"],";
            }
            if (confidence!=null)
            {
                result += "'confidence':[";
                for (int i = 0; i < confidence.Count() - 1; i++)
                {
                    result += confidence[i] + ",";
                }
                result += confidence.Last() + "],";
            }
            
            if (location!=null)
            {
                result += "'location':" + location.ToString() + ",";
            }
            if (timezone!=null)
            {
                result += "'timezone':" + timezone + ",";
            }
            result += "'resetContexts':" + resetContexts.ToString() + ",";
            result += "'lang':" + lang+ ",";
            result += "'sessionid':" + sessionid + ",";
            result += "'v':" + v+"}";
            return result;
        }

    }
    public class Context
    {
        string name;
        int lifespan;

        override public string ToString()
        {
            return "{ 'name:':" + name + ",'lifespan':" + lifespan + "}";
        }
    }
    public class Location
    {
        double latitude;
        double longitude;
        override public string ToString()
        {
            return "{ 'latitude:':" + latitude + ",'longitude':" + longitude + "}";
        }

    }

}