using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace robot.Models
{

    /// <summary>
    /// api返回结果对应的类，仅抽取程序需要的属性
    /// </summary>
    public class ApiResultJson
    {
        public string id { get; set; }
        public string timestamp { get; set; }
        public ApiResult result { get; set; }
        public ApiStatus status { get; set; }
    }
    public class ApiResult
    {
        public string action { get; set; }
        //bool actionIncomplete;
        public ApiMetadata metadata { get; set; }
        public string speech { get; set; }//返回消息
        public string source { get; set; }//消息来源
        public double score { get; set; }
    }
    public class ApiStatus
    {
        public int code { get; set; }
        public string errorType { get; set; }
        public string errorDetails { get; set; }
    }

    public class ApiMetadata
    {
        public string intentId { get; set; }
        public string intentName { get; set; }

    }
    
}