using Newtonsoft.Json;
using robot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace robot.ServiceHelper
{

    /// <summary>
    /// Api.ai接口对接帮助类
    /// </summary>
    public class ApiHelper
    {
        //接口地址
        private const string API_URL = "https://api.api.ai/v1/query";
        private const string API_TOKEN_CLIENT = "d9cd4aa0589c45a285388fe25db9763f";
        //要提交的postbody
        private string postbody;

        public ApiHelper(string postbody)
        {
            this.postbody = postbody;
        }

        /// <summary>
        /// 返回post请求结果
        /// </summary>
        /// <returns></returns>
        private string GetApiHttp()
        {

            //初始化http帮助类
            HttpHelper httphelper = new HttpHelper();
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("Authorization", "Bearer " + API_TOKEN_CLIENT));
            string message = httphelper.HttpPost(API_URL, postbody, list);
            return message;
        }

        /// <summary>
        /// 得到Api返回结果，并封装成html的形式
        /// </summary>
        /// <returns></returns>
        public string GetApiPost()
        {
            string httptext = GetApiHttp();
            ApiResultJson jsonResult = JsonConvert.DeserializeObject<ApiResultJson>(httptext);
            switch (jsonResult.status.code)
            {
                case 200:
                    if (jsonResult.result.speech != null&& jsonResult.result.speech!="")
                    {
                        return jsonResult.result.speech;
                    }
                    else
                        return "尊敬的用户你好，您的问题暂时无法回答";
                   
                default:
                    return jsonResult.status.errorDetails;
            }
        }





    }
}